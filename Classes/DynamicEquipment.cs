/***********************************************************************
 * Module:  DynamicEquipment.cs
 * Author:  Igor
 * Purpose: Definition of the Class Manager.DynamicEquipment
 ***********************************************************************/

using System;

namespace Classes
{
   public class DynamicEquipment
   {
        public int Id;
        public string Name;
        public string Amount;

        public DynamicEquipment()
        {
        }

        public DynamicEquipment(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }

        public DynamicEquipment(int Id, string Name, string Amount) : this(Id, Name)
        {
            this.Amount = Amount;
        }
    }
}