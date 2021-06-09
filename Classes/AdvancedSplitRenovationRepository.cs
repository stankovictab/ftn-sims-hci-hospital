/***********************************************************************
 * Module:  AdvancedSplitRenovationRepository.cs
 * Author:  Igor
 * Purpose: Definition of the Class Controllers,Services&Repositories.AdvancedSplitRenovationRepository
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.IO;

namespace Classes
{
    public class AdvancedSplitRenovationRepository : IAdvancedSplitRenovationRepository
    {
        private string FileLocationSplit = "../../Text Files/splitrenovations.txt";
        private string FileLocationSplitFinished = "../../Text Files/finishedsplitrenovations.txt";
        public List<SplitRenovation> SplitRenovations { get; set; } = new List<SplitRenovation>();
        public List<SplitRenovation> FinishedSplitRenovations { get; set; } = new List<SplitRenovation>();
        RoomRepository roomRepository = new RoomRepository();
        StaticEquipmentRepository staticEquipmentRepository = new StaticEquipmentRepository();



        public List<SplitRenovation> PullFromFile(String FileLocation)
        {
            List<SplitRenovation> splitRenovations = new List<SplitRenovation>();
            TextReader tr = new StreamReader(FileLocation);
            string text = tr.ReadLine();
            while (text != null && text != "\n" && text != "")
            {
                string[] components = text.Split(',');
                int id = Convert.ToInt32(components[0]);
                DateTime startTime = Convert.ToDateTime(components[1]);
                DateTime endTime = Convert.ToDateTime(components[2]);
                Room oldRoom = roomRepository.GetByNumber(components[3]);
                Room newRoom1 = roomRepository.GetByNumber(components[4]);
                Room newRoom2 = roomRepository.GetByNumber(components[5]);

                SplitRenovation newSplitRenovation = new SplitRenovation(id, startTime, endTime, oldRoom, newRoom1, newRoom2);
                splitRenovations.Add(newSplitRenovation);
                text = tr.ReadLine();
            }
            tr.Close();
            return splitRenovations;
        }

        public void WriteToFile(List<SplitRenovation> splitRenovations, String FileLocation)
        { 
            TextWriter tw = new StreamWriter(FileLocation);

            foreach (var item in splitRenovations)
            {
                tw.WriteLine(string.Format("{0},{1},{2},{3},{4},{5}", item.Id, item.StartTime.ToString(), item.EndTime.ToString(), item.OldRoom.RoomNumber, item.NewRoom1.RoomNumber, item.NewRoom2.RoomNumber));
            }
            tw.Close();
        }

        public List<SplitRenovation> GetAllSplit()
        { 
            List<SplitRenovation> splitRenovations = new List<SplitRenovation>();

            splitRenovations = PullFromFile(FileLocationSplit);

            return splitRenovations;
        }

        public List<SplitRenovation> GetAllSplitFinished()
        { 
            List<SplitRenovation> splitRenovations = new List<SplitRenovation>();

            splitRenovations = PullFromFile(FileLocationSplitFinished);

            return splitRenovations;
        }

        public Boolean Create(SplitRenovation newSplitRenovation)
        { 
            SplitRenovations = GetAllSplit();
            SplitRenovations.Add(newSplitRenovation);
            WriteToFile(SplitRenovations, FileLocationSplit);

            //zauzimanje sobe
            roomRepository.Reorder(newSplitRenovation.OldRoom);

            return true;
        }

        public Boolean Delete(int id)
        { 
            SplitRenovations = GetAllSplit();
            foreach (SplitRenovation renovation in SplitRenovations)
            {
                if (renovation.Id == id)
                {
                    roomRepository.Free(renovation.OldRoom);
                    SplitRenovations.Remove(renovation);
                    WriteToFile(SplitRenovations, FileLocationSplit);

                    return true;
                }
            }
            return false;
        }

        public Boolean UpdateFile(List<SplitRenovation> splitRenovations)
        { 
            if (splitRenovations == null)
            {
                return false;
            }
            else
            {
                WriteToFile(splitRenovations, FileLocationSplit);
                return true;
            }
        }

        public void UpdateTime(DateTime currentTime)
        { 
            SplitRenovations = GetAllSplit();
            FinishedSplitRenovations = GetAllSplitFinished();
            List<StaticEquipment> staticEquipment = staticEquipmentRepository.GetAll();

            foreach (SplitRenovation renovation in SplitRenovations)
            {
                if (DateTime.Compare(currentTime, renovation.StartTime) >= 0 && DateTime.Compare(currentTime, renovation.EndTime) <= 0)
                {
                    Room oldRoom = roomRepository.GetByNumber(renovation.OldRoom.RoomNumber);
                    oldRoom.Status = RoomStatus.Reordering;
                    roomRepository.Update(oldRoom);
                    roomRepository.UpdateFile(roomRepository.Rooms);
                }
                else if (DateTime.Compare(currentTime, renovation.EndTime) > 0)
                {
                    //oslobadjanje soba koja se napravila
                    roomRepository.Free(renovation.NewRoom1);
                    roomRepository.Free(renovation.NewRoom2);

                    //brisanje stare sobe
                    roomRepository.Delete(renovation.OldRoom.RoomNumber);
                    roomRepository.UpdateFile(roomRepository.Rooms);

                    //azuriranje lokacija staticke opreme
                    foreach (StaticEquipment oneStatic in staticEquipment)
                    {
                        if (oneStatic.statLocation == renovation.OldRoom.RoomNumber)
                            if(Convert.ToInt32(oneStatic.statId) % 2 == 0)
                                oneStatic.statLocation = renovation.NewRoom1.RoomNumber;
                            else
                                oneStatic.statLocation = renovation.NewRoom2.RoomNumber;
                    }
                    staticEquipmentRepository.UpdateAll(staticEquipment);

                    SplitRenovations.Remove(renovation);
                    WriteToFile(SplitRenovations, FileLocationSplit);

                    FinishedSplitRenovations.Add(renovation);
                    WriteToFile(FinishedSplitRenovations, FileLocationSplitFinished);
                }
            }
        }
    }
}