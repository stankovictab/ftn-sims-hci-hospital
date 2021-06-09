using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public interface IAdvancedSplitRenovationRepository
    {

        List<SplitRenovation> SplitRenovations { get; set; }
        List<SplitRenovation> FinishedSplitRenovations { get; set; }
        List<SplitRenovation> PullFromFile(String FileLocation);


        void WriteToFile(List<SplitRenovation> splitRenovations, String FileLocation);


        List<SplitRenovation> GetAllSplit();


        List<SplitRenovation> GetAllSplitFinished();


        Boolean Create(SplitRenovation newSplitRenovation);


        Boolean Delete(int id);


        Boolean UpdateFile(List<SplitRenovation> splitRenovations);


        void UpdateTime(DateTime currentTime);
        
    }
}
