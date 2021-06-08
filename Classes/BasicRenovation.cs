/***********************************************************************
 * Module:  BasicRenovation.cs
 * Author:  Igor
 * Purpose: Definition of the Class Manager.BasicRenovation
 ***********************************************************************/

using System;

namespace Classes
{
    public class BasicRenovation
    {
        public int Id;
        public Room Room;
        public DateTime DateTime;
        public int Duration;

        public BasicRenovation(int id, Room room, DateTime dateTime, int duration)
        {
            Id = id;
            Room = room;
            DateTime = dateTime;
            Duration = duration;
        }
    }
}