using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public interface IEnschedulementRepository
    {

        List<StaticEnschedulement> Enschedulements { get; set; }
        List<StaticEnschedulement> FinishedEnschedulements { get; set; }
        void UpdateTime(DateTime currentTime);


        Boolean Create(StaticEnschedulement newEnschedulement);


        List<StaticEnschedulement> GetAll();


        List<StaticEnschedulement> GetAllFinished();


        Boolean Delete(StaticEnschedulement enschedulement);

    }
}
