using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class IBasicRenovationRepository
    {
        BasicRenovationRepository basicRenovationRepository;
        public IBasicRenovationRepository(BasicRenovationRepository repo)
        {
            this.basicRenovationRepository = repo;
        }

        public List<BasicRenovation> AccessBasicRenovations { get => basicRenovationRepository.BasicRenovations; set => basicRenovationRepository.BasicRenovations = value; }

        public void UpdateTime(DateTime currentTime)
        {
            this.basicRenovationRepository.UpdateTime(currentTime);
        }

        public Boolean Create(BasicRenovation newBasicRenovation)
        {
            return this.basicRenovationRepository.Create(newBasicRenovation);
        }

        public List<BasicRenovation> GetAll()
        {
            return this.basicRenovationRepository.GetAll();
        }

        public List<BasicRenovation> GetAllFinished()
        {
            return this.basicRenovationRepository.GetAllFinished();
        }

        public Boolean UpdateFile(List<BasicRenovation> renovations)
        {
            return this.basicRenovationRepository.UpdateFile(renovations);
        }

        public Boolean Delete(int id)
        {
            return this.basicRenovationRepository.Delete(id);
        }
    }
}
