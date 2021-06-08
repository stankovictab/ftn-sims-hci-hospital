/***********************************************************************
 * Module:  EquipmentService.cs
 * Author:  Igor
 * Purpose: Definition of the Class Manager.EquipmentService
 ***********************************************************************/

using System;
using System.Collections.Generic;

namespace Classes
{
    public class EnschedulementController
    {

        public bool CreateEnschedulement(StaticEnschedulement newEnschedulement)
        {
            return enschedulementService.CreateEnschedulement(newEnschedulement);
        }


        public List<StaticEnschedulement> GetAll()
        {
            return enschedulementService.GetAll();
        }

        public List<StaticEnschedulement> GetAllFinished()
        {
            return enschedulementService.GetAllFinished();
        }

        public List<StaticEnschedulement> DateCheck(DateTime date)
        {
            return enschedulementService.DateCheck(date);
        }

        public Boolean Delete(StaticEnschedulement enschedulement)
        {
            return enschedulementService.Delete(enschedulement);
        }

        public void UpdateTime(DateTime currentTime)
        {
            enschedulementService.UpdateTime(currentTime);
        }

        public EnschedulementService enschedulementService = new EnschedulementService();

    }
}