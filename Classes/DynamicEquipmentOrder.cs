using System;
using System.Collections.Generic;

namespace Classes
{
    public class DynamicEquipmentOrder
    {
        private string OrderID;
        private string EquipmentNames; // List<String>?
        private string EquipmentAmounts; // List<int>?
        private DateTime OrderDate;
        private DynamicEquipmentOrderStatus Status;

        public string OrderID1 { get => OrderID; set => OrderID = value; }
        public string EquipmentNames1 { get => EquipmentNames; set => EquipmentNames = value; }
        public string EquipmentAmounts1 { get => EquipmentAmounts; set => EquipmentAmounts = value; }
        public DateTime OrderDate1 { get => OrderDate; set => OrderDate = value; }
        public DynamicEquipmentOrderStatus Status1 { get => Status; set => Status = value; }

        public DynamicEquipmentOrder(String OrderID, string equipmentNames, string equipmentAmounts, DateTime OrderDate, DynamicEquipmentOrderStatus Status)
        {
            this.OrderID = OrderID;
            this.EquipmentNames = equipmentNames;
            this.EquipmentAmounts = equipmentAmounts;
            this.OrderDate = OrderDate;
            this.Status = Status;
        }
    }
}