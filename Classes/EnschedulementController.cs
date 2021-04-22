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
        public List<StaticEquipment> GetStaticEquipment()
        {
            // TODO: implement
            return null;
        }

        public bool CreateEnschedulement(StaticEnschedulement newEnschedulement)
        {
            return enschedulementService.CreateEnschedulement(newEnschedulement);
        }

        public bool Update()
        {
            // TODO: implement
            return false;
        }

        public bool Delete()
        {
            // TODO: implement
            return false;
        }

        public List<StaticEnschedulement> GetAll()
        {
            return enschedulementService.GetAll();
        }

        public EnschedulementService enschedulementService = new EnschedulementService();

    }
}