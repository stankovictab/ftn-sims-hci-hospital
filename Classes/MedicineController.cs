/***********************************************************************
 * Module:  MedicineController.cs
 * Author:  Igor
 * Purpose: Definition of the Class Controllers,Services&Repositories.MedicineController
 ***********************************************************************/

using System;
using System.Collections.Generic;

namespace Classes
{
    public class MedicineController
    {
        public static MedicineRepository repo = new MedicineRepository();
        public MedicineService medicineService = new MedicineService(repo);

        public bool UpdateAllOnHold(List<Medicine> mif)
        {
            return medicineService.UpdateAllOnHold(mif);
        }

        public List<Medicine> GetAllOnHold()
        {
            return medicineService.GetAllOnHold();
        }

        public bool DeleteOnHold(string name)
        {
            return medicineService.DeleteOnHold(name);
        }

        public bool AddOnHold(Medicine medicine)
        {
            return medicineService.AddOnHold(medicine);
        }

        public Medicine GetOnHoldByName(string name)
        {
            return medicineService.GetOnHoldByName(name);
        }

        public bool UpdateOnHold(Medicine medicine)
        {
            return medicineService.UpdateOnHold(medicine);
        }

        public List<Medicine> GetAllUnverified()
        {
            return medicineService.GetAllUnverified();
        }

        public Medicine GetUnverifiedByName(string name)
        {
            return medicineService.GetUnverifiedByName(name);
        }

        public bool DeleteUnverified(string id)
        {
            return medicineService.DeleteUnverified(id);
        }

        public bool UpdateAllUnverified(List<Medicine> mif)
        {
            return medicineService.UpdateAllUnverified(mif);
        }

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