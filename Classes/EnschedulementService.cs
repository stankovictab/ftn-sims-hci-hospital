using System;

namespace Classes
{
    public class EnschedulementService
    {
        public EnschedulementRepository enschedulementRepository;
        public StaticEquipmentRepository staticEquipmentRepository;

        public bool CreateEnschedulement(DateTime time, Room fromRoom, Room toRoom, StaticEquipment equipment)
        {
            // TODO: implement
            return false;
        }

        public bool CheckAvailable(StaticEnschedulement newEnsch)
        {
            // TODO: implement
            return false;
        }
    }
}