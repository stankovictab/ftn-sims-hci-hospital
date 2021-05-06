/***********************************************************************
 * Module:  ManagerService.cs
 * Author:  Igor
 * Purpose: Definition of the Class Manager.ManagerService
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace Classes
{
    public class DynamicEquipmentRepository
    {
        private String FileLocation = "../../Text Files/dynamicequipment.txt";
        public List<DynamicEquipment> DynamicEquipment = new List<DynamicEquipment>();

        public void WriteToFile(List<DynamicEquipment> dynamicInFile)
        {
            TextWriter tw = new StreamWriter(FileLocation);

            foreach (var item in dynamicInFile)
            {
                tw.WriteLine(string.Format("{0},{1},{2}", item.Id.ToString(), item.Name, item.Amount));
            }
            tw.Close();
        }

        public Boolean Create(DynamicEquipment newDynamic)
        {
            DynamicEquipment.Add(newDynamic);
            WriteToFile(DynamicEquipment);

            return true;
        }

        public DynamicEquipment GetById(int id)
        {
            DynamicEquipment = GetAll();
            foreach (DynamicEquipment dynamicEquipment in DynamicEquipment)
            {
                if (dynamicEquipment.Id.Equals(id))
                {
                    return dynamicEquipment;
                }
            }
            return null;
        }

        public DynamicEquipment GetByName(string name)
        {
            DynamicEquipment = GetAll();
            foreach (DynamicEquipment dynamicEquipment in DynamicEquipment)
            {
                if (dynamicEquipment.Name.Equals(name))
                {
                    return dynamicEquipment;
                }
            }
            return null;
        }

        public List<DynamicEquipment> PullFromFile()
        {
            List<DynamicEquipment> dynamicEquipment = new List<DynamicEquipment>();
            TextReader tr = new StreamReader(FileLocation);
            string text = tr.ReadLine();
            while (text != null && text != "\n")
            {
                string[] components = text.Split(',');
                int dynamicId = Convert.ToInt32(components[0]);
                string dynamicName = components[1];
                string dynamicAmount = components[2];
                DynamicEquipment newDynamic = new DynamicEquipment(dynamicId, dynamicName, dynamicAmount);
                dynamicEquipment.Add(newDynamic);
                text = tr.ReadLine();
            }
            tr.Close();
            return dynamicEquipment;
        }

        public List<DynamicEquipment> GetAll()
        {
            List<DynamicEquipment> dynamicEquipment = new List<DynamicEquipment>();

            dynamicEquipment = PullFromFile();

            return dynamicEquipment;
        }

        public Boolean Update(DynamicEquipment updateDynamic)
        {
            DynamicEquipment = GetAll();
            foreach (DynamicEquipment d in DynamicEquipment)
            {
                if (updateDynamic.Id.Equals(d.Id))
                {
                    d.Id = updateDynamic.Id;
                    d.Name = updateDynamic.Name;
                    d.Amount = updateDynamic.Amount;
                    return true;
                }
            }
            return false;
        }

        public Boolean UpdateFile(List<DynamicEquipment> dynamicInFile)
        {
            if (dynamicInFile == null)
            {
                return false;
            }
            else
            {
                WriteToFile(dynamicInFile);
                return true;
            }
        }

        public Boolean Delete(int toDelete)
        {
            DynamicEquipment = GetAll();
            foreach (DynamicEquipment d in DynamicEquipment)
            {
                if (d.Id.Equals(toDelete))
                {
                    DynamicEquipment.Remove(d);
                    return true;
                }
            }
            return false;
        }

    }
}