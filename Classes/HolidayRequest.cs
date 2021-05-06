using System;

namespace Classes
{
    public class HolidayRequest
    {
        private String RequestID;
        private String Description;
        private DateTime StartDate;
        private DateTime EndDate;
        private DateTime RequestDate;
        private HolidayRequestStatus Status;
        public Doctor doctor;
        private string Commentary;

        // Format u txt fajlu treba da bude isti kao parametri konstruktora, vidi GetAll() metodu
        public HolidayRequest(String RequestID, String Description, DateTime StartDate, DateTime EndDate, DateTime RequestDate, HolidayRequestStatus Status, Doctor doctor, string commentary)
        {
            this.RequestID = RequestID;
            this.Description = Description;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.RequestDate = RequestDate;
            this.Status = Status;
            this.doctor = doctor;
            this.Commentary = commentary;
        }

        public string RequestID1 { get => RequestID; set => RequestID = value; }
        public string Description1 { get => Description; set => Description = value; }
        public DateTime StartDate1 { get => StartDate; set => StartDate = value; }
        public DateTime EndDate1 { get => EndDate; set => EndDate = value; }
        public DateTime RequestDate1 { get => RequestDate; set => RequestDate = value; }
        public HolidayRequestStatus Status1 { get => Status; set => Status = value; }
        public string Commentary1 { get => Commentary; set => Commentary = value; }

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