/***********************************************************************
 * Module:  SplitRenovation.cs
 * Author:  Igor
 * Purpose: Definition of the Class Manager.SplitRenovation
 ***********************************************************************/

using System;

namespace Classes
{
   public class SplitRenovation
   {
      public int Id;
      public DateTime StartTime;
      public DateTime EndTime;
      public Room OldRoom;
      public Room NewRoom1;
      public Room NewRoom2;

        public SplitRenovation(int v, DateTime dateTime1, DateTime dateTime2, Room room, Room newRoom1, Room newRoom2)
        {
            this.Id = v;
            this.StartTime = dateTime1;
            this.EndTime = dateTime2;
            this.OldRoom = room;
            this.NewRoom1 = newRoom1;
            this.NewRoom2 = newRoom2;
        }
    }
}