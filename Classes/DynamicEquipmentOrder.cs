using System;
using System.Collections.Generic;
using ftn_sims_hci_hospital.Classes;

namespace Classes
{
    public class DynamicEquipmentOrder : Order
    {
        private string EquipmentNames; // List<String>?
        private string EquipmentAmounts; // List<int>?

        public string EquipmentNames1 { get => EquipmentNames; set => EquipmentNames = value; }
        public string EquipmentAmounts1 { get => EquipmentAmounts; set => EquipmentAmounts = value; }

        public DynamicEquipmentOrder(String ID, string equipmentNames, string equipmentAmounts, DateTime CreationDate, OrderStatus Status)
        {
            this.ID = ID;
            this.EquipmentNames = equipmentNames;
            this.EquipmentAmounts = equipmentAmounts;
            this.CreationDate = CreationDate;
            this.Status1 = Status;
        }

        // Koristi se u DEOCreation
        public DynamicEquipmentOrder(string equipmentNames, string equipmentAmounts)
        {
            this.ID = null;
            this.EquipmentNames = equipmentNames;
            this.EquipmentAmounts = equipmentAmounts;
            this.CreationDate = DateTime.Now;
            this.Status1 = OrderStatus.Sent;
        }

        public DynamicEquipmentOrder() { }
    }
}