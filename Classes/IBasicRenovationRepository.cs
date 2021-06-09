using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public interface IBasicRenovationRepository
    {
        List<BasicRenovation> BasicRenovations { get; set; }
        List<BasicRenovation> FinishedBasicRenovations { get; set; }
        void UpdateTime(DateTime currentTime);


        Boolean Create(BasicRenovation newBasicRenovation);


        List<BasicRenovation> GetAll();


        List<BasicRenovation> GetAllFinished();


        Boolean UpdateFile(List<BasicRenovation> renovations);

        Boolean Delete(int id);

    }
}
