using System;
using System.Xml.Serialization;

namespace Classes2
{
    [XmlRoot("student")]
    public class Student
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Birthdate { get; set; }
        public string Email { get; set; }
        public string MothersName { get; set; }
        public string FathersName { get; set; }
        public string StudiesName { get; set; }
        public string Mode { get; set; }

        public override int GetHashCode()
        {
            return Int32.Parse(Id);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) 
                return false;

            Student st = obj as Student;
            
            return Id.Equals(st.Id);
        }
    }
}