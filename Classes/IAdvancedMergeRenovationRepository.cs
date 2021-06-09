using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public interface IAdvancedMergeRenovationRepository
    {
        List<MergeRenovation> MergeRenovations { get; set; }
        List<MergeRenovation> FinishedMergeRenovations { get; set; }

        List<MergeRenovation> PullFromFile(String FileLocation);
        void WriteToFile(List<MergeRenovation> mergeRenovations, String FileLocation);
        List<MergeRenovation> GetAllMerge();
        List<MergeRenovation> GetAllMergeFinished();
        Boolean Create(MergeRenovation newMergeRenovation);
        Boolean Delete(int id);
        Boolean UpdateFile(List<MergeRenovation> mergeRenovations);
        void UpdateTime(DateTime currentTime);
    }
}
