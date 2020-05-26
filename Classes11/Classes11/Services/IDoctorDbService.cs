using System;
using System.Collections.Generic;
using Classes11.Models;
using Classes11.Models.DTOs;

namespace Classes11.Services
{
    public interface IDoctorDbService
    {
        public IEnumerable<Doctor> GetDoctors();
        public Doctor CreateDoctor(CreateOrUpdateDoctorRequest request);
        public Doctor UpdateDoctor(int id, CreateOrUpdateDoctorRequest request);
        public bool DeleteDoctor(int id);
    }
}