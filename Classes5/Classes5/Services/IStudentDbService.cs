using Classes5.Models;
using Classes5.Models.DTOs.Requests;

namespace Classes5.Services
{
    public interface IStudentDbService
    {
        public Enrollment EnrollStudent(EnrollStudentRequest request);
        public Enrollment PromoteStudents(PromoteStudentRequest request);
    }
}