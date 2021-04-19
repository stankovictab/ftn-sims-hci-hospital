using System;

namespace Classes
{
    public class HolidayRequest
    {
        public Doctor doctor;
        private String RequestID;
        private String Description;
        private DateTime StartDate;
        private DateTime EndDate;
        private DateTime RequestDate;
        private HolidayRequestStatus Status = 0;

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