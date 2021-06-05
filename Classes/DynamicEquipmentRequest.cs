using ftn_sims_hci_hospital.Classes;
using System;
namespace Classes

{
    public class DynamicEquipmentRequest : Request
    {
        private String EquipmentName;
        private String EquipmentAmount;
        private DynamicEquipmentRequestStatus Status;
        private bool Ordered;
        public Doctor doctor;

        public string EquipmentName1 { get => EquipmentName; set => EquipmentName = value; }
        public string EquipmentAmount1 { get => EquipmentAmount; set => EquipmentAmount = value; }
        public DynamicEquipmentRequestStatus Status1 { get => Status; set => Status = value; }
        public bool Ordered1 { get => Ordered; set => Ordered = value; }

        public DynamicEquipmentRequest(String ID, String EquipmentName, String EquipmentAmount, DateTime CreationDate, DynamicEquipmentRequestStatus Status, bool ordered, Doctor doctor, string commentary)
        {
            this.ID = ID;
            this.EquipmentName = EquipmentName;
            this.EquipmentAmount = EquipmentAmount;
            this.CreationDate = CreationDate;
            this.Status = Status;
            this.Ordered = ordered; // Ne moze uvek false da bude
            this.doctor = doctor;
            this.Commentary = commentary;
        }

        // Koristi se u Create-u u DERPanel-u
        public DynamicEquipmentRequest(String EquipmentName, Doctor Doctor)
        {
            this.ID = null;
            this.EquipmentName = EquipmentName;
            this.EquipmentAmount = "0";
            this.CreationDate = DateTime.Now;
            this.Status = DynamicEquipmentRequestStatus.OnHold;
            this.Ordered = false;
            this.doctor = Doctor;
            this.Commentary = "/";
        }

        // Koristi se u Update-u u DERPanel-u
        public DynamicEquipmentRequest(String ID, String EquipmentName)
        {
            this.ID = ID;
            this.EquipmentName = EquipmentName;
            this.EquipmentAmount = "0";
            this.CreationDate = DateTime.Now;
            this.Status = DynamicEquipmentRequestStatus.OnHold;
            this.Ordered = false;
            this.doctor = null;
            this.Commentary = "/";
        }

        // Koristi se u Update-u u DEOCreation-u
        public DynamicEquipmentRequest(String ID, String EquipmentName, String EquipmentAmount)
        {
            this.ID = ID;
            this.EquipmentName = EquipmentName;
            this.EquipmentAmount = EquipmentAmount;
            this.CreationDate = DateTime.Now;
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