using System;
using System.Collections.Generic;
using System.IO;

namespace Classes
{
    public class MedicineRepository : IMedicineRepository
    {
        private String FileLocationOnHold = "C:/Users/Igor/Desktop/ftn-sims-hci-hospital-master/ftn-sims-hci-hospital-master/Text Files/onholdmedicine.txt";
        private String FileLocationUnverified = "C:/Users/Igor/Desktop/ftn-sims-hci-hospital-master/ftn-sims-hci-hospital-master/Text Files/unverifiedmedicine.txt";
        private String FIleLocationMedicine = "../../Text Files/medicine.txt";
        public List<Medicine> UnverifiedMedicine { get; set; } = new List<Medicine>();
        public List<Medicine> OnHoldMedicine { get; set; } = new List<Medicine>();


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
                    UpdateAllOnHold(OnHoldMedicine);
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
                    UnverifiedMedicine.Remove(medicine);
                    UpdateAllUnverified(UnverifiedMedicine);
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

        // medicine je samo ono sto je verifikovano
        public List<Medicine> GetAllMedicine()
        {
            List<Medicine> medicine = new List<Medicine>();
            TextReader tr = new StreamReader(FIleLocationMedicine);
            string text = tr.ReadLine();
            while (text != null && text != "\n")
            {
                string[] components = text.Split(';');
                Medicine newMedicine = readMedicne(components);
                medicine.Add(newMedicine);
                text = tr.ReadLine();
            }
            tr.Close();
            return medicine;
        }
        public Medicine GetById(String medicineId)
        {
            List<Medicine> medicines = GetAllMedicine();

            foreach (Medicine medicine in medicines)
            {
                if (medicine.Id == medicineId)
                    return medicine;
            }
            return null;
        }

        public Medicine readMedicne(String[] components)
        {

            string id = components[0];
            string name = components[1];
            string description = components[2];
            string ingredients = components[3];
            List<Allergy> allergies = readAllergies(ingredients);
            string alternatives = components[4];
            MedicineStatus status = ParseStatus(components[5]);
            string denialReason = components[6];
            Medicine newMedicine = new Medicine(id, name, description, ingredients, alternatives, status, denialReason, allergies);

            return newMedicine;
        }

        private List<Allergy> readAllergies(String ingredients)
        {
            List<Allergy> allergies = new List<Allergy>();
            String[] components = ingredients.Split(',');
            foreach(String component in components)
            {
                Allergy allergy = new Allergy(component);
                allergies.Add(allergy);
            }

            return allergies;
        }
    }
}