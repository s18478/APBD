using System;

namespace Classes4.Models
{
    public class Enrollment
    {
        public int IdEnrollment { get; set; }

        public int Semester { get; set; }

        public int IdStudy { get; set; }

        public DateTime StartDate { get; set; }
        
        public override string ToString()
        {
            return "IdEnrollment: " + IdEnrollment + ", Semester: " +
                   Semester + ", IdStudy: " + IdStudy + ", Start Date: " + StartDate.ToString("MM/dd/yyyy");
        }
    }
}