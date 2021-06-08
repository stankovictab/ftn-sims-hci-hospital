using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class IMedicineRepository
    {
        public MedicineRepository medicineRepository;
        public IMedicineRepository(MedicineRepository repo)
        {
            this.medicineRepository = repo;
        }

        public List<Medicine> AccessOnHoldMedicine { get => medicineRepository.OnHoldMedicine; set => medicineRepository.OnHoldMedicine = value; }
        public List<Medicine> AccessUnverifiedMedicine { get => medicineRepository.UnverifiedMedicine; set => medicineRepository.UnverifiedMedicine = value; }


        public Boolean CreateOnHold(Medicine newMedicine)
        {
            return this.medicineRepository.CreateOnHold(newMedicine);
        }

        public Medicine GetOnHoldByName(string name)
        {
            return this.medicineRepository.GetOnHoldByName(name);
        }

        public List<Medicine> GetAllOnHold()
        {
            return this.medicineRepository.GetAllOnHold();
        }

        public Boolean UpdateOnHold(Medicine updateMedicine)
        {
            return this.medicineRepository.UpdateOnHold(updateMedicine);
        }

        public Boolean UpdateAllOnHold(List<Medicine> mif)
        {
            return this.medicineRepository.UpdateAllOnHold(mif);
        }
        public Boolean DeleteOnHold(string name)
        {
            return this.medicineRepository.DeleteOnHold(name);
        }

        public List<Medicine> GetAllUnverified()
        {
            return this.medicineRepository.GetAllUnverified();
        }

        public Medicine GetUnverifiedByName(string name)
        {
            return this.medicineRepository.GetUnverifiedByName(name);
        }

        public Boolean DeleteUnverified(string id)
        {
            return this.medicineRepository.DeleteUnverified(id);
        }

        public Boolean UpdateAllUnverified(List<Medicine> mif)
        {
            return this.medicineRepository.UpdateAllUnverified(mif);
        }
    }
}
