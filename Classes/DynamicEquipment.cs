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
        public int dynamicId;
        public string dynamicName;
        public string dynamicAmount;

        public DynamicEquipment()
        {
        }

        public DynamicEquipment(int dynamicId, string dynamicName)
        {
            this.dynamicId = dynamicId;
            this.dynamicName = dynamicName;
        }

        public DynamicEquipment(int dynamicId, string dynamicName, string dynamicAmount) : this(dynamicId, dynamicName)
        {
            this.dynamicAmount = dynamicAmount;
        }
    }
}