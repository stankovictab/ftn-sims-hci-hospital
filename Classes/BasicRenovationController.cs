/***********************************************************************
 * Module:  BasicRenovationController.cs
 * Author:  Igor
 * Purpose: Definition of the Class Controllers,Services&Repositories.BasicRenovationController
 ***********************************************************************/

using System;
using System.Collections.Generic;

namespace Classes
{
    public class BasicRenovationController
    {
        public static BasicRenovationRepository repo = new BasicRenovationRepository();
        public BasicRenovationService basicRenovationService = new BasicRenovationService(repo);

        public List<BasicRenovation> GetAll()
        {
            return basicRenovationService.GetAll();
        }

        public bool Create(BasicRenovation newBasicRenovation)
        {
            return basicRenovationService.Create(newBasicRenovation);
        }

        public bool Delete(int toDelete)
        {
            return basicRenovationService.Delete(toDelete);
        }

        public bool UpdateFile(List<BasicRenovation> basicRenovationsInFile)
        {
            return basicRenovationService.UpdateFile(basicRenovationsInFile);
        }

        public void UpdateTime(DateTime currentTime)
        {
            basicRenovationService.UpdateTime(currentTime);
        }
    }
}