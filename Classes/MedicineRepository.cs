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
        private String FileLocation = "../../Text Files/unverifiedmedicine.txt";
        public List<Medicine> UnverifiedMedicine = new List<Medicine>();


        public static MedicineStatus ParseStatus(string input)
        {
            if (input == "Unverified")
                return MedicineStatus.Unverified;
            else if (input == "Verified")
                return MedicineStatus.Verified;

            return MedicineStatus.Unverified;
        }

        public Boolean CreateUnverified(Medicine newMedicine)
        {
            UnverifiedMedicine = GetAllUnverified();
            UnverifiedMedicine.Add(newMedicine);
            TextWriter tw = new StreamWriter(FileLocation);

            foreach (var item in UnverifiedMedicine)
            {
                tw.WriteLine(string.Format("{0},{1},{2},{3},{4}", item.Name, item.Description, item.Ingredients, item.Alternatives, item.Status.ToString()));
            }
            tw.Close();

            return true;
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

        public List<Medicine> GetAllUnverified()
        {
            List<Medicine> medicine = new List<Medicine>();
            TextReader tr = new StreamReader(FileLocation);
            string text = tr.ReadLine();
            while (text != null && text != "\n")
            {
                string[] components = text.Split(',');
                string name = components[0];
                string description = components[1];
                string ingredients = components[2];
                string alternatives = components[3];
                MedicineStatus status = ParseStatus(components[4]);
                Medicine newMedicine = new Medicine(name, description, ingredients, alternatives, status);
                medicine.Add(newMedicine);
                text = tr.ReadLine();
            }
            tr.Close();
            return medicine;
        }

        public Boolean UpdateUnverified(Medicine updateMedicine)
        {
            foreach (Medicine newMedicine in UnverifiedMedicine)
            {
                if (newMedicine.Name.Equals(updateMedicine.Name))
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

        public Boolean UpdateAllUnverified(List<Medicine> mif)
        {
            TextWriter tw = new StreamWriter(FileLocation);
            if (mif == null)
            {
                tw.Close();
                return false;

            }
            else
            {
                foreach (var item in mif)
                {
                    tw.WriteLine(string.Format("{0},{1},{2},{3},{4}", item.Name, item.Description, item.Ingredients, item.Alternatives, item.Status.ToString()));
                }
                tw.Close();
                return true;
            }
        }

        public Boolean DeleteUnverified(string name)
        {
            foreach (Medicine medicine in UnverifiedMedicine)
            {
                if (medicine.Name.Equals(name))
                {
                    UnverifiedMedicine.Remove(medicine);
                    return true;
                }
            }
            return false;
        }

    }
}