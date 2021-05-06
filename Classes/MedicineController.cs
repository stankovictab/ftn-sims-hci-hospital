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
        public MedicineService medicineService = new MedicineService();

        public bool UpdateAllUnverified(List<Medicine> mif)
        {
            return medicineService.UpdateAllUnverified(mif);
        }

        public List<Medicine> GetAllUnverified()
        {
            return medicineService.GetAllUnverified();
        }

        public bool DeleteUnverified(string name)
        {
            return medicineService.DeleteUnverified(name);
        }

        public bool AddUnverified(Medicine medicine)
        {
            return medicineService.AddUnverified(medicine);
        }

        public Medicine GetUnverifiedByName(string name)
        {
            return medicineService.GetUnverifiedByName(name);
        }

        public bool UpdateUnverified(Medicine medicine)
        {
            return medicineService.UpdateUnverified(medicine);
        }
    }
}