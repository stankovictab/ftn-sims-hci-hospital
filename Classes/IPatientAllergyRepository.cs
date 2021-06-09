using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public interface IPatientAllergyRepository
    {
        List<PatientAllergy> PatientAllergiesInFile { get; set; }
        Boolean Create(PatientAllergy pa);
        List<PatientAllergy> GetAllByPatientID(String id);
        List<PatientAllergy> GetAll();
        Boolean Update(PatientAllergy pa);
        Boolean UpdateAll(List<PatientAllergy> paif);
        Boolean DeleteByPatientID(String id);


    }
}
