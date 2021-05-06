using System;
using System.Collections.Generic;

namespace Classes
{
    public class DynamicEquipmentRequestService
    {
        public DynamicEquipmentRequestRepository derr = new DynamicEquipmentRequestRepository();

        public int CheckQuantity(String equipmentName)
        {
            DynamicEquipmentRepository der = new DynamicEquipmentRepository();
            List<DynamicEquipment> temp = der.GetAll();
            foreach (DynamicEquipment eq in temp)
            {
                if (eq.dynamicName.Equals(equipmentName))
                {
                    return Convert.ToInt32(eq.dynamicAmount);
                }
            }
            return 0;
        }

        public Boolean Create(String equipmentName, Doctor doctor)
        {
            List<DynamicEquipmentRequest> temp = derr.GetAll();
            int newid = 0;
            foreach (DynamicEquipmentRequest r in temp)
            {
                newid = Int32.Parse(r.RequestID1);
            }
            newid++;
            String newidstring = newid.ToString();

            DynamicEquipmentRequest req = new DynamicEquipmentRequest(newidstring, equipmentName, DateTime.Now, DynamicEquipmentRequestStatus.OnHold, doctor);
            return derr.Create(req);
        }

        public DynamicEquipmentRequest GetByID(String id)
        {
            return derr.GetByID(id);
        }

        public List<DynamicEquipmentRequest> GetAll()
        {
            return derr.GetAll();
        }

        public List<DynamicEquipmentRequest> GetAllByDoctorID(String id)
        {
            return derr.GetAllByDoctorID(id);
        }

        public List<DynamicEquipmentRequest> GetAllOnHold()
        {
            return derr.GetAllOnHold();
        }

        public Boolean Update(String id, String equipmentName, Doctor doctor)
        {
            DynamicEquipmentRequest req = new DynamicEquipmentRequest(id, equipmentName, DateTime.Now, DynamicEquipmentRequestStatus.OnHold, doctor);
            return derr.Update(req); // Provera da li postoji vec u listi se radi u repozitorijumu
        }

        public Boolean Delete(String id)
        {
            return derr.Delete(id);
        }

        public Boolean Approve(String id)
        {
            return derr.Approve(id);
        }

        public Boolean Deny(String id)
        {
            return derr.Deny(id);
        }
    }
}