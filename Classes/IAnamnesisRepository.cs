using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public interface IAnamnesisRepository
    {
        Boolean Create(Anamnesis a, String patientId);
        Anamnesis GetByID(String id);
        List<Anamnesis> GetAllByPatientId(String id);
        List<Anamnesis> GetAll();
        Boolean Update(Anamnesis a, String patientId);
        Boolean UpdateAll(List<Anamnesis> anamnesesInFile);
        Boolean Delete(String id);
    }
}
