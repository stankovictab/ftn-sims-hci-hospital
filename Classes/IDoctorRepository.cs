using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public interface IDoctorRepository
    {
        List<Doctor> DoctorsInFile { get; set; }

        Boolean Create(Doctor d);

        Doctor GetByID(String id);

        List<Doctor> GetAll();

        Boolean Update(Doctor prosledjeni);

        Boolean UpdateFile();

        Boolean Delete(String id);
    }
}
