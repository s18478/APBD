using System;
using System.Data.SqlClient;
using Classes5.Models;
using Classes5.Models.DTOs.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Classes5.Controllers
{
    [ApiController]
    [Route("api/enrollments")]
    public class EnrollmentsController : ControllerBase
    {
        private const string connecionString = "Data Source=db-mssql.pjwstk.edu.pl;" +
                                               "Initial Catalog=s18478;" +
                                               "Integrated Security=True";
        
        [HttpPost]
        public IActionResult EnrollStudent(EnrollStudentRequest request)
        {
            // For response
            Enrollment enrollment = new Enrollment();
            
            using (var conn = new SqlConnection(connecionString))
            using (var comm = new SqlCommand())
            {
                conn.Open();
                comm.Connection = conn;

                var tran = conn.BeginTransaction();
                comm.Transaction = tran;

                try
                {
                    SqlDataReader sdr;

                    // Does the studies exist ?
                    comm.CommandText = "SELECT IdStudy FROM Studies WHERE Name = @name";
                    comm.Parameters.AddWithValue("name", request.Studies);
                    sdr = comm.ExecuteReader();
                    
                    if (!sdr.Read())
                    {
                        sdr.Close();
                        tran.Rollback();
                        return BadRequest("Studies does not exist !");
                    }
                    
                    enrollment.IdStudy = (int) sdr["IdStudy"];
                    sdr.Close();
                    
                    // Does the enrollment exist ? If it does not exist, add new 
                    comm.CommandText = "SELECT IdEnrollment, StartDate FROM Enrollment WHERE IdStudy = @idStudy AND Semester = 1";
                    comm.Parameters.AddWithValue("idStudy", enrollment.IdStudy);
                    sdr = comm.ExecuteReader();

                    // Does not exist (add new)
                    if (!sdr.Read())
                    {
                        sdr.Close();
                        
                        // New enrollment index
                        comm.CommandText = "SELECT MAX(IdEnrollment) FROM Enrollment";
                        sdr = comm.ExecuteReader();

                        int id = 1;
                        
                        if (sdr.Read() && !DBNull.Value.Equals(sdr[0]))
                        {
                            id += (int) sdr[0];
                        }
                        
                        sdr.Close();
                        
                        comm.CommandText = "INSERT INTO Enrollment VALUES (@id, 1, @idStudy, @startDate)";
                        comm.Parameters.AddWithValue("id", id);
                        comm.Parameters.AddWithValue("startDate", DateTime.Now.Date);
                        comm.ExecuteNonQuery();

                        enrollment.IdEnrollment = id;
                        enrollment.StartDate = DateTime.Now;
                    }
                    else
                    {
                        enrollment.IdEnrollment = (int) sdr["IdEnrollment"];
                        enrollment.StartDate = (DateTime) sdr["StartDate"];
                    }

                    enrollment.Semester = 1;
                    sdr.Close();
            
                    // Check the index number (unique)
                    comm.CommandText = "SELECT IndexNumber FROM Student WHERE IndexNumber = @index";
                    comm.Parameters.AddWithValue("index", request.IndexNumber);
                    sdr = comm.ExecuteReader();

                    if (sdr.Read())
                    {
                        sdr.Close();
                        tran.Rollback();
                        return BadRequest("Index exists in database!");
                    }
                    
                    comm.CommandText = "INSERT INTO Student VALUES (@index, @fname, @lname, @birthdate, @idEnroll)";
                    comm.Parameters.AddWithValue("fname", request.FirstName);
                    comm.Parameters.AddWithValue("lname", request.LastName);
                    comm.Parameters.AddWithValue("birthdate", DateTime.Parse(request.BirthDate));
                    comm.Parameters.AddWithValue("idEnroll", enrollment.IdEnrollment);
                    sdr.Close();
                    comm.ExecuteNonQuery();

                    tran.Commit();
                }
                catch (SqlException exc)
                {
                    tran.Rollback();
                    return Problem(exc.Message);
                }
            }
            
            // If everything is okay return code 201 and enrollment 
            return Created(enrollment.ToString(), enrollment);
        }
    }
}