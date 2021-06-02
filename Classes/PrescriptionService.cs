using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    class PrescriptionService
    {
        PerscriptionRepository prescriptionRepository = new PerscriptionRepository();
        PatientAllergyRepository patientAllergyRepository = new PatientAllergyRepository();
        MedicineRepository medicineRepository = new MedicineRepository();
        AllergiesRepository allergiesRepository = new AllergiesRepository();

        public Boolean Create(Perscription perscription, String patientId)
        {
            if (!isAllergic(perscription, patientId))
               return prescriptionRepository.Create(perscription, patientId);
            return false;
        }

        private Boolean isAllergic(Perscription perscription, String patientId)
        {
            List<PatientAllergy> patientAllergies = patientAllergyRepository.GetAllByPatientID(patientId);
            List<Allergy> MedicineAllergies = (medicineRepository.GetById(perscription.Medicine.Id)).Allergies;

            foreach (PatientAllergy patientAllergy in patientAllergies)
            {
                foreach(Allergy medicineAllergy in MedicineAllergies)
                {
                    if ((allergiesRepository.GetByID(patientAllergy.allergy.Id1).Name1).Equals(medicineAllergy.Name1))
                        return true;
                }
            }
            return false;
        }

    }
}
