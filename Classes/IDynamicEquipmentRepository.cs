using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{ 
    public class IDynamicEquipmentRepository
    {
        DynamicEquipmentRepository dynamicEquipmentRepository;
        public IDynamicEquipmentRepository(DynamicEquipmentRepository repo)
        {
            this.dynamicEquipmentRepository = repo;
        }

        public List<DynamicEquipment> AccessDynamicEquipment { get => dynamicEquipmentRepository.DynamicEquipment; set => dynamicEquipmentRepository.DynamicEquipment = value; }

        public Boolean Create(DynamicEquipment newDynamic)
        {
            return this.dynamicEquipmentRepository.Create(newDynamic);
        }

        public DynamicEquipment GetById(int id)
        {
            return this.dynamicEquipmentRepository.GetById(id);
        }

        public DynamicEquipment GetByName(string name)
        {
            return this.dynamicEquipmentRepository.GetByName(name);
        }

        public List<DynamicEquipment> GetAll()
        {
            return this.dynamicEquipmentRepository.GetAll();
        }

        public Boolean Update(DynamicEquipment updateDynamic)
        {
            return this.dynamicEquipmentRepository.Update(updateDynamic);
        }

        public Boolean UpdateFile(List<DynamicEquipment> dynamicInFile)
        {
            return this.dynamicEquipmentRepository.UpdateFile(dynamicInFile);
        }

        public Boolean Delete(int toDelete)
        {
            return this.dynamicEquipmentRepository.Delete(toDelete);
        }
    }
}
