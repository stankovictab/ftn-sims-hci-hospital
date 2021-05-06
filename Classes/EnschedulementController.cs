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

        public List<StaticEnschedulement> DateCheck(DateTime date)
        {
            return enschedulementService.DateCheck(date);
        }

        public EnschedulementService enschedulementService = new EnschedulementService();

    }
}