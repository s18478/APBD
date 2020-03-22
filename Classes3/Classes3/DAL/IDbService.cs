using System.Collections.Generic;
using Classes3.Models;

namespace Classes3.DAL
{
    public interface IDbService
    {
        public IEnumerable<Student> GetStudents();
    }
}