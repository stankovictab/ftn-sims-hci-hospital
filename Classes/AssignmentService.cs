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
            if (!CheckAvailableAmount(equipment, amount))
                return false;

            equipment.dynamicAmount = (Convert.ToInt32(equipment.dynamicAmount) - amount).ToString();
            dynamicEquipmentRepository.Update(equipment);
            dynamicEquipmentRepository.UpdateAll(dynamicEquipmentRepository.DynamicInFile);

            DynamicAssignment newAssignment = new DynamicAssignment(amount, equipment, 1);
            assignmentRepository.Create(newAssignment);

            return true;
        }

        public bool CheckAvailableAmount(DynamicEquipment newDynamic, int amountToCheck)
        {
            if(Convert.ToInt32(newDynamic.dynamicAmount) - amountToCheck < 0)
                return false;
            return true;
        }

        public List<DynamicEquipment> GetDynamicEquipment()
        {
            // TODO: implement
            return null;
        }

        public List<DynamicAssignment> GetAll()
        {
            return assignmentRepository.GetAll();
        }

    }
}