using System;
using System.Collections.Generic;
using System.Windows;

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

        public Boolean Create(String equipmentName, String equipmentAmount, Doctor doctor)
        {
            List<DynamicEquipmentRequest> temp = derr.GetAll();
            int newid = 0;
            foreach (DynamicEquipmentRequest r in temp)
            {
                newid = Int32.Parse(r.RequestID1);
            }
            newid++;
            String newidstring = newid.ToString();

            DynamicEquipmentRequest req = new DynamicEquipmentRequest(newidstring, equipmentName, equipmentAmount, DateTime.Now, DynamicEquipmentRequestStatus.OnHold, false, doctor, "/");
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

        public Boolean Update(String id, String equipmentName, String equipmentAmount)
        {
            // Posto se doktor nece menjati pri update-u, a treba ga imati za ovaj konstruktor, nalazi se ovako
            List<DynamicEquipmentRequest> list = derr.GetAll();
            Doctor doctor = new Doctor();
            foreach(DynamicEquipmentRequest req in list)
            {
                if(req.RequestID1 == id)
                {
                    doctor = req.doctor;
                }
            }
            DynamicEquipmentRequest r = new DynamicEquipmentRequest(id, equipmentName, equipmentAmount, DateTime.Now, DynamicEquipmentRequestStatus.OnHold, false, doctor, "/");
            return derr.Update(r); // Provera da li postoji vec u listi se radi u repozitorijumu
        }

        public Boolean Delete(String id)
        {
            return derr.Delete(id);
        }

        public Boolean Approve(String id, String commentary)
        {
            return derr.Approve(id, commentary);
        }

        public Boolean Deny(String id, String commentary)
        {
            return derr.Deny(id, commentary);
        }

        public Boolean SetAllApprovedToOrdered()
        {
            return derr.SetAllApprovedToOrdered();
        }
    }
}