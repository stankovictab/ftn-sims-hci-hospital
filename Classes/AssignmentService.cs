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
        public IDynamicEquipmentRepository dynamicEquipmentRepository;
        public IAssignmentRepository assignmentRepository;

        public AssignmentService(/*IAssignmentRepository iRepo, IDynamicEquipmentRepository dynRepo*/)
        {
            /*this.assignmentRepository = iRepo;
            this.dynamicEquipmentRepository = dynRepo;*/
        }

        public bool Create(int amount, DynamicEquipment equipment)
        {
            if (!AmountIsAvailable(equipment, amount))
                return false;

            equipment.Amount = (Convert.ToInt32(equipment.Amount) - amount).ToString();
            dynamicEquipmentRepository.Update(equipment);
            dynamicEquipmentRepository.UpdateFile(dynamicEquipmentRepository.AccessDynamicEquipment);

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

        public Boolean Delete(DynamicAssignment assignment)
        {
            return assignmentRepository.Delete(assignment);
        }
    }
}