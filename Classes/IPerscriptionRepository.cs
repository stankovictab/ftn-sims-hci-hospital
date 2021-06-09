using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public interface IPerscriptionRepository
    {
        Boolean Create(Perscription per, String patientId);
        Perscription GetByID(String id);
        List<Perscription> GetAllByPatientId(String id);
        List<Perscription> GetAll();
        Boolean Update(Perscription per, String patientId);
        Boolean UpdateAll(List<Perscription> perscriptionsInFile);
        Boolean Delete(String id);
    }
}
