/***********************************************************************
 * Module:  Room.cs
 * Author:  Igor
 * Purpose: Definition of the Class Manager.Room
 ***********************************************************************/

using System;

namespace Manager
{
   public class Room
   {
      public System.Collections.ArrayList roomEquipment;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetRoomEquipment()
      {
         if (roomEquipment == null)
            roomEquipment = new System.Collections.ArrayList();
         return roomEquipment;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetRoomEquipment(System.Collections.ArrayList newRoomEquipment)
      {
         RemoveAllRoomEquipment();
         foreach (StaticEquipment oStaticEquipment in newRoomEquipment)
            AddRoomEquipment(oStaticEquipment);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddRoomEquipment(StaticEquipment newStaticEquipment)
      {
         if (newStaticEquipment == null)
            return;
         if (this.roomEquipment == null)
            this.roomEquipment = new System.Collections.ArrayList();
         if (!this.roomEquipment.Contains(newStaticEquipment))
            this.roomEquipment.Add(newStaticEquipment);
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveRoomEquipment(StaticEquipment oldStaticEquipment)
      {
         if (oldStaticEquipment == null)
            return;
         if (this.roomEquipment != null)
            if (this.roomEquipment.Contains(oldStaticEquipment))
               this.roomEquipment.Remove(oldStaticEquipment);
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllRoomEquipment()
      {
         if (roomEquipment != null)
            roomEquipment.Clear();
      }
      public Doctor doctor;
   
      public String RoomNumber;
      public int FloorNumber;
      public String Description;
      public RoomType Type;
      public RoomStatus Status;

        public Room(string roomNumber, int floorNumber, string description, RoomType type, RoomStatus newStatus)
        {
            RoomNumber = roomNumber;
            FloorNumber = floorNumber;
            Description = description;
            Type = type;
        }

        public Room()
        {
        }
    }
}