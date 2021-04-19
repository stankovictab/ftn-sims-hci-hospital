using System;

namespace Classes
{
    public class Room
    {
        public Doctor doctor;
        private String RoomNumber;
        private int FloorNumber;
        private String Description;
        private RoomType Type;
        private RoomStatus Status;
        public System.Collections.ArrayList roomEquipment;

        public System.Collections.ArrayList GetRoomEquipment()
        {
            if (roomEquipment == null)
                roomEquipment = new System.Collections.ArrayList();
            return roomEquipment;
        }

        public void SetRoomEquipment(System.Collections.ArrayList newRoomEquipment)
        {
            RemoveAllRoomEquipment();
            foreach (StaticEquipment oStaticEquipment in newRoomEquipment)
                AddRoomEquipment(oStaticEquipment);
        }

        public void AddRoomEquipment(StaticEquipment newStaticEquipment)
        {
            if (newStaticEquipment == null)
                return;
            if (this.roomEquipment == null)
                this.roomEquipment = new System.Collections.ArrayList();
            if (!this.roomEquipment.Contains(newStaticEquipment))
                this.roomEquipment.Add(newStaticEquipment);
        }

        public void RemoveRoomEquipment(StaticEquipment oldStaticEquipment)
        {
            if (oldStaticEquipment == null)
                return;
            if (this.roomEquipment != null)
                if (this.roomEquipment.Contains(oldStaticEquipment))
                    this.roomEquipment.Remove(oldStaticEquipment);
        }

        public void RemoveAllRoomEquipment()
        {
            if (roomEquipment != null)
                roomEquipment.Clear();
        }
    }
}