using Classes7.Models;

namespace Classes7.Services
{
    public interface IStudentDbService
    {
        public Student GetStudent(string index);
    }
}