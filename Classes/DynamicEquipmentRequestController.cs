using System;
using System.Collections.Generic;

namespace Classes
{
    public class DynamicEquipmentRequestController
    {
        public DynamicEquipmentRequestService ders = new DynamicEquipmentRequestService();

        public Boolean Create(String equipmentName, Doctor doctor)
        {
            return ders.Create(equipmentName, doctor);
        }

        public DynamicEquipmentRequest GetByID(String id)
        {
            return ders.GetByID(id);
        }

        public List<DynamicEquipmentRequest> GetAll()
        {
            return ders.GetAll();
        }

        public List<DynamicEquipmentRequest> GetAllByDoctorID(String id)
        {
            return ders.GetAllByDoctorID(id);
        }

        public List<DynamicEquipmentRequest> GetAllOnHold()
        {
            return ders.GetAllOnHold();
        }

        public Boolean Update(String id, String equipmentName, Doctor doctor)
        {
            return ders.Update(id, equipmentName, doctor);
        }

        public Boolean Delete(String id)
        {
            return ders.Delete(id);
        }

        public Boolean Approve(String id, String commentary)
        {
            return ders.Approve(id, commentary);
        }

        public Boolean Deny(String id, String commentary)
        {
            return ders.Deny(id, commentary);
        }
    }
}