using System.Collections;
using System.Collections.Generic;

namespace Classes11.Models
{
    public class Medicament
    {
        public int IdMedicament { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        
        public virtual ICollection<PrescriptionMedicament> PrescriptionMedicament { get; set; }
    }
}