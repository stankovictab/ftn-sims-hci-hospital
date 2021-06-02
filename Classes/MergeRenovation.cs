/***********************************************************************
 * Module:  MergeRenovation.cs
 * Author:  Igor
 * Purpose: Definition of the Class Manager.MergeRenovation
 ***********************************************************************/

using System;

namespace Classes
{
   public class MergeRenovation
   {
      public int Id;
      public DateTime StartTime;
      public DateTime EndTime;
      public Room OldRoom1;
      public Room OldRoom2;
      public Room NewRoom;

        public MergeRenovation(int v, DateTime dateTime1, DateTime dateTime2, Room room1, Room room2, Room newRoom)
        {
            this.Id = v;
            this.StartTime = dateTime1;
            this.EndTime = dateTime2;
            this.OldRoom1 = room1;
            this.OldRoom2 = room2;
            this.NewRoom = newRoom;
        }
    }
}