/***********************************************************************
 * Module:  BasicRenovationRepository.cs
 * Author:  Igor
 * Purpose: Definition of the Class Controllers,Services&Repositories.BasicRenovationRepository
 ***********************************************************************/

using ASquare.WindowsTaskScheduler;
using ASquare.WindowsTaskScheduler.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Classes
{
    public class BasicRenovationRepository
    {
        private String FileLocation = "../../Text Files/basicrenovations.txt";
        private String FileLocationTasks = "../../Text Files/basicrenovationtasks.txt";
        private String FileLocationFinished = "../../Text Files/finishedbasicrenovations.txt";
        public List<BasicRenovation> BasicRenovations = new List<BasicRenovation>();
        public List<BasicRenovation> FinishedBasicRenovations = new List<BasicRenovation>();
        public RoomRepository roomRepository = new RoomRepository();

        public void WriteToFile(List<BasicRenovation> basicRenovations, String FileLocation)
        {
            TextWriter tw = new StreamWriter(FileLocation);

            foreach (var item in BasicRenovations)
            {
                tw.WriteLine(string.Format("{0},{1},{2},{3}", item.Id, item.Room.RoomNumber, item.DateTime.ToString(), item.Duration.ToString()));
            }
            tw.Close();
        }

        public void ScheduleTask(BasicRenovation newBasicRenovation)
        {
            SchedulerResponse response = WindowTaskScheduler
                .Configure()
                .CreateTask(newBasicRenovation.Id.ToString(), FileLocationTasks)
                .RunMonthly()
                .SetMonthsToRun(1)
                .RunDurationFor(new TimeSpan(0, newBasicRenovation.Duration, 0))
                .SetStartDate(newBasicRenovation.DateTime.Date)
                .SetStartTime(newBasicRenovation.DateTime.TimeOfDay)
                .SetEndDate(newBasicRenovation.DateTime.AddMinutes(newBasicRenovation.Duration))
                .Execute();
        }

        public void UpdateTime(DateTime currentTime)
        {
            BasicRenovations = GetAll();
            List<BasicRenovation> basicRenovationIterator = GetAll();
            FinishedBasicRenovations = GetAllFinished();
            foreach (BasicRenovation renovation in BasicRenovations)
            {
                if (DateTime.Compare(currentTime, renovation.DateTime.AddMinutes(renovation.Duration)) >= 0)
                {
                    BasicRenovations.Remove(renovation);
                    WriteToFile(BasicRenovations, FileLocation);

                    FinishedBasicRenovations.Add(renovation);
                    WriteToFile(FinishedBasicRenovations, FileLocationFinished);
                }
            }
        }

        public Boolean Create(BasicRenovation newBasicRenovation)
        {
            BasicRenovations = GetAll();
            BasicRenovations.Add(newBasicRenovation);
            WriteToFile(BasicRenovations, FileLocation);

            //zauzimanje sobe
            roomRepository.Renovate(newBasicRenovation.Room);

            ScheduleTask(newBasicRenovation);
            
            return true;
        }

        public List<BasicRenovation> PullFromFile(String FileLocation)
        {
            List<BasicRenovation> basicRenovations = new List<BasicRenovation>();
            TextReader tr = new StreamReader(FileLocation);
            string text = tr.ReadLine();
            while (text != null && text != "\n" && text != "")
            {
                string[] components = text.Split(',');
                int id = Convert.ToInt32(components[0]);
                Room room = roomRepository.GetByNumber(components[1]);
                DateTime dateTime = Convert.ToDateTime(components[2]);
                int duration = Convert.ToInt32(components[3]);

                BasicRenovation newBasicRenovation = new BasicRenovation(id, room, dateTime, duration);
                basicRenovations.Add(newBasicRenovation);
                text = tr.ReadLine();
            }
            tr.Close();
            return basicRenovations;
        }

        public List<BasicRenovation> GetAll()
        {
            List<BasicRenovation> basicRenovations = new List<BasicRenovation>();

            basicRenovations = PullFromFile(FileLocation);

            return basicRenovations;
        }

        public List<BasicRenovation> GetAllFinished()
        {
            List<BasicRenovation> finishedBasicRenovations = new List<BasicRenovation>();
            finishedBasicRenovations = PullFromFile(FileLocationFinished);
            return finishedBasicRenovations;
        }
        public Boolean UpdateFile(List<BasicRenovation> renovations)
        {
            if (renovations == null)
            {
                return false;
            }
            else
            {
                WriteToFile(renovations, FileLocation);
                return true;
            }
        }

        public Boolean Delete(int id)
        {
            BasicRenovations = GetAll();
            foreach (BasicRenovation renovation in BasicRenovations)
            {
                if (renovation.Id == id)
                {
                    renovation.Room.Status = RoomStatus.Free;
                    roomRepository.Update(renovation.Room);
                    roomRepository.UpdateFile(roomRepository.Rooms);
                    BasicRenovations.Remove(renovation);
                    WriteToFile(BasicRenovations, FileLocation);
                    
                    return true;
                }
            }
            return false;
        }
    }
}
