using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class IEnschedulementRepository
    {
        EnschedulementRepository enschedulementRepository;
        public IEnschedulementRepository(EnschedulementRepository repo)
        {
            this.enschedulementRepository = repo;
        }

        public List<StaticEnschedulement> AccessEnschedulements { get => enschedulementRepository.Enschedulements; set => enschedulementRepository.Enschedulements = value; }


        public List<StaticEnschedulement> GetEnschedulements()
        {
            return enschedulementRepository.Enschedulements;
        }
        public void UpdateTime(DateTime currentTime)
        {
            this.enschedulementRepository.UpdateTime(currentTime);
        }

        public Boolean Create(StaticEnschedulement newEnschedulement)
        {
            return this.enschedulementRepository.Create(newEnschedulement);
        }

        public List<StaticEnschedulement> GetAll()
        {
            return this.enschedulementRepository.GetAll();
        }

        public List<StaticEnschedulement> GetAllFinished()
        {
            return this.enschedulementRepository.GetAllFinished();
        }

        public Boolean Delete(StaticEnschedulement enschedulement)
        {
            return this.enschedulementRepository.Delete(enschedulement);
        }
    }
}
