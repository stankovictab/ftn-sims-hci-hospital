using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class IAdvancedSplitRenovationRepository
    {
        AdvancedSplitRenovationRepository advancedSplitRenovationRepository;

        public IAdvancedSplitRenovationRepository(AdvancedSplitRenovationRepository repo)
        {
            this.advancedSplitRenovationRepository = repo;
        }

        public List<SplitRenovation> AccessSplitRenovations { get => advancedSplitRenovationRepository.SplitRenovations; set => advancedSplitRenovationRepository.SplitRenovations = value; }

        public List<SplitRenovation> PullFromFile(String FileLocation)
        {
            return this.advancedSplitRenovationRepository.PullFromFile(FileLocation);
        }

        public void WriteToFile(List<SplitRenovation> splitRenovations, String FileLocation)
        {
            this.advancedSplitRenovationRepository.WriteToFile(splitRenovations, FileLocation);
        }

        public List<SplitRenovation> GetAllSplit()
        {
            return this.advancedSplitRenovationRepository.GetAllSplit();
        }

        public List<SplitRenovation> GetAllSplitFinished()
        {
            return this.advancedSplitRenovationRepository.GetAllSplitFinished();
        }

        public Boolean Create(SplitRenovation newSplitRenovation)
        {
            return this.advancedSplitRenovationRepository.Create(newSplitRenovation);
        }

        public Boolean Delete(int id)
        {
            return this.advancedSplitRenovationRepository.Delete(id);
        }

        public Boolean UpdateFile(List<SplitRenovation> splitRenovations)
        {
            return this.advancedSplitRenovationRepository.UpdateFile(splitRenovations);
        }

        public void UpdateTime(DateTime currentTime)
        {
            this.advancedSplitRenovationRepository.UpdateTime(currentTime);
        }
    }
}
