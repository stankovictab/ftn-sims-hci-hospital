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
    public class EnschedulementRepository : IEnschedulementRepository
    {
        private String FileLocation = "../../Text Files/enschedulements.txt";
        private String FileLocationFinished = "../../Text Files/finishedenschedulements.txt";
        private String FileLocationTasks = "../../Text Files/enschedulementtasks.txt";
        public List<StaticEnschedulement> Enschedulements { get; set; } = new List<StaticEnschedulement>();
        public List<StaticEnschedulement> FinishedEnschedulements { get; set; } = new List<StaticEnschedulement>();
        public RoomRepository roomRepository = new RoomRepository();
        public StaticEquipmentRepository staticEquipmentRepository = new StaticEquipmentRepository();

        public void WriteToFile(List<StaticEnschedulement> enschedulements, String FileLocation)
        {
            TextWriter tw = new StreamWriter(FileLocation);

            foreach (var item in enschedulements)
            {
                tw.WriteLine(string.Format("{0},{1},{2},{3}", item.Time.ToString(), item.FromRoom.RoomNumber, item.ToRoom.RoomNumber, item.MovedEquipment.statName));
            }
            tw.Close();
        }

        public void UpdateTime(DateTime currentTime)
        { 
            Enschedulements = GetAll();
            List<StaticEnschedulement> enschedulementIterator = GetAll();
            FinishedEnschedulements = GetAllFinished();
            foreach(StaticEnschedulement enschedulement in Enschedulements)
            {
                if(DateTime.Compare(currentTime, enschedulement.Time) >= 0)
                {
                    Enschedulements.Remove(enschedulement);
                    WriteToFile(Enschedulements, FileLocation);

                    FinishedEnschedulements.Add(enschedulement);
                    WriteToFile(FinishedEnschedulements, FileLocationFinished);
                }
                enschedulementIterator = Enschedulements;
            }
        }


        public Boolean Create(StaticEnschedulement newEnschedulement)
        {
            Enschedulements = GetAll();
            Enschedulements.Add(newEnschedulement);

            WriteToFile(Enschedulements, FileLocation);

            return true;
        }

        public List<StaticEnschedulement> PullFromFile(String FileLocation)
        {
            List<StaticEnschedulement> staticEnschedulements = new List<StaticEnschedulement>();
            TextReader tr = new StreamReader(FileLocation);
            string text = tr.ReadLine();
            while (text != null && text != "\n" && text != "")
            {
                string[] components = text.Split(',');
                DateTime time = Convert.ToDateTime(components[0]);
                Room fromRoom = roomRepository.GetByNumber(components[1]);
                Room toRoom = roomRepository.GetByNumber(components[2]);
                StaticEquipment equipment = staticEquipmentRepository.GetByName(components[3]);
                StaticEnschedulement newEnschedulement = new StaticEnschedulement(time, fromRoom, toRoom, equipment, 1);
                staticEnschedulements.Add(newEnschedulement);
                text = tr.ReadLine();
            }
            tr.Close();
            return staticEnschedulements;
        }

        public List<StaticEnschedulement> GetAll()
        {
            List<StaticEnschedulement> staticEnschedulements = new List<StaticEnschedulement>();
            staticEnschedulements = PullFromFile(FileLocation);
            return staticEnschedulements;
        }

        public List<StaticEnschedulement> GetAllFinished()
        { 
            List<StaticEnschedulement> finishedEnschedulements = new List<StaticEnschedulement>();
            finishedEnschedulements = PullFromFile(FileLocationFinished);
            return finishedEnschedulements;
        }

        public Boolean Delete(StaticEnschedulement enschedulement)
        { 
            Enschedulements = GetAll();
            foreach (StaticEnschedulement se in Enschedulements)
            {
                if (se.IdEnsch.Equals(enschedulement.IdEnsch))
                {
                    Enschedulements.Remove(se);
                    WriteToFile(Enschedulements, FileLocation);
                    return true;
                }
            }
            return false;
        }
    }
}