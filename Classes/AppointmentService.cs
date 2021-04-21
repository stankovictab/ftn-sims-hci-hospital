using System;
using System.Collections.Generic;

namespace Classes
{
    public class AppointmentService
    {
        public AppointmentRepository appointmentRepository;
        public DoctorRepository doctorRepository;
        public PatientRepository patientRepository;
        public RoomRepository roomRepository;

        public AppointmentService()
        {
            appointmentRepository = new AppointmentRepository();
            doctorRepository = new DoctorRepository();
            patientRepository = new PatientRepository();
            roomRepository = new RoomRepository();
        }

        public Appointment getById(String id)
        {
            return appointmentRepository.GetByID(id);
        }

        public List<Appointment> ShowAvailableAppointments(int priority, String doctorId, DateTime startTime, DateTime endTime, int type)
        {
            // TODO: implement
            return null;
        }

        public Boolean CreateAppointment(String doctorId, String patientId, DateTime startTime, DateTime endTime ,int type, String roomId)
        {
            Random random = new Random();
            Appointment app = new Appointment(random.Next(1,1000).ToString(), doctorId, patientId, startTime, endTime,roomId);
            app.Type = (AppointmentType) type;
            appointmentRepository.Create(app);
            return true;
        }

        public List<String> ShowAvailableAppointmentsUpdate(String appointmentId, DateTime newDate)
        {
            // TODO: implement
            return null;
        }

        public Boolean UpdateAppointment(String appointmentId, DateTime startTime, DateTime endTime, String roomId, int type)
        {
            Appointment appointment = getById(appointmentId);
            appointment.StartTime = startTime;
            appointment.EndTime = endTime;
            appointment.Room.RoomNumber1 = roomId;
            appointment.Type = (AppointmentType) type;
            return appointmentRepository.Update(appointment);
        }

        public Boolean DeleteAppointment(String appointmentId)
        {
            return appointmentRepository.Delete(appointmentId);
        }

        public List<Appointment> GetAllOperaionsByDoctorId(String doctorId)
        {
            // TODO: implement
            return null;
        }

        public List<Appointment> GetAllByPatientId(String patientId)
        {
            // TODO: implement
            return null;
        }

        public List<Appointment> GetAllByDoctorId(String doctorId)
        {
            return appointmentRepository.GetAllByDoctorID(doctorId);
        }

        public Boolean AreDatesValid(DateTime start, DateTime end)
        {
            // TODO: implement
            return false;
        }
    }
}