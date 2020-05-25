using System;
using System.Collections.Generic;
using Classes11.Models;
using Classes11.Models.DTOs;

namespace Classes11.Services
{
    public interface IDoctorDbService
    {
        public IEnumerable<Doctor> GetDoctors();
        public Doctor CreateDoctor(CreateDoctorRequest request);
        public Doctor UpdateDoctor();
        public bool DeleteDoctor();
    }
}