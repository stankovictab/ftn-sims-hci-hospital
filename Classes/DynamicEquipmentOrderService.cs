using System;
using System.Collections.Generic;

namespace Classes
{
    public class DynamicEquipmentOrderService
    {
        public DynamicEquipmentOrderRepository deor = new DynamicEquipmentOrderRepository();

        public Boolean Create(DynamicEquipmentOrder ord)
        {
            List<DynamicEquipmentOrder> temp = deor.GetAll();
            int newID = 0;
            foreach (DynamicEquipmentOrder o in temp)
            {
                newID = Int32.Parse(o.ID1);
            }
            newID++;
            String newerID = newID.ToString();
            ord.ID1 = newerID;
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

        public Boolean Update(DynamicEquipmentOrder ord)
        {
            // TODO: Ovo treba da se doda za Order Update


            // DynamicEquipmentOrder ord = new DynamicEquipmentOrder(id, equipmentNames, equipmentAmounts, DateTime.Now, DynamicEquipmentOrderStatus.Sent);
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