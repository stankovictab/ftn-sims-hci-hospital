using System;
namespace Classes
{
    public class Appointment
    {
        public String AppointmentID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public AppointmentType Type { get; set; }
        public Room Room { get; set; }
        public Boolean StatusFinished { get; set; }
        public Doctor doctor { get; set; }
        public Patient patient { get; set; }

		public Appointment(String id, String doctorId, String patientId, DateTime start, DateTime end)
        {
            AppointmentID = id;
            doctor = new Doctor(doctorId);
            patient = new Patient(patientId);
            StartTime = start;
            EndTime = end;
        }
        public Appointment()
        { }

        public Appointment(String id, DateTime start, DateTime end)
        {
            AppointmentID = id;
            StartTime = start;
            EndTime = end;
        }
    }
}