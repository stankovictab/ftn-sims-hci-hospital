using System;
using System.Collections.Generic;

namespace Classes
{
    public class AppointmentController
    {
        public AppointmentService appointmentService;

        public AppointmentController()
        {
            appointmentService = new AppointmentService();
        }

        public List<Appointment> ShowAvailableAppointments(int priority, String doctorId, DateTime startTime, DateTime endTime, int type)
        {
            // TODO: implement
            return null;
        }

        public Appointment GetByID(String id)
        {
            return appointmentService.getById(id);
        }

        public Boolean CreateAppointment(String doctorId, String patientId, DateTime startTime, DateTime endTime ,int type, String roomId)
        {
            appointmentService.CreateAppointment(doctorId, patientId, startTime, endTime ,type,roomId);
            return true;
        }

        public List<String> ShowAvailableAppointmentsUpdate(String appointmentId, DateTime newDate)
        {
            // TODO: implement
            return null;
        }

        public Boolean UpdateAppointment(String appointmentId, DateTime startTime,DateTime endTime, String roomId,int type)
        {
            return appointmentService.UpdateAppointment(appointmentId, startTime, endTime, roomId, type);
        }

        public Boolean DeleteAppointment(String appointmentId)
        {
            return appointmentService.DeleteAppointment(appointmentId);
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
            return appointmentService.GetAllByDoctorId(doctorId);
        }
    }
}