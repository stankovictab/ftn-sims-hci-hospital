using System;

namespace Classes
{
    public class Notification
    {
        public String Id { get; set; }
        public String Title { get; set; }
        public String Body { get; set; }
        public DateTime Date { get; set; }
        public Boolean Read { get; set; }
        public String PatientId { get; set; }
        public String DoctorId { get; set; }

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