/***********************************************************************
 * Module:  ManagerService.cs
 * Author:  Igor
 * Purpose: Definition of the Class Manager.ManagerService
 ***********************************************************************/

using ASquare.WindowsTaskScheduler;
using ASquare.WindowsTaskScheduler.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Classes
{
    public class EnschedulementRepository
    {
        private String FileLocation = "../../Text Files/enschedulements.txt";
        private String FileLocationTasks = "../../Text Files/enschedulementtasks.txt";
        public List<StaticEnschedulement> Enschedulements = new List<StaticEnschedulement>();
        public RoomRepository roomRepository = new RoomRepository();
        public StaticEquipmentRepository staticEquipmentRepository = new StaticEquipmentRepository();

        public void WriteToFile(List<StaticEnschedulement> enschedulements)
        {
            TextWriter tw = new StreamWriter(FileLocation);

            foreach (var item in enschedulements)
            {
                tw.WriteLine(string.Format("{0},{1},{2},{3}", item.Time.ToString(), item.FromRoom.RoomNumber, item.ToRoom.RoomNumber, item.MovedEquipment.statName));
            }
            tw.Close();
        }

        public void ScheduleTask(StaticEnschedulement newEnschedulement)
        {
            SchedulerResponse response = WindowTaskScheduler
                .Configure()
                .CreateTask(newEnschedulement.IdEnsch.ToString(), FileLocationTasks)
                .RunMonthly()
                .SetMonthsToRun(1)
                .RunDurationFor(new TimeSpan(0, 10, 0))
                .SetStartDate(newEnschedulement.Time.Date)
                .SetStartTime(newEnschedulement.Time.TimeOfDay)
                .Execute();
        }

        public Boolean Create(StaticEnschedulement newEnschedulement)
        {
            Enschedulements = GetAll();
            Enschedulements.Add(newEnschedulement);
            TextWriter tw = new StreamWriter(FileLocation);

            WriteToFile(Enschedulements);

            ScheduleTask(newEnschedulement);

            return true;
        }

        public List<StaticEnschedulement> PullFromFile()
        {
            List<StaticEnschedulement> staticEnschedulements = new List<StaticEnschedulement>();
            TextReader tr = new StreamReader(FileLocation);
            string text = tr.ReadLine();
            while (text != null && text != "\n")
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
            staticEnschedulements = PullFromFile();
            return staticEnschedulements;
        }
    }
}