using System.Collections.Generic;
namespace Classes
{
    public class AssignmentService
    {
        public bool CreateAssignment(int amount, DynamicEquipment equipment)
        {
            // TODO: implement
            return false;
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

        public DynamicEquipmentRepository dynamicEquipmentRepository;
        public AssignmentRepository assignmentRepository;

    }
}