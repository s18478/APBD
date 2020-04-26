using System.Data.SqlClient;
using Classes7.Models;
using Microsoft.AspNetCore.Mvc;

namespace Classes7.Services
{
    public class SqlServerDbService : IStudentDbService
    {
        private const string connecionString = "Data Source=db-mssql.pjwstk.edu.pl;" +
                                               "Initial Catalog=s18478;" +
                                               "Integrated Security=True";
        
        public Student GetStudent(string index)
        {
            using (var conn = new SqlConnection(connecionString))
            using (var comm = new SqlCommand()) 
            {
                conn.Open();
                comm.Connection = conn;

                comm.CommandText = "SELECT IndexNumber, FirstName, LastName, Password " +
                                   "FROM Student WHERE IndexNumber = @index";
                comm.Parameters.AddWithValue("index", index);

                var reader = comm.ExecuteReader();

                if (!reader.Read())
                {
                    return null;
                }

                Student student = new Student();
                
                student.IndexNumber = reader["IndexNumber"].ToString();
                student.FirstName = reader["FirstName"].ToString();
                student.LastName = reader["LastName"].ToString();
                student.Password = reader["Password"].ToString();

                return student;
            }
        }
    }
}