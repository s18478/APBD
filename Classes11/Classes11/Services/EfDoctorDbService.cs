using System.Collections.Generic;
using System.Linq;
using Classes11.Models;
using Classes11.Models.DTOs;

namespace Classes11.Services
{
    public class EfDoctorDbService : IDoctorDbService
    {
        private readonly ClinicDbContext _context;

        public EfDoctorDbService(ClinicDbContext context)
        {
            _context = context;
        }
        
        public IEnumerable<Doctor> GetDoctors()
        {
            return _context.Doctors.ToList();
        }

        public Doctor CreateDoctor(CreateDoctorRequest request)
        {
            Doctor doctor = new Doctor
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email
            };

            _context.Doctors.Add(doctor);
            _context.SaveChanges();

            return doctor;
        }

        public Doctor UpdateDoctor()
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteDoctor()
        {
            throw new System.NotImplementedException();
        }
    }
}