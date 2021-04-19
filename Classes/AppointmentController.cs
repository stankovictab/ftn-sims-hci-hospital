using System;
using System.Collections.Generic;

namespace Classes
{
    public class AppointmentController
    {
        public AppointmentService appointmentService;

        public List<Appointment> ShowAvailableAppointments(int priority, String doctorId, DateTime startTime, DateTime endTime, int type)
        {
            // TODO: implement
            return null;
        }

        public Boolean CreateAppointment(String doctorId, String patientId, DateTime startTime, int type, String roomId)
        {
            // TODO: implement
            return false;
        }

        public List<String> ShowAvailableAppointmentsUpdate(String appointmentId, DateTime newDate)
        {
            // TODO: implement
            return null;
        }

        public Boolean UpdateAppointment(String appointmentId, DateTime newDate, String roomId)
        {
            // TODO: implement
            return false;
        }

        public Boolean DeleteAppointment(String appointmentId)
        {
            // TODO: implement
            return false;
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
            // TODO: implement
            return null;
        }
    }
}