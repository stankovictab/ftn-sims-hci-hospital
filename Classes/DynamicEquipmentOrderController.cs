using System;
using System.Collections.Generic;

namespace Classes
{
    public class DynamicEquipmentOrderController
    {
        public DynamicEquipmentOrderService deos = new DynamicEquipmentOrderService();

        public Boolean Create(String equipmentNames, String equipmentAmounts)
        {
            return deos.Create(equipmentNames, equipmentAmounts);
        }

        public DynamicEquipmentOrder GetByID(String id)
        {
            return deos.GetByID(id);
        }

        public List<DynamicEquipmentOrder> GetAll()
        {
            return deos.GetAll();
        }

        public Boolean Update(String id, String equipmentNames, String equipmentAmounts)
        {
            return deos.Update(id, equipmentNames, equipmentAmounts);
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