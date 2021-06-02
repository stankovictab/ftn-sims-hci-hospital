/***********************************************************************
 * Module:  AdvancedRenovationRepository.cs
 * Author:  Igor
 * Purpose: Definition of the Class Controllers,Services&Repositories.AdvancedRenovationRepository
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.IO;

namespace Classes
{
    public class AdvancedMergeRenovationRepository
    {
        private string FileLocationMerge = "../../Text Files/mergerenovations.txt";
        private string FileLocationMergeFinished = "../../Text Files/finishedmergerenovations.txt";
        public List<MergeRenovation> MergeRenovations = new List<MergeRenovation>();
        public List<MergeRenovation> FinishedMergeRenovations = new List<MergeRenovation>();
        RoomRepository roomRepository = new RoomRepository();
        StaticEquipmentRepository staticEquipmentRepository = new StaticEquipmentRepository();

        public List<MergeRenovation> PullFromFile(String FileLocation)
        { 
            List<MergeRenovation> mergeRenovations = new List<MergeRenovation>();
            TextReader tr = new StreamReader(FileLocation);
            string text = tr.ReadLine();
            while (text != null && text != "\n" && text != "")
            {
                string[] components = text.Split(',');
                int id = Convert.ToInt32(components[0]);
                DateTime startTime = Convert.ToDateTime(components[1]);
                DateTime endTime = Convert.ToDateTime(components[2]);
                Room oldRoom1 = roomRepository.GetByNumber(components[3]);
                Room oldRoom2 = roomRepository.GetByNumber(components[4]);
                Room newRoom = roomRepository.GetByNumber(components[5]);

                MergeRenovation newMergeRenovation = new MergeRenovation(id, startTime, endTime, oldRoom1, oldRoom2, newRoom);
                mergeRenovations.Add(newMergeRenovation);
                text = tr.ReadLine();
            }
            tr.Close();
            return mergeRenovations;
        }

        public void WriteToFile(List<MergeRenovation> mergeRenovations, String FileLocation)
        { 
            TextWriter tw = new StreamWriter(FileLocation);

            foreach (var item in mergeRenovations)
            {
                tw.WriteLine(string.Format("{0},{1},{2},{3},{4},{5}", item.Id, item.StartTime.ToString(), item.EndTime.ToString(), item.OldRoom1.RoomNumber, item.OldRoom2.RoomNumber, item.NewRoom.RoomNumber));
            }
            tw.Close();
        }

        public List<MergeRenovation> GetAllMerge()
        {
            List<MergeRenovation> mergeRenovations = new List<MergeRenovation>();

            mergeRenovations = PullFromFile(FileLocationMerge);

            return mergeRenovations;
        }

        public List<MergeRenovation> GetAllMergeFinished()
        {
            List<MergeRenovation> mergeRenovations = new List<MergeRenovation>();

            mergeRenovations = PullFromFile(FileLocationMergeFinished);

            return mergeRenovations;
        }

        public Boolean Create(MergeRenovation newMergeRenovation)
        { 
            MergeRenovations = GetAllMerge();
            MergeRenovations.Add(newMergeRenovation);
            WriteToFile(MergeRenovations, FileLocationMerge);

            //zauzimanje soba
            roomRepository.Reorder(newMergeRenovation.OldRoom1);
            roomRepository.Reorder(newMergeRenovation.OldRoom2);

            return true;
        }

        public Boolean Delete(int id)
        { 
            MergeRenovations = GetAllMerge();
            foreach (MergeRenovation renovation in MergeRenovations)
            {
                if (renovation.Id == id)
                {
                    roomRepository.Free(renovation.OldRoom1);
                    roomRepository.Free(renovation.OldRoom2);
                    MergeRenovations.Remove(renovation);
                    WriteToFile(MergeRenovations, FileLocationMerge);

                    return true;
                }
            }
            return false;
        }

        public Boolean UpdateFile(List<MergeRenovation> mergeRenovations)
        { 
            if (mergeRenovations == null)
            {
                return false;
            }
            else
            {
                WriteToFile(mergeRenovations, FileLocationMerge);
                return true;
            }
        }

        public void UpdateTime(DateTime currentTime)
        {
            MergeRenovations = GetAllMerge();
            FinishedMergeRenovations = GetAllMergeFinished();
            List<StaticEquipment> staticEquipment = staticEquipmentRepository.GetAll();

            foreach (MergeRenovation renovation in MergeRenovations)
            {
                if(DateTime.Compare(currentTime, renovation.StartTime) >= 0 && DateTime.Compare(currentTime, renovation.EndTime) <= 0)
                {
                    roomRepository.Reorder(renovation.OldRoom1);
                    roomRepository.Reorder(renovation.OldRoom2);
                }
                else if (DateTime.Compare(currentTime, renovation.EndTime) > 0)
                {
                    //oslobadjanje sobe koja se napravila
                    roomRepository.Free(renovation.NewRoom);
                    
                    //brisanje starih soba
                    roomRepository.Delete(renovation.OldRoom1.RoomNumber);
                    roomRepository.UpdateFile(roomRepository.Rooms);
                    roomRepository.Delete(renovation.OldRoom2.RoomNumber);
                    roomRepository.UpdateFile(roomRepository.Rooms);

                    //azuriranje lokacija staticke opreme
                    foreach (StaticEquipment oneStatic in staticEquipment)
                    {
                        if (oneStatic.statLocation == renovation.OldRoom1.RoomNumber || oneStatic.statLocation == renovation.OldRoom2.RoomNumber)
                            oneStatic.statLocation = renovation.NewRoom.RoomNumber;
                    }
                    staticEquipmentRepository.UpdateAll(staticEquipment);

                    MergeRenovations.Remove(renovation);
                    WriteToFile(MergeRenovations, FileLocationMerge);

                    FinishedMergeRenovations.Add(renovation);
                    WriteToFile(FinishedMergeRenovations, FileLocationMergeFinished);
                }
            }
        }
    }
}