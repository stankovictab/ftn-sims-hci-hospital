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
        public int rescheduled { get; set; }
        public Doctor doctor { get; set; }
        public Patient patient { get; set; }
        public Boolean isUrgent { get; set; }
        private DoctorRepository doctorRepository;
        private PatientRepository patientRepository;

        public Appointment(String id, String doctorId, String patientId, DateTime start, AppointmentType type, String roomId)
        {
            AppointmentID = id;
            doctor = new Doctor(doctorId);
            patient = new Patient(patientId);
            StartTime = start;
            EndTime = new DateTime(start.Year, start.Month, start.Day, start.Hour + 1, start.Minute, start.Second);
            this.Type = type;
            //this.Room = new(roomId);
            this.StatusFinished = false;
            rescheduled = 0;
        }

        public Appointment(String id, String doctorId, String patientId, DateTime start, DateTime end, String roomId)
        {
            AppointmentID = id;
            doctor = new Doctor(doctorId);
            patient = new Patient(patientId);
            StartTime = start;
            EndTime = end;

            Room r = new Room();
            r.RoomNumber1 = roomId;
            Room = r;
            rescheduled = 0;
        }

        public Appointment(String id, String doctorId, String patientId, DateTime start, DateTime end)
        {
            doctorRepository = new DoctorRepository();
            patientRepository = new PatientRepository();
            AppointmentID = id;
            if(doctorRepository.GetByID(doctorId) is null)
            {
                doctor = new Doctor(doctorId);
            }
            else
            {
                doctor = doctorRepository.GetByID(doctorId);
            }

            if(patientRepository.GetByID(patientId) is null)
            {
                patient = new Patient(patientId);
            }
            else
            {
                patient = patientRepository.GetByID(patientId);
            }
            
            StartTime = start;
            EndTime = end;
            rescheduled = 0;
        }
        public Appointment()
        { }

        public Appointment(String id, DateTime start, DateTime end)
        {
            AppointmentID = id;
            StartTime = start;
            EndTime = end;
            rescheduled = 0;
        }
    }
}