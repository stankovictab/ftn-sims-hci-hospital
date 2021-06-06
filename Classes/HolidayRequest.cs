using ftn_sims_hci_hospital.Classes;
using System;

namespace Classes
{
    public class HolidayRequest : Request
    {
        private String Description;
        private DateTime StartDate;
        private DateTime EndDate;
        public Doctor doctor;

        // Format u txt fajlu treba da bude isti kao parametri konstruktora, vidi GetAll() metodu
        public HolidayRequest(String ID, String Description, DateTime StartDate, DateTime EndDate, DateTime CreationDate, RequestStatus Status, Doctor doctor, string commentary)
        {
            this.ID = ID;
            this.Description = Description;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.CreationDate = CreationDate;
            this.Status = Status;
            this.doctor = doctor;
            this.Commentary = commentary;
        }

        // Koristi se u HolidayRequestCreation
        public HolidayRequest(String Description, DateTime StartDate, DateTime EndDate, Doctor doctor)
        {
            this.ID = null;
            this.Description = Description;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.CreationDate = DateTime.Now;
            this.Status = RequestStatus.OnHold;
            this.doctor = doctor;
            this.Commentary = "/";
        }

        // Koristi se u HolidayRequestUpdate
        public HolidayRequest(String RequestID, String Description, DateTime StartDate, DateTime EndDate)
        {
            this.ID = RequestID;
            this.Description = Description;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.CreationDate = DateTime.Now;
            this.Status = RequestStatus.OnHold;
            this.doctor = null;
            this.Commentary = "/";
        }

        public HolidayRequest() { }

        public string Description1 { get => Description; set => Description = value; }
        public DateTime StartDate1 { get => StartDate; set => StartDate = value; }
        public DateTime EndDate1 { get => EndDate; set => EndDate = value; }
        
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
                    oldDoctor.RemoveHolidayRequests(this);
                }
                if (newDoctor != null)
                {
                    this.doctor = newDoctor;
                    this.doctor.AddHolidayRequests(this);
                }
            }
        }
    }
}