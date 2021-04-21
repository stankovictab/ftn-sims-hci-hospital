/***********************************************************************
 * Module:  EquipmentService.cs
 * Author:  Igor
 * Purpose: Definition of the Class Manager.EquipmentService
 ***********************************************************************/

using System;
using System.Collections.Generic;

namespace Manager
{
    public class AssignmentController
    {
        AssignmentService assignmentService = new AssignmentService();

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

        public bool CreateAssignment(int amount, DynamicEquipment equipment)
        {
            return assignmentService.CreateAssignment(amount, equipment);
        }

        public bool CheckAvailable(DynamicEquipment newDynamic, int amountToCheck)
        {
            // TODO: implement
            return false;
        }

        public List<DynamicEquipment> GetDynamicEquipment()
        {
            // TODO: implement
            return null;
        }

        public List<DynamicAssignment> GetAll()
        {
            return assignmentService.GetAll();
        }

    }
}