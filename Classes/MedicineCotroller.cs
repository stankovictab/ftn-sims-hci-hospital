﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    class MedicineCotroller
    {
        public static MedicineRepository repo = new MedicineRepository();
        public MedicineService medicineService = new MedicineService(repo);
        public Medicine Create(Medicine newMedicine)
        {
            // return medicineService.Create(newMedicine);
            return null;
        }

        public Medicine GetByID(String id)
        {
            return medicineService.GetByID(id);
        }

        public List<Medicine> GetAll()
        {
            return medicineService.GetAll();
        }

        public Medicine Update(Medicine changedMedicine)
        {
           //return medicineService.Update(changedMedicine);
           return null;
        }

        public Medicine Approve(Medicine medicineForApprove)
        {
            //return medicineService.Approve(medicineForApprove);
            return null;
        }

        public Medicine Decline(Medicine medicineForDecline)
        {
            //return medicineService.Decline(medicineForDecline);
            return null;
        }
    }
}