using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public interface IPatientRepository
    {
        List<Patient> PatientsInFile { get; set; }
        Boolean Create(Patient p);
        Patient GetByID(String id);

        List<Patient> GetAll();
        Boolean Update(Patient p);

        Boolean UpdateAll(List<Patient> pif);

        Boolean Delete(String id);

    }
}
