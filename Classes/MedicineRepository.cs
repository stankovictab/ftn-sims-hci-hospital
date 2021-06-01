/***********************************************************************
 * Module:  MedicineRepository.cs
 * Author:  Igor
 * Purpose: Definition of the Class Controllers,Services&Repositories.MedicineRepository
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.IO;

namespace Classes
{
    public class MedicineRepository
    {
        private String FileLocationOnHold = "../../Text Files/onholdmedicine.txt";
        private String FileLocationUnverified = "../../Text Files/unverifiedmedicine.txt";
        public List<Medicine> UnverifiedMedicine = new List<Medicine>();
        public List<Medicine> OnHoldMedicine = new List<Medicine>();


        public static MedicineStatus ParseStatus(string input)
        {
            if (input == "Unverified")
                return MedicineStatus.Unverified;
            else if (input == "Verified")
                return MedicineStatus.Verified;

            return MedicineStatus.OnHold;
        }

        public Boolean CreateOnHold(Medicine newMedicine)
        {
            OnHoldMedicine = GetAllOnHold();
            OnHoldMedicine.Add(newMedicine);
            TextWriter tw = new StreamWriter(FileLocationOnHold);

            foreach (var item in OnHoldMedicine)
            {
                tw.WriteLine(string.Format("{0},{1},{2},{3},{4},{5},{6}", item.Id, item.Name, item.Description, item.Ingredients, item.Alternatives, item.Status.ToString(), item.DenialReason));
            }
            tw.Close();

            return true;
        }

        public Medicine GetOnHoldByName(string name)
        {
            OnHoldMedicine = GetAllOnHold();
            foreach (Medicine medicine in OnHoldMedicine)
            {
                if (medicine.Name.Equals(name))
                {
                    return medicine;
                }
            }
            return null;
        }

        public List<Medicine> GetAllOnHold()
        {
            List<Medicine> medicine = new List<Medicine>();
            TextReader tr = new StreamReader(FileLocationOnHold);
            string text = tr.ReadLine();
            while (text != null && text != "\n")
            {
                string[] components = text.Split(',');
                string id = components[0];
                string name = components[1];
                string description = components[2];
                string ingredients = components[3];
                string alternatives = components[4];
                MedicineStatus status = ParseStatus(components[5]);
                string denialReason = components[6];
                Medicine newMedicine = new Medicine(id, name, description, ingredients, alternatives, status, denialReason);
                medicine.Add(newMedicine);
                text = tr.ReadLine();
            }
            tr.Close();
            return medicine;
        }

        public Boolean UpdateOnHold(Medicine updateMedicine)
        {
            foreach (Medicine newMedicine in OnHoldMedicine)
            {
                if (newMedicine.Id.Equals(updateMedicine.Id))
                {
                    newMedicine.Name = updateMedicine.Name;
                    newMedicine.Description = updateMedicine.Description;
                    newMedicine.Ingredients = updateMedicine.Ingredients;
                    newMedicine.Alternatives = updateMedicine.Alternatives;
                    newMedicine.Status = updateMedicine.Status;
                    return true;
                }
            }
            return false;
        }

        public Boolean UpdateAllOnHold(List<Medicine> mif)
        {
            TextWriter tw = new StreamWriter(FileLocationOnHold);
            if (mif == null)
            {
                tw.Close();
                return false;
            }
            else
            {
                foreach (var item in mif)
                {
                    tw.WriteLine(string.Format("{0},{1},{2},{3},{4},{5},{6}", item.Id, item.Name, item.Description, item.Ingredients, item.Alternatives, item.Status.ToString(), item.DenialReason));
                }
                tw.Close();
                return true;
            }
        }

        public Boolean DeleteOnHold(string name)
        {
            OnHoldMedicine = GetAllOnHold();
            foreach (Medicine medicine in OnHoldMedicine)
            {
                if (medicine.Name.Equals(name))
                {
                    OnHoldMedicine.Remove(medicine);
                    return true;
                }
            }
            return false;
        }

        public List<Medicine> GetAllUnverified()
        {
            List<Medicine> medicine = new List<Medicine>();
            TextReader tr = new StreamReader(FileLocationUnverified);
            string text = tr.ReadLine();
            while (text != null && text != "\n")
            {
                string[] components = text.Split(',');
                string id = components[0];
                string name = components[1];
                string description = components[2];
                string ingredients = components[3];
                string alternatives = components[4];
                MedicineStatus status = ParseStatus(components[5]);
                string denialReason = components[6];
                Medicine newMedicine = new Medicine(id, name, description, ingredients, alternatives, status, denialReason);
                medicine.Add(newMedicine);
                text = tr.ReadLine();
            }
            tr.Close();
            return medicine;
        }

        public Medicine GetUnverifiedByName(string name)
        {
            UnverifiedMedicine = GetAllUnverified();
            foreach (Medicine medicine in UnverifiedMedicine)
            {
                if (medicine.Name.Equals(name))
                {
                    return medicine;
                }
            }
            return null;
        }

        public Boolean DeleteUnverified(string id)
        {
            UnverifiedMedicine = GetAllUnverified();
            foreach (Medicine medicine in UnverifiedMedicine)
            {
                if (medicine.Id.Equals(id))
                {
                    UnverifiedMedicine.Remove(medicine);
                    return true;
                }
            }
            return false;
        }

        public Boolean UpdateAllUnverified(List<Medicine> mif)
        {
            TextWriter tw = new StreamWriter(FileLocationUnverified);
            if (mif == null)
            {
                tw.Close();
                return false;
            }
            else
            {
                foreach (var item in mif)
                {
                    tw.WriteLine(string.Format("{0},{1},{2},{3},{4},{5},{6}", item.Id, item.Name, item.Description, item.Ingredients, item.Alternatives, item.Status.ToString(), item.DenialReason));
                }
                tw.Close();
                return true;
            }
        }
    }
}