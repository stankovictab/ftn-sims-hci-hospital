using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class IAdvancedMergeRenovationRepository
    {
        public AdvancedMergeRenovationRepository advancedMergeRenovationRepository;

        public IAdvancedMergeRenovationRepository(AdvancedMergeRenovationRepository repo)
        {
            this.advancedMergeRenovationRepository = repo;
        }

        public List<MergeRenovation> AccessMergeRenovations { get => advancedMergeRenovationRepository.MergeRenovations; set => advancedMergeRenovationRepository.MergeRenovations = value; }
        public List<MergeRenovation> GetMergeRenovations()
        {
            return advancedMergeRenovationRepository.MergeRenovations;
        }

        public List<MergeRenovation> PullFromFile(String FileLocation)
        {
            return this.advancedMergeRenovationRepository.PullFromFile(FileLocation);
        }

        public void WriteToFile(List<MergeRenovation> mergeRenovations, String FileLocation)
        {
            this.advancedMergeRenovationRepository.WriteToFile(mergeRenovations, FileLocation);
        }

        public List<MergeRenovation> GetAllMerge()
        {
            return this.advancedMergeRenovationRepository.GetAllMerge();
        }

        public List<MergeRenovation> GetAllMergeFinished()
        {
            return this.advancedMergeRenovationRepository.GetAllMergeFinished();
        }

        public Boolean Create(MergeRenovation newMergeRenovation)
        {
            return this.advancedMergeRenovationRepository.Create(newMergeRenovation);
        }

        public Boolean Delete(int id)
        {
            return this.advancedMergeRenovationRepository.Delete(id);
        }

        public Boolean UpdateFile(List<MergeRenovation> mergeRenovations)
        {
            return this.advancedMergeRenovationRepository.UpdateFile(mergeRenovations);
        }

        public void UpdateTime(DateTime currentTime)
        {
            this.UpdateTime(currentTime);
        }
    }
}
