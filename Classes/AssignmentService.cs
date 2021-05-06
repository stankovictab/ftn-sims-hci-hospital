/***********************************************************************
 * Module:  ManagerService.cs
 * Author:  Igor
 * Purpose: Definition of the Class Manager.ManagerService
 ***********************************************************************/

using System;
using System.Collections.Generic;

namespace Classes
{
    public class AssignmentService
    {
        public DynamicEquipmentRepository dynamicEquipmentRepository = new DynamicEquipmentRepository();
        public AssignmentRepository assignmentRepository = new AssignmentRepository();


        public bool Create(int amount, DynamicEquipment equipment)
        {
            if (!AmountIsAvailable(equipment, amount))
                return false;

            equipment.Amount = (Convert.ToInt32(equipment.Amount) - amount).ToString();
            dynamicEquipmentRepository.Update(equipment);
            dynamicEquipmentRepository.UpdateFile(dynamicEquipmentRepository.DynamicEquipment);

            DynamicAssignment newAssignment = new DynamicAssignment(amount, equipment, 1);
            assignmentRepository.Create(newAssignment);

            return true;
        }

        public bool AmountIsAvailable(DynamicEquipment newDynamic, int amountToCheck)
        {
            if(Convert.ToInt32(newDynamic.Amount) - amountToCheck < 0)
                return false;
            return true;
        }


        public List<DynamicAssignment> GetAll()
        {
            return assignmentRepository.GetAll();
        }

    }
}