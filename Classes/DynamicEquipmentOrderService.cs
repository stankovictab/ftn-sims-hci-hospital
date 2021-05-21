using System;
using System.Collections.Generic;

namespace Classes
{
    public class DynamicEquipmentOrderService
    {
        public DynamicEquipmentOrderRepository deor = new DynamicEquipmentOrderRepository();

        public Boolean Create(String equipmentNames, String equipmentAmounts)
        {
            List<DynamicEquipmentOrder> temp = deor.GetAll();
            int newid = 0;
            foreach (DynamicEquipmentOrder o in temp)
            {
                newid = Int32.Parse(o.OrderID1);
            }
            newid++;
            String newidstring = newid.ToString();

            DynamicEquipmentOrder ord = new DynamicEquipmentOrder(newidstring, equipmentNames, equipmentAmounts, DateTime.Now, DynamicEquipmentOrderStatus.Sent);
            return deor.Create(ord);
        }

        public DynamicEquipmentOrder GetByID(String id)
        {
            return deor.GetByID(id);
        }

        public List<DynamicEquipmentOrder> GetAll()
        {
            return deor.GetAll();
        }

        public Boolean Update(String id, String equipmentNames, String equipmentAmounts)
        {
            DynamicEquipmentOrder ord = new DynamicEquipmentOrder(id, equipmentNames, equipmentAmounts, DateTime.Now, DynamicEquipmentOrderStatus.Sent);
            return deor.Update(ord); // Provera da li postoji vec u listi se radi u repozitorijumu
        }

        public Boolean Delete(String id)
        {
            return deor.Delete(id);
        }

        public Boolean SetToWaiting(String id)
        {
            return deor.SetToWaiting(id);
        }

        public Boolean SetToCompleted(String id)
        {
            return deor.SetToCompleted(id);
        }
    }
}