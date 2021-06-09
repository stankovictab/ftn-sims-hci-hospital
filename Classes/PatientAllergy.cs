using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class PatientAllergy
    {
        public String patientID { get; set; }
        public Allergy allergy { get; set; }

        public PatientAllergy(string patientID, Allergy allergy)
        {
            this.patientID = patientID;
            this.allergy = allergy;
        }
    }
}
