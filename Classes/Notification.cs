using System;

namespace Classes
{
    public class Notification
    {
        public String Id;
        public String Title;
        public String Body;
        public DateTime Date;
        public Boolean Read;
        public String PatientId;
        public String DoctorId;

        public Notification(string id, string title, string body, DateTime date, bool read, string patientId, string doctorId)
        {
            Id = id;
            Title = title;
            Body = body;
            Date = date;
            Read = read;
            PatientId = patientId;
            DoctorId = doctorId;
        }
    }
}