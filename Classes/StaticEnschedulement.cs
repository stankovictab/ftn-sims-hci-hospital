/***********************************************************************
 * Module:  StaticEnschedulement.cs
 * Author:  Igor
 * Purpose: Definition of the Class Manager.StaticEnschedulement
 ***********************************************************************/

using System;
using System.Windows.Controls;

namespace Classes
{
    public class StaticEnschedulement
    {
        public DateTime Time;
        public Room FromRoom;
        public Room ToRoom;
        public StaticEquipment MovedEquipment;
        public int IdEnsch;


        public StaticEnschedulement(DateTime moveItemDate, Room fromRoom, Room toRoom, StaticEquipment equipment, int v)
        {
            this.Time = moveItemDate;
            FromRoom = fromRoom;
            ToRoom = toRoom;
            this.MovedEquipment = equipment;
            this.IdEnsch = v;
        }
    }
}