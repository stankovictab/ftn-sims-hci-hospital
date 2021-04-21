/***********************************************************************
 * Module:  StaticEnschedulement.cs
 * Author:  Igor
 * Purpose: Definition of the Class Manager.StaticEnschedulement
 ***********************************************************************/

using System;

namespace Manager
{
    public class DynamicAssignment
    {
        public DynamicEquipment EquipmentAssigned;
        public int AmountAssigned;
        public int IdAssign;
        
        public DynamicAssignment(int amount, DynamicEquipment equipment, int id)
        {
            this.AmountAssigned = amount;
            this.EquipmentAssigned = equipment;
            this.IdAssign = id;
        }
    }
}