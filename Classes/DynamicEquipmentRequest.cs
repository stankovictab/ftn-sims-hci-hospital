using System;
namespace Classes
{
    public class DynamicEquipmentRequest
    {
        private String RequestID;
        private String EquipmentName;
        private String EquipmentAmount;
        private DateTime RequestDate;
        private DynamicEquipmentRequestStatus Status;
        private bool Ordered;
        public Doctor doctor;
        private string Commentary;

        public string RequestID1 { get => RequestID; set => RequestID = value; }
        public string EquipmentName1 { get => EquipmentName; set => EquipmentName = value; }
        public string EquipmentAmount1 { get => EquipmentAmount; set => EquipmentAmount = value; }
        public DateTime RequestDate1 { get => RequestDate; set => RequestDate = value; }
        public DynamicEquipmentRequestStatus Status1 { get => Status; set => Status = value; }
        public bool Ordered1 { get => Ordered; set => Ordered = value; }
        public string Commentary1 { get => Commentary; set => Commentary = value; }

        public DynamicEquipmentRequest(String RequestID, String EquipmentName, String EquipmentAmount, DateTime RequestDate, DynamicEquipmentRequestStatus Status, bool ordered, Doctor doctor, string commentary)
        {
            this.RequestID = RequestID;
            this.EquipmentName = EquipmentName;
            this.EquipmentAmount = EquipmentAmount;
            this.RequestDate = RequestDate;
            this.Status = Status;
            this.Ordered = ordered; // Ne moze uvek false da bude
            this.doctor = doctor;
            this.Commentary = commentary;
        }

        // Koristi se u Create-u u DERPanel-u
        public DynamicEquipmentRequest(String EquipmentName, Doctor Doctor)
        {
            this.RequestID = null;
            this.EquipmentName = EquipmentName;
            this.EquipmentAmount = "0";
            this.RequestDate = DateTime.Now;
            this.Status = DynamicEquipmentRequestStatus.OnHold;
            this.Ordered = false;
            this.doctor = Doctor;
            this.Commentary = "/";
        }

        // Koristi se u Update-u u DERPanel-u
        public DynamicEquipmentRequest(String RequestID, String EquipmentName)
        {
            this.RequestID = RequestID;
            this.EquipmentName = EquipmentName;
            this.EquipmentAmount = "0";
            this.RequestDate = DateTime.Now;
            this.Status = DynamicEquipmentRequestStatus.OnHold;
            this.Ordered = false;
            this.doctor = null;
            this.Commentary = "/";
        }

        // Koristi se u Update-u u DEOCreation-u
        public DynamicEquipmentRequest(String RequestID, String EquipmentName, String EquipmentAmount)
        {
            this.RequestID = RequestID;
            this.EquipmentName = EquipmentName;
            this.EquipmentAmount = EquipmentAmount;
            this.RequestDate = DateTime.Now;
            this.Status = DynamicEquipmentRequestStatus.OnHold;
            this.Ordered = false;
            this.doctor = null;
            this.Commentary = "/";
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