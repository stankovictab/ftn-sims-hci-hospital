using System;
using System.Collections.Generic;
using System.IO;

namespace Classes
{
    public class AllergiesRepository : IAllergiesRepository
    {
        private String FileLocation;

        public List<Allergy> AllergiesInFile { get; set; }
        public AllergiesRepository()
        {
            FileLocation = "../../Text Files/allergies.txt";
        }
        public Boolean Create(Allergy a)
        {

            AllergiesInFile = GetAll();
            if (AllergiesInFile.Contains(a))
            {
                return false;
            }
            else
            {
                AllergiesInFile.Add(a);
                UpdateAll(AllergiesInFile);
                return true;
            }
        }

        public Allergy GetByID(int id)
        {
            AllergiesInFile = GetAll();
            foreach (Allergy allergy in AllergiesInFile)
            {
                if (allergy.Id1==id)
                {
                    return allergy;
                }
            }
            return null;
        }

        public List<Allergy> GetAll()
        {
            List<Allergy> allergies= new List<Allergy>();
            TextReader tr = new StreamReader(FileLocation);
            string text = tr.ReadLine();
            while (text != null && text != "\n")
            {
                string[] components = text.Split(',');
                int id = Convert.ToInt32(components[0]);
                string name = components[1];
                Allergy allergy = new Allergy(name, id);
                allergies.Add(allergy);
                text = tr.ReadLine();
            }
            tr.Close();
            return allergies;
        }

        public Boolean Update(Allergy a)
        {
            AllergiesInFile = GetAll();
            foreach (Allergy allergy in AllergiesInFile)
            {
                if (allergy.Id1==a.Id1)
                {
                    allergy.Name1 = a.Name1;
                    UpdateAll(AllergiesInFile);
                    return true;
                }
            }
            return false;
        }

        public Boolean UpdateAll(List<Allergy> allergiesInFile)
        {
            TextWriter tw = new StreamWriter(FileLocation);
            if (allergiesInFile == null)
            {
                tw.Close();
                return false;

            }
            else
            {
                foreach (Allergy a in allergiesInFile)
                {
                    tw.WriteLine(a.Id1.ToString()+","+a.Name1);
                }
                tw.Close();
                return true;
            }
        }

        public Boolean Delete(int id)
        {
            AllergiesInFile = GetAll();
            foreach (Allergy allergy in AllergiesInFile)
            {
                if (allergy.Id1==id)
                {
                    AllergiesInFile.Remove(allergy);
                    UpdateAll(AllergiesInFile);
                    return true;
                }
            }
            return false;
        }
    }
}