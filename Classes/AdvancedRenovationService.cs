/***********************************************************************
 * Module:  AdvancedRenovationService.cs
 * Author:  Igor
 * Purpose: Definition of the Class Controllers,Services&Repositories.AdvancedRenovationService
 ***********************************************************************/

using System;
using System.Collections.Generic;

namespace Classes
{
    public class AdvancedRenovationService
    {
        public IAdvancedMergeRenovationRepository advancedMergeRenovationRepository;
        public IAdvancedSplitRenovationRepository advancedSplitRenovationRepository;

        public AdvancedRenovationService(/*IAdvancedSplitRenovationRepository splitRepo, IAdvancedMergeRenovationRepository mergeRepo*/)
        {
            /*this.advancedSplitRenovationRepository = splitRepo;
            this.advancedMergeRenovationRepository = mergeRepo;*/
        }

        public List<MergeRenovation> GetAllMerge()
        {
            return advancedMergeRenovationRepository.GetAllMerge();
        }
        public List<SplitRenovation> GetAllSplit()
        {
            return advancedSplitRenovationRepository.GetAllSplit();
        }

        public bool CreateMerge(MergeRenovation newMergeRenovation)
        {
            if (!isAvailableMerge(newMergeRenovation))
                return false;

            return advancedMergeRenovationRepository.Create(newMergeRenovation);
        }

        public bool CreateSplit(SplitRenovation newSplitRenovation)
        {
            if (!isAvailableSplit(newSplitRenovation))
                return false;

            return advancedSplitRenovationRepository.Create(newSplitRenovation);
        }

        public bool isAvailableMerge(MergeRenovation toCheck)
        {
            List<MergeRenovation> mergeRenovations = advancedMergeRenovationRepository.GetAllMerge();

            foreach (MergeRenovation renovation in mergeRenovations)
            {
                bool available = checkDateTimeMerge(renovation, toCheck);
                if (!available)
                    return false;
            }
            return true;
        }

        public bool isAvailableSplit(SplitRenovation toCheck)
        {
            List<SplitRenovation> splitRenovations = advancedSplitRenovationRepository.GetAllSplit();

            foreach (SplitRenovation renovation in splitRenovations)
            {
                bool available = checkDateTimeSplit(renovation, toCheck);
                if (!available)
                    return false;
            }
            return true;
        }

        public bool checkDateTimeMerge(MergeRenovation renovation, MergeRenovation toCheck)
        {
            if (toCheck.OldRoom1.RoomNumber == renovation.OldRoom1.RoomNumber || toCheck.OldRoom2.RoomNumber == renovation.OldRoom2.RoomNumber || toCheck.OldRoom1.RoomNumber == renovation.OldRoom2.RoomNumber)
                if (toCheck.StartTime >= renovation.StartTime && toCheck.StartTime <= renovation.EndTime)
                    return false;
            return true;
        }

        public bool checkDateTimeSplit(SplitRenovation renovation, SplitRenovation toCheck)
        {
            if (toCheck.OldRoom.RoomNumber == renovation.OldRoom.RoomNumber || toCheck.NewRoom1.RoomNumber == renovation.NewRoom1.RoomNumber || toCheck.NewRoom2.RoomNumber == renovation.NewRoom2.RoomNumber)
                if (toCheck.StartTime >= renovation.StartTime && toCheck.StartTime <= renovation.EndTime)
                    return false;
            return true;
        }

        public bool DeleteMerge(int toDelete)
        {
            return advancedMergeRenovationRepository.Delete(toDelete);
        }

        public bool DeleteSplit(int toDelete)
        {
            return advancedSplitRenovationRepository.Delete(toDelete);
        }

        public bool UpdateFileMerge(List<MergeRenovation> mergeRenovationsInFile)
        {
            return advancedMergeRenovationRepository.UpdateFile(mergeRenovationsInFile);
        }

        public bool UpdateFileSplit(List<SplitRenovation> splitRenovationsInFile)
        {
            return advancedSplitRenovationRepository.UpdateFile(splitRenovationsInFile);
        }

        public void UpdateTimeMerge(DateTime currentTime)
        {
            advancedMergeRenovationRepository.UpdateTime(currentTime);
        }

        public void UpdateTimeSplit(DateTime currentTime)
        {
            advancedSplitRenovationRepository.UpdateTime(currentTime);
        }
    }
}