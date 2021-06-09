using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public interface IDynamicEquipmentRepository
    {


        List<DynamicEquipment> DynamicEquipment { get; set; }
        Boolean Create(DynamicEquipment newDynamic);


        DynamicEquipment GetById(int id);


        DynamicEquipment GetByName(string name);


        List<DynamicEquipment> GetAll();


        Boolean Update(DynamicEquipment updateDynamic);


        Boolean UpdateFile(List<DynamicEquipment> dynamicInFile);


        Boolean Delete(int toDelete);

    }
}
