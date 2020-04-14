using System;
using Classes6.Models;

namespace Classes6.Services
{
    public interface IStudentDbService
    {
        public Student GetStudent(string index);
    }
}