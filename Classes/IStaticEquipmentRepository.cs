using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class IStaticEquipmentRepository
    {
        StaticEquipmentRepository staticEquipmentRepository;

        public IStaticEquipmentRepository(StaticEquipmentRepository repo)
        {
            this.staticEquipmentRepository = repo;
        }

        public List<StaticEquipment> AccessStaticEquipment { get => staticEquipmentRepository.StaticEquipment; set => staticEquipmentRepository.StaticEquipment = value; }

        public StaticEquipment GetByName(string name)
        {
            return this.staticEquipmentRepository.GetByName(name);
        }

        public Boolean Create(StaticEquipment newStatic)
        {
            return this.staticEquipmentRepository.Create(newStatic);
        }

        public bool Delete(int toDelete)
        {
            return this.staticEquipmentRepository.Delete(toDelete);
        }

        public StaticEquipment GetById(int id)
        {
            return this.staticEquipmentRepository.GetById(id);
        }

        public List<StaticEquipment> GetAll()
        {
            return this.staticEquipmentRepository.GetAll();
        }

        public Boolean Update(StaticEquipment updateStatic)
        {
            return this.staticEquipmentRepository.Update(updateStatic);
        }

        public Boolean UpdateAll(List<StaticEquipment> sif)
        {
            return this.staticEquipmentRepository.UpdateAll(sif);
        }

        public void DeleteByLocation(string location)
        {
            this.staticEquipmentRepository.DeleteByLocation(location);
        }
    }
}
