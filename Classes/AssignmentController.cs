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
        public static AssignmentRepository repo1 = new AssignmentRepository();
        public static DynamicEquipmentRepository repo2 = new DynamicEquipmentRepository();
        AssignmentService assignmentService = new AssignmentService(repo1, repo2);

        public bool Create(int amount, DynamicEquipment equipment)
        {
            return assignmentService.Create(amount, equipment);
        }

        public List<DynamicAssignment> GetAll()
        {
            return assignmentService.GetAll();
        }

        public Boolean Delete(DynamicAssignment assignment)
        {
            return assignmentService.Delete(assignment);
        }
    }
}