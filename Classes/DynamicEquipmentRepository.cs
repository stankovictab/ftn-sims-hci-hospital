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
        public List<DynamicEquipment> DynamicInFile = new List<DynamicEquipment>();

        public Boolean Create(DynamicEquipment newDynamic)
        {
            DynamicInFile.Add(newDynamic);
            TextWriter tw = new StreamWriter(FileLocation);

            foreach (var item in DynamicInFile)
            {
                tw.WriteLine(string.Format("{0},{1},{2}", item.dynamicId.ToString(), item.dynamicName, item.dynamicAmount));
            }
            tw.Close();

            return true;
        }

        public DynamicEquipment GetById(int id)
        {
            DynamicInFile = GetAll();
            foreach (DynamicEquipment d in DynamicInFile)
            {
                if (d.dynamicId.Equals(id))
                {
                    return d;
                }
            }
            return null;
        }

        public DynamicEquipment GetByName(string name)
        {
            DynamicInFile = GetAll();
            foreach (DynamicEquipment d in DynamicInFile)
            {
                if (d.dynamicName.Equals(name))
                {
                    return d;
                }
            }
            return null;
        }

        public List<DynamicEquipment> GetAll()
        {
            List<DynamicEquipment> de = new List<DynamicEquipment>();
            TextReader tr = new StreamReader(FileLocation);
            string text = tr.ReadLine();
            while (text != null && text != "\n")
            {
                string[] components = text.Split(',');
                int dynamicId = Convert.ToInt32(components[0]);
                string dynamicName = components[1];
                string dynamicAmount = components[2];
                DynamicEquipment newDynamic = new DynamicEquipment(dynamicId, dynamicName, dynamicAmount);
                de.Add(newDynamic);
                text = tr.ReadLine();
            }
            tr.Close();
            return de;
        }

        public Boolean Update(DynamicEquipment updateDynamic)
        {
            DynamicInFile = GetAll();
            foreach (DynamicEquipment d in DynamicInFile)
            {
                if (updateDynamic.dynamicId.Equals(d.dynamicId))
                {
                    d.dynamicId = updateDynamic.dynamicId;
                    d.dynamicName = updateDynamic.dynamicName;
                    d.dynamicAmount = updateDynamic.dynamicAmount;
                    return true;
                }
            }
            return false;
        }

        public Boolean UpdateAll(List<DynamicEquipment> dif)
        {
            TextWriter tw = new StreamWriter(FileLocation);
            if (dif == null)
            {
                tw.Close();
                return false;
            }
            else
            {
                foreach (var item in dif)
                {
                    tw.WriteLine(string.Format("{0},{1},{2}", item.dynamicId.ToString(), item.dynamicName, item.dynamicAmount));
                }
                tw.Close();
                return true;
            }
        }

        public Boolean Delete(int toDelete)
        {
            DynamicInFile = GetAll();
            foreach (DynamicEquipment d in DynamicInFile)
            {
                if (d.dynamicId.Equals(toDelete))
                {

                    DynamicInFile.Remove(d);
                    return true;
                }
            }
            return false;
        }

    }
}