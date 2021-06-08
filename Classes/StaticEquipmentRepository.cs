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
    public class StaticEquipmentRepository
    {
        private String FileLocation = "../../Text Files/staticequipment.txt";
        public List<StaticEquipment> StaticEquipment = new List<StaticEquipment>();


        public StaticEquipment GetByName(string name)
        { 
            StaticEquipment = GetAll();
            foreach (StaticEquipment s in StaticEquipment)
            {
                if (s.statName.Equals(name))
                {
                    return s;
                }
            }
            return null;
        }

        public List<StaticEquipment> GetByLocation(Room location)
        {
            StaticEquipment = GetAll();
            List<StaticEquipment> equipmentInRoom = new List<StaticEquipment>();
            foreach (StaticEquipment s in StaticEquipment)
            {
                if (s.statLocation.Equals(location.RoomNumber1))
                {
                    equipmentInRoom.Add(s);
                }
            }
            return equipmentInRoom;
        }

        public Boolean Create(StaticEquipment newStatic)
        { 
            StaticEquipment.Add(newStatic);
            TextWriter tw = new StreamWriter(FileLocation);

            foreach (var item in StaticEquipment)
            {
                tw.WriteLine(string.Format("{0},{1},{2}", item.statId.ToString(), item.statName, item.statLocation));
            }
            tw.Close();

            return true;
        }

        public bool Delete(int toDelete)
        { 
            StaticEquipment = GetAll();
            foreach (StaticEquipment s in StaticEquipment)
            {
                if (s.statId.Equals(toDelete))
                {

                    StaticEquipment.Remove(s);
                    return true;
                }
            }
            return false;
        }

        public StaticEquipment GetById(int id)
        { 
            StaticEquipment = GetAll();
            foreach (StaticEquipment s in StaticEquipment)
            {
                if (s.statId.Equals(id))
                {
                    return s;
                }
            }
            return null;
        }

        public List<StaticEquipment> GetAll()
        { 
            List<StaticEquipment> se = new List<StaticEquipment>();
            TextReader tr = new StreamReader(FileLocation);
            string text = tr.ReadLine();
            while (text != null && text != "\n")
            {
                string[] components = text.Split(',');
                int statId = Convert.ToInt32(components[0]);
                string statName = components[1];
                string statLocation = components[2];
                StaticEquipment newStat = new StaticEquipment(statId, statName, statLocation);
                se.Add(newStat);
                text = tr.ReadLine();
            }
            tr.Close();
            return se;
        }

        public Boolean Update(StaticEquipment updateStatic)
        { 
            
            foreach (StaticEquipment s in StaticEquipment)
            {
                if (updateStatic.statId.Equals(s.statId))
                {
                    s.statId = updateStatic.statId;
                    s.statName = updateStatic.statName;
                    return true;
                }
            }
            return false;
        }

        public Boolean UpdateAll(List<StaticEquipment> sif)
        { 
            TextWriter tw = new StreamWriter(FileLocation);
            if (sif == null)
            {
                tw.Close();
                return false;
            }
            else
            {
                foreach (var item in sif)
                {
                    tw.WriteLine(string.Format("{0},{1},{2}", item.statId.ToString(), item.statName, item.statLocation));
                }
                tw.Close();
                return true;
            }
        }

        public void DeleteByLocation(string location)
        { 
            foreach(StaticEquipment staticEquipment in StaticEquipment)
            {
                if (staticEquipment.statLocation.Equals(location))
                {
                    StaticEquipment.Remove(staticEquipment);
                    UpdateAll(StaticEquipment);
                }
            }
        }

    }
}