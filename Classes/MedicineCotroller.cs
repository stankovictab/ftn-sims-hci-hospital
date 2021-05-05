﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    class MedicineCotroller
    {

        public MedicineService medicineService = new MedicineService();
        public Medicine Create(Medicine newMedicine)
        {
           return medicineService.Create(newMedicine);   
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
           return medicineService.Update(changedMedicine);
        }

        public Medicine Approve(Medicine medicineForApprove)
        {
            return medicineService.Approve(medicineForApprove);
        }

        public Medicine Decline(Medicine medicineForDecline)
        {
            return medicineService.Decline(medicineForDecline);
        }

    }
}