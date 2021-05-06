using System.Collections.Generic;
namespace Classes
{
    public class MedicalRecord
    {
        public Patient patient;
        public List<Perscription> perscriptions;
        public List<Allergy> allergies;
        public List<Anamnesis> anamneses;


        public MedicalRecord()
        {
            perscriptions = new List<Perscription>();
            allergies = new List<Allergy>();
            anamneses = new List<Anamnesis>();
        }


    }
}