using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    class PatientAllergy
    {
        public String patientID;
        public int allergyID;

        public PatientAllergy(string patientID, int allergyID)
        {
            this.patientID = patientID;
            this.allergyID = allergyID;
        }
    }
}
