using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public interface IAllergiesRepository
    {
        List<Allergy> AllergiesInFile { get; set; }

        Boolean Create(Allergy a);
        Allergy GetByID(int id);
        List<Allergy> GetAll();
        Boolean Update(Allergy a);
        Boolean UpdateAll(List<Allergy> allergiesInFile);
        Boolean Delete(int id);
    }
}
