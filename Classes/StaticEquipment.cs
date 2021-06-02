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
        public int statId { get; set; }
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
        public override string ToString()
        {
            return string.Format("{0}-{1}", statId.ToString(), statName);
        }
    }
}