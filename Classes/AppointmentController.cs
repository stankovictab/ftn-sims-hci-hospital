using ftn_sims_hci_hospital;
using System;
using System.Collections.Generic;
using Models;
namespace Classes
{
    public class AppointmentController
    {
        public AppointmentService appointmentService = new AppointmentService();

        public AppointmentController()
        {
            appointmentService = new AppointmentService();
        }

        public Appointment GetByID(String id)
        {
            return appointmentService.getById(id);
        }

        
        public List<Appointment> ShowAvailableAppointments(Priority priority, String doctorId, DateTime startTime, DateTime endTime, AppointmentType type)
        {
            List<Appointment> appointments;
            appointments = appointmentService.ShowAvailableAppointments(priority, doctorId, startTime, endTime, type);
            return appointments;
        }

        public Boolean CreateAppointment(String doctorId, String patientId, DateTime startTime,DateTime endTime ,int type, String roomId)
        {
            appointmentService.CreateAppointment(doctorId, patientId, startTime, endTime,type, roomId);
            return true;
        }

        public List<String> ShowAvailableAppointmentsUpdate(String appointmentId, DateTime newDate)
        {
            // TODO: implement
            return null;
        }

        public Boolean UpdateAppointment(String appointmentId, DateTime startTime,DateTime endTime, DateTime end, String roomId,int type)
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
            List<Appointment> app = appointmentService.GetAllByPatientId(patientId);
            return app;
        }

        public List<Appointment> GetAllByDoctorId(String doctorId)
        {
            return appointmentService.GetAllByDoctorId(doctorId);
        }
    }
}