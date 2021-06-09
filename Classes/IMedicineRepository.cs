using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public interface IMedicineRepository
    {


        List<Medicine> OnHoldMedicine { get; set; }

        List<Medicine> UnverifiedMedicine { get; set; }


        Boolean CreateOnHold(Medicine newMedicine);


        Medicine GetOnHoldByName(string name);


        List<Medicine> GetAllOnHold();


        Boolean UpdateOnHold(Medicine updateMedicine);


        Boolean UpdateAllOnHold(List<Medicine> mif);

        Boolean DeleteOnHold(string name);


        List<Medicine> GetAllUnverified();


        Medicine GetUnverifiedByName(string name);


        Boolean DeleteUnverified(string id);


        Boolean UpdateAllUnverified(List<Medicine> mif);
        
    }
}
