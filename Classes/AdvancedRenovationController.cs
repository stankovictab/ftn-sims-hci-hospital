/***********************************************************************
 * Module:  AdvancedRenovationController.cs
 * Author:  Igor
 * Purpose: Definition of the Class Controllers,Services&Repositories.AdvancedRenovationController
 ***********************************************************************/

using System;
using System.Collections.Generic;

namespace Classes
{
    public class AdvancedRenovationController
    {
        public static AdvancedSplitRenovationRepository repo1 = new AdvancedSplitRenovationRepository();
        public static AdvancedMergeRenovationRepository repo2 = new AdvancedMergeRenovationRepository();
        public AdvancedRenovationService advancedRenovationService = new AdvancedRenovationService(repo1, repo2);

        public List<MergeRenovation> GetAllMerge()
        {
            return advancedRenovationService.GetAllMerge();
        }

        public List<SplitRenovation> GetAllSplit()
        {
            return advancedRenovationService.GetAllSplit();
        }

        public bool CreateMerge(MergeRenovation newMergeRenovation)
        {
            return advancedRenovationService.CreateMerge(newMergeRenovation);
        }

        public bool CreateSplit(SplitRenovation newSplitRenovation)
        {
            return advancedRenovationService.CreateSplit(newSplitRenovation);
        }

        public bool DeleteMerge(int toDelete)
        {
            return advancedRenovationService.DeleteMerge(toDelete);
        }

        public bool DeleteSplit(int toDelete)
        {
            return advancedRenovationService.DeleteSplit(toDelete);
        }

        public bool UpdateFileSplit(List<SplitRenovation> splitRenovationsInFile)
        {
            return advancedRenovationService.UpdateFileSplit (splitRenovationsInFile);
        }

        public bool UpdateFileMerge(List<MergeRenovation> mergeRenovationsInFile)
        {
            return advancedRenovationService.UpdateFileMerge(mergeRenovationsInFile);
        }

        public void UpdateTimeMerge(DateTime currentTime)
        {
            advancedRenovationService.UpdateTimeMerge(currentTime);
        }

        public void UpdateTimeSplit(DateTime currentTime)
        {
            advancedRenovationService.UpdateTimeSplit(currentTime);
        }
    }
}