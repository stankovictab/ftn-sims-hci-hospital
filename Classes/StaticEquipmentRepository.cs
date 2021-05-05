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
        public List<StaticEquipment> StaticInFile = new List<StaticEquipment>();
        

        public List<StaticEquipment> GetStaticByLocation()
        {
            // TODO: implement
            return null;
        }

        public StaticEquipment GetByName(string name)
        {
            StaticInFile = GetAll();
            foreach (StaticEquipment s in StaticInFile)
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
            StaticInFile = GetAll();
            List<StaticEquipment> equipmentInRoom = new List<StaticEquipment>();
            foreach (StaticEquipment s in StaticInFile)
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
            StaticInFile.Add(newStatic);
            TextWriter tw = new StreamWriter(FileLocation);

            foreach (var item in StaticInFile)
            {
                tw.WriteLine(string.Format("{0},{1},{2}", item.statId.ToString(), item.statName, item.statLocation));
            }
            tw.Close();

            return true;
        }

        public bool Delete(int toDelete)
        {
            StaticInFile = GetAll();
            foreach (StaticEquipment s in StaticInFile)
            {
                if (s.statId.Equals(toDelete))
                {
                    
                    StaticInFile.Remove(s);
                    return true;
                }
            }
            return false;
        }

        public StaticEquipment GetById(int id)
        {
            StaticInFile = GetAll();
            foreach (StaticEquipment s in StaticInFile)
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
            
            foreach (StaticEquipment s in StaticInFile)
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

    }
}