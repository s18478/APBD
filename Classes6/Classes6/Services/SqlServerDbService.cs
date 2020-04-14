using System.Data.SqlClient;
using Classes6.Models;

namespace Classes6.Services
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

                comm.CommandText = "SELECT TOP 1 IndexNumber, FirstName, LastName FROM Student WHERE IndexNumber = @index;";
                comm.Parameters.AddWithValue("index", index);
                var sdr = comm.ExecuteReader();

                if (sdr.Read())
                {
                    var student = new Student();
                    student.Index = sdr["IndexNumber"].ToString();
                    student.FirstName = sdr["FirstName"].ToString();
                    student.LastName = sdr["LastName"].ToString();

                    return student;
                }

                return null;
            }
        }
    }
}