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
        public List<BasicRenovation> BasicRenovations = new List<BasicRenovation>();
        public RoomRepository roomRepository = new RoomRepository();

        public void WriteToFile(List<BasicRenovation> basicRenovations)
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

        public Boolean Create(BasicRenovation newBasicRenovation)
        {
            BasicRenovations = GetAll();
            BasicRenovations.Add(newBasicRenovation);
            WriteToFile(BasicRenovations);

            //zauzimanje sobe
            newBasicRenovation.Room.Status = RoomStatus.Renovating;
            roomRepository.Update(newBasicRenovation.Room);
            roomRepository.UpdateFile(roomRepository.Rooms);

            ScheduleTask(newBasicRenovation);
            
            return true;
        }

        public List<BasicRenovation> PullFromFile()
        {
            List<BasicRenovation> basicRenovations = new List<BasicRenovation>();
            TextReader tr = new StreamReader(FileLocation);
            string text = tr.ReadLine();
            while (text != null && text != "\n")
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

            basicRenovations = PullFromFile();

            return basicRenovations;
        }

        public Boolean UpdateFile(List<BasicRenovation> renovations)
        {
            if (renovations == null)
            {
                return false;
            }
            else
            {
                WriteToFile(renovations);
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
                    BasicRenovations.Remove(renovation);
                    return true;
                }
            }
            return false;
        }
    }
}
