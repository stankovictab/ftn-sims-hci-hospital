/***********************************************************************
 * Module:  HolidayRequest.cs
 * Author:  stankovictab
 * Purpose: Definition of the Class Doctor.HolidayRequest
 ***********************************************************************/

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
        private HolidayRequestStatus Status = 0;
        public Doctor doctor;

        // Format u txt fajlu treba da bude isti kao ovi parametri, vidi GetAll() u FileStorage klasi
        public HolidayRequest(String RequestID, String Description, DateTime StartDate, DateTime EndDate, Doctor doctor)
        {
            this.RequestID = RequestID;
            this.Description = Description;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.RequestDate = DateTime.Now; // TODO: Proveri da li radi
            this.Status = HolidayRequestStatus.OnHold; // default, mozda ne treba?
            this.doctor = doctor;
        }

        public string RequestID1 { get => RequestID; set => RequestID = value; }
        public string Description1 { get => Description; set => Description = value; }
        public DateTime StartDate1 { get => StartDate; set => StartDate = value; }
        public DateTime EndDate1 { get => EndDate; set => EndDate = value; }
        public DateTime RequestDate1 { get => RequestDate; set => RequestDate = value; }
        public HolidayRequestStatus Status1 { get => Status; set => Status = value; }

        /// <pdGenerated>default parent getter</pdGenerated>
        public Doctor GetDoctor()
        {
            return doctor;
        }

        /// <pdGenerated>default parent setter</pdGenerated>
        /// <param>newDoctor</param>
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