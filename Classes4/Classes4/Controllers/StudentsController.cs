using System.Collections.Generic;
using System.Data.SqlClient;
using Classes4.Models;
using Microsoft.AspNetCore.Mvc;

namespace Classes4.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : Controller
    {
        private const string connecionString = "Data Source=db-mssql.pjwstk.edu.pl;" +
                                               "Initial Catalog=s18478;" +
                                               "Integrated Security=True";
        
        [HttpGet]
        public IActionResult GetStudents()
        {
            var list = new List<Student>();
            
            using (var connection = new SqlConnection(connecionString))
            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Student";
                
                connection.Open();
                var sdr = command.ExecuteReader();    // SqlDataReader

                while (sdr.Read())
                {
                    var st = new Student();
                    st.IndexNumber = sdr["IndexNumber"].ToString();
                    st.FirstName = sdr["FirstName"].ToString();
                    st.LastName = sdr["LastName"].ToString();
                    
                    list.Add(st);
                }
            }
            return Ok(list);
        }
    }
}