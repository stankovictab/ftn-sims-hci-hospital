/***********************************************************************
 * Module:  EquipmentService.cs
 * Author:  Igor
 * Purpose: Definition of the Class Manager.EquipmentService
 ***********************************************************************/

using System;
using System.Collections.Generic;

namespace Classes
{
    public class AssignmentController
    {
        AssignmentService assignmentService = new AssignmentService();

        public bool Create(int amount, DynamicEquipment equipment)
        {
            return assignmentService.Create(amount, equipment);
        }

        public List<DynamicAssignment> GetAll()
        {
            return assignmentService.GetAll();
        }

    }
}