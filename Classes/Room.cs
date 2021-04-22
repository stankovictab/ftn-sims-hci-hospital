using System;

namespace Classes
{
    public class Room
    {
        public Doctor doctor = null;
        public String RoomNumber;
        public int FloorNumber;
        public String Description;
        public RoomType Type;
        public RoomStatus Status;
        public System.Collections.ArrayList roomEquipment = null; // List<StaticEquipment>?

		public string RoomNumber1 { get => RoomNumber; set => RoomNumber = value; }
        public int FloorNumber1 { get => FloorNumber; set => FloorNumber = value; }
        public string Description1 { get => Description; set => Description = value; }
        public RoomType Type1 { get => Type; set => Type = value; }
        public RoomStatus Status1 { get => Status; set => Status = value; }

        public Room() { }

        public Room(string roomNumber, int floorNumber, string description, RoomType type, RoomStatus status = RoomStatus.Free)
        {
            RoomNumber = roomNumber;
            FloorNumber = floorNumber;
            Description = description;
            Type = type;
            Status = status;
        }

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