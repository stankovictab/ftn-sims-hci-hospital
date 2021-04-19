using System;
using System.Collections.Generic;

namespace Classes
{
    public class AppointmentRepository
    {
        private String FileLocation;
        private List<Appointment> AppointmentsInFile;

        public Boolean CreateAppointment(Appointment appointment)
        {
            // TODO: implement
            return false;
        }

        public Appointment GetByID(String id)
        {
            // TODO: implement
            return null;
        }

        public List<Appointment> GetAllAppointments()
        {
            // TODO: implement
            return null;
        }

        public List<Appointment> GetAllAppointmentsByPatientId(String patientId)
        {
            // TODO: implement
            return null;
        }

        public List<Appointment> GetAllAppointmentsByDoctorId(String doctorId)
        {
            // TODO: implement
            return null;
        }

        public Boolean UpdateAppointment(Appointment appointment)
        {
            // TODO: implement
            return false;
        }

        public Boolean DeleteAppointment(String appointmentId)
        {
            // TODO: implement
            return false;
        }
    }
}