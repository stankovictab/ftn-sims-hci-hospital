/***********************************************************************
 * Module:  BasicRenovationService.cs
 * Author:  Igor
 * Purpose: Definition of the Class Controllers,Services&Repositories.BasicRenovationService
 ***********************************************************************/

using System;
using System.Collections.Generic;

namespace Classes
{
    public class BasicRenovationService
    {
        public IBasicRenovationRepository basicRenovationRepository;
        public BasicRenovationService(IBasicRenovationRepository repo)
        {
            this.basicRenovationRepository = repo;    
        }

        public List<BasicRenovation> GetAll()
        {
            return basicRenovationRepository.GetAll();
        }

        public bool Create(BasicRenovation newBasicRenovation)
        {
            if (!isAvailable(newBasicRenovation))
                return false;

            return basicRenovationRepository.Create(newBasicRenovation);
        }

        public bool Delete(int toDelete)
        {
            return basicRenovationRepository.Delete(toDelete);
        }

        public bool isAvailable(BasicRenovation toCheck)
        {
            List<BasicRenovation> basicRenovations = basicRenovationRepository.GetAll();

            foreach (BasicRenovation renovation in basicRenovations)
            {
                bool available = checkDateTime(renovation, toCheck);
                if (!available)
                    return false;
            }
            return true;
        }

        public bool checkDateTime(BasicRenovation renovation, BasicRenovation toCheck)
        {
            if (toCheck.Room.RoomNumber == renovation.Room.RoomNumber)
                if (toCheck.DateTime >= renovation.DateTime && toCheck.DateTime <= renovation.DateTime.AddMinutes(Convert.ToDouble(renovation.Duration)))
                    return false;
            return true;
        }

        public bool UpdateFile(List<BasicRenovation> basicRenovationsInFile)
        {
            return basicRenovationRepository.UpdateFile(basicRenovationsInFile);
        }

        public void UpdateTime(DateTime currentTime)
        {
            basicRenovationRepository.UpdateTime(currentTime);
        }
    }
}