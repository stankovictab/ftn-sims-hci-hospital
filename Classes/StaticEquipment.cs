/***********************************************************************
 * Module:  StaticEquipment.cs
 * Author:  Igor
 * Purpose: Definition of the Class Manager.StaticEquipment
 ***********************************************************************/

using System;

namespace Classes
{
    public class StaticEquipment
    {
        public int statId;
        public string statName;
        public string statLocation;

        public StaticEquipment()
        {
        }

        public StaticEquipment(int statId, string statName, string statLocation)
        {
            this.statId = statId;
            this.statName = statName;
            this.statLocation = statLocation;
        }
    }
}