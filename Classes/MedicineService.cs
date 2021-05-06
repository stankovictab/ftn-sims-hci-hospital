/***********************************************************************
 * Module:  MedicineService.cs
 * Author:  Igor
 * Purpose: Definition of the Class Controllers,Services&Repositories.MedicineService
 ***********************************************************************/

using System;
using System.Collections.Generic;

namespace Classes
{
    public class MedicineService
    {
        public MedicineRepository medicineRepository = new MedicineRepository();

        public bool UpdateAllUnverified(List<Medicine> mif)
        {
            return medicineRepository.UpdateAllUnverified(mif);
        }

        public List<Medicine> GetAllUnverified()
        {
            return medicineRepository.GetAllUnverified();
        }

        public bool DeleteUnverified(string name)
        {
            return medicineRepository.DeleteUnverified(name);
        }

        public bool AddUnverified(Medicine medicine)
        {
            return medicineRepository.CreateUnverified(medicine);
        }

        public Medicine GetUnverifiedByName(string name)
        {
            return medicineRepository.GetUnverifiedByName(name);
        }

        public bool UpdateUnverified(Medicine medicine)
        {
            return medicineRepository.UpdateUnverified(medicine);
        }
    }
}