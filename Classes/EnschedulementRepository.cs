/***********************************************************************
 * Module:  ManagerService.cs
 * Author:  Igor
 * Purpose: Definition of the Class Manager.ManagerService
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.IO;

namespace Classes
{
    public class EnschedulementRepository
    {
        private String FileLocation = "../../Text Files/enschedulements.txt";
        public List<StaticEnschedulement> EnschedulementsInFile = new List<StaticEnschedulement>();
        public RoomRepository roomRepository = new RoomRepository();
        public StaticEquipmentRepository staticEquipmentRepository = new StaticEquipmentRepository();

        public Boolean Create(StaticEnschedulement newEnschedulement)
        {
            EnschedulementsInFile = GetAll();
            EnschedulementsInFile.Add(newEnschedulement);
            TextWriter tw = new StreamWriter(FileLocation);

            foreach (var item in EnschedulementsInFile)
            {
                tw.WriteLine(string.Format("{0},{1},{2},{3}", item.Time.ToString(), item.FromRoom.RoomNumber, item.ToRoom.RoomNumber, item.MovedEquipment.statName));
            }
            tw.Close();

            return true;
        }

        public StaticEnschedulement GetById(int id)
        {
            // TODO: implement
            return null;
        }

        public List<StaticEnschedulement> GetAll()
        {
            //hard code-ovan id na 1
            List<StaticEnschedulement> se = new List<StaticEnschedulement>();
            TextReader tr = new StreamReader(FileLocation);
            string text = tr.ReadLine();
            while (text != null && text != "\n")
            {
                string[] components = text.Split(',');
                DateTime time = Convert.ToDateTime(components[0]);
                Room fromRoom = roomRepository.GetById(components[1]);
                Room toRoom = roomRepository.GetById(components[2]);
                StaticEquipment equipment = staticEquipmentRepository.GetByName(components[3]);
                StaticEnschedulement newEnschedulement = new StaticEnschedulement(time, fromRoom, toRoom, equipment, 1);
                se.Add(newEnschedulement);
                text = tr.ReadLine();
            }
            tr.Close();
            return se;
        }

        public Boolean Update(StaticEnschedulement updateEnsch)
        {
            // TODO: implement
            return false;
        }

        public Boolean UpdateAll(List<StaticEnschedulement> eif)
        {
            // TODO: implement
            return false;
        }

        public Boolean Delete(int id)
        {
            // TODO: implement
            return false;
        }

    }
}