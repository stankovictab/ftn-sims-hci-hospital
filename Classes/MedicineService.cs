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

        public bool UpdateAllOnHold(List<Medicine> mif)
        {
            return medicineRepository.UpdateAllOnHold(mif);
        }

        public List<Medicine> GetAllOnHold()
        {
            return medicineRepository.GetAllOnHold();
        }

        public bool DeleteOnHold(string name)
        {
            return medicineRepository.DeleteOnHold(name);
        }

        public bool AddOnHold(Medicine medicine)
        {
            return medicineRepository.CreateOnHold(medicine);
        }

        public Medicine GetOnHoldByName(string name)
        {
            return medicineRepository.GetOnHoldByName(name);
        }

        public bool UpdateOnHold(Medicine medicine)
        {
            return medicineRepository.UpdateOnHold(medicine);
        }

        public List<Medicine> GetAllUnverified()
        {
            return medicineRepository.GetAllUnverified();
        }

        public Medicine GetUnverifiedByName(string name)
        {
            return medicineRepository.GetUnverifiedByName(name);
        }

        public bool DeleteUnverified(string id)
        {
            return medicineRepository.DeleteUnverified(id);
        }

        public bool UpdateAllUnverified(List<Medicine> mif)
        {
            return medicineRepository.UpdateAllUnverified(mif);
        }
    }
}