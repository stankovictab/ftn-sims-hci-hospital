using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    class MedicineRepository
    {
        private String FileLocation;
        public MedicineRepository()
        {
            FileLocation = "../../Text Files/medicine.txt";
        }

        public Medicine Create(Medicine newMedicine)
        {
            string newLine = newMedicine.id + ";" + newMedicine.name + ";" + newMedicine.description + ";" + newMedicine.verified  + "\n";
            System.IO.File.AppendAllText(FileLocation, newLine);
            return newMedicine;
        }

        public Medicine GetById(String medicineId)
        {
            Medicine medicine;
            String[] rows = System.IO.File.ReadAllLines(FileLocation);

            foreach (String row in rows)
            {
                String[] data = row.Split(';');
                if (data[0].Equals(medicineId))
                {
                    String id = data[0];
                    String name = data[1];
                    String description = data[2];
                    Boolean verified = Boolean.Parse(data[3]);
                    medicine = new Medicine(id, name, description, verified);

                    return medicine;
                }
            }
            return null;
        }

        public List<Medicine> GetAll()
        {
            List<Medicine> allMedicines = new List<Medicine>();
            String[] rows = System.IO.File.ReadAllLines(FileLocation);

            foreach (String row in rows)
            {
                String[] data = row.Split(';');
                String id = data[0];
                String name = data[1];
                String description = data[2];
                Boolean verified = Boolean.Parse(data[3]);

                Medicine newMedicine = new Medicine(id,name,description,verified);

                allMedicines.Add(newMedicine);
            }
            return allMedicines;
        }

        public Boolean Delete(String id)
        {
            String[] rows = System.IO.File.ReadAllLines(FileLocation);
            List<Medicine> medicines = new List<Medicine>();
            List<String> newList = new List<string>();
            foreach (String row in rows)
            {
                String[] data = row.Split(';');
                if (!data[0].Equals(id))
                {
                    String r = String.Join(";", data);
                    newList.Add(r);
                }
            }
            System.IO.File.WriteAllLines(FileLocation, newList);
            return true;
        }

        
        
        public Medicine Update(Medicine medicine)
        {
            if (Delete(medicine.id))
            {
                Create(medicine);
                return medicine;
            }

            return medicine;
        }
    }
}
