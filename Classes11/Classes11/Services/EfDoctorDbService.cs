using System;
using System.Collections.Generic;
using System.Linq;
using Classes11.Models;
using Classes11.Models.DTOs;
using Microsoft.EntityFrameworkCore;

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

        public Doctor CreateDoctor(CreateOrUpdateDoctorRequest request)
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

        public Doctor UpdateDoctor(int id, CreateOrUpdateDoctorRequest request)
        {
            Console.WriteLine(id);
            if (_context.Doctors.Any(d => d.IdDoctor == id))
            {
                Console.WriteLine("Exist");
                Doctor doctor = new Doctor
                {
                    IdDoctor = id,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email
                };

                _context.Attach(doctor);
                _context.Entry(doctor).State = EntityState.Modified;
                _context.SaveChanges();

                return doctor;
            }
            Console.WriteLine("Not exist");
            throw new Exception("Doctor not found.");
        }

        public bool DeleteDoctor()
        {
            throw new System.NotImplementedException();
        }
    }
}