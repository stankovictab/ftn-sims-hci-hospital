using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Classes
{
    class MedicineService
    {
        MedicineRepository medicineRepository = new MedicineRepository();

        public Medicine Create(Medicine newMedicine)
        {
            return medicineRepository.Create(newMedicine);
        }

        public Medicine GetByID(String id)
        {
            return medicineRepository.GetById(id);
        }

        public List<Medicine> GetAll()
        {
            return medicineRepository.GetAll();
        }

        public Medicine Update(Medicine changedMedicine)
        {
            return medicineRepository.Update(changedMedicine);
        }

        public Medicine Approve(Medicine medicineForApprove)
        {
            medicineForApprove.verified = true;
            return medicineRepository.Update(medicineForApprove);
            
        }

        public Medicine Decline(Medicine medicineForDecline)
        {
            medicineRepository.Delete(medicineForDecline.id);
            return medicineForDecline;
        }

   
    }
}
