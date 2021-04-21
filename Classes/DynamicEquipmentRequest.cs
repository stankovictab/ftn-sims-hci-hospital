using System;
namespace Classes
{
    public class DynamicEquipmentRequest
    {
        private String RequestID;
        private String EquipmentName;
        private DateTime RequestDate;
        private DynamicEquipmentRequestStatus Status;
        public Doctor doctor;

        public string RequestID1 { get => RequestID; set => RequestID = value; }
        public string EquipmentName1 { get => EquipmentName; set => EquipmentName = value; }
        public DateTime RequestDate1 { get => RequestDate; set => RequestDate = value; }
        public DynamicEquipmentRequestStatus Status1 { get => Status; set => Status = value; }

        public DynamicEquipmentRequest(String RequestID, String EquipmentName, DateTime RequestDate, DynamicEquipmentRequestStatus Status, Doctor doctor)
        {
            this.RequestID = RequestID;
            this.EquipmentName = EquipmentName;
            this.RequestDate = RequestDate;
            this.Status = Status;
            this.doctor = doctor;
        }

        public Doctor GetDoctor()
        {
            return doctor;
        }

        public void SetDoctor(Doctor newDoctor)
        {
            if (this.doctor != newDoctor)
            {
                if (this.doctor != null)
                {
                    Doctor oldDoctor = this.doctor;
                    this.doctor = null;
                    oldDoctor.RemoveDynamicEquipmentRequests(this);
                }
                if (newDoctor != null)
                {
                    this.doctor = newDoctor;
                    this.doctor.AddDynamicEquipmentRequests(this);
                }
            }
        }
    }
}