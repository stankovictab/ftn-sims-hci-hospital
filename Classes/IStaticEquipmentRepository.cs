using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public interface IStaticEquipmentRepository
    {



        List<StaticEquipment> StaticEquipment { get; set; }

        StaticEquipment GetByName(string name);


        Boolean Create(StaticEquipment newStatic);


        bool Delete(int toDelete);


        StaticEquipment GetById(int id);


        List<StaticEquipment> GetAll();


        Boolean Update(StaticEquipment updateStatic);

        Boolean UpdateAll(List<StaticEquipment> sif);


        void DeleteByLocation(string location);
        
    }
}
