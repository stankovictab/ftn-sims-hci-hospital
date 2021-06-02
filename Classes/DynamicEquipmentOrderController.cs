using System;
using System.Collections.Generic;

namespace Classes
{
    public class DynamicEquipmentOrderController
    {
        public DynamicEquipmentOrderService deos = new DynamicEquipmentOrderService();

        public Boolean Create(DynamicEquipmentOrder ord)
        {
            return deos.Create(ord);
        }

        public DynamicEquipmentOrder GetByID(String id)
        {
            return deos.GetByID(id);
        }

        public List<DynamicEquipmentOrder> GetAll()
        {
            return deos.GetAll();
        }

        public Boolean Update(DynamicEquipmentOrder ord)
        {
            return deos.Update(ord);
        }

        public Boolean Delete(String id)
        {
            return deos.Delete(id);
        }

        public Boolean SetToWaiting(String id)
        {
            return deos.SetToWaiting(id);
        }

        public Boolean SetToCompleted(String id)
        {
            return deos.SetToCompleted(id);
        }
    }
}