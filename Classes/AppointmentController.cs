using ftn_sims_hci_hospital;
using System;
using System.Collections.Generic;

namespace Classes
{
    public class AppointmentController
    {
        private static AppointmentRepository iar = new AppointmentRepository();
        public AppointmentService appointmentService = new AppointmentService(iar);

  

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

        public Boolean UpdateAppointment(String appointmentId, DateTime oldTime, DateTime startTime, DateTime endTime, String roomId, int type)
        {
            if (MainWindow.user.Role1 == Roles.Patient)
            {
                var dani = (startTime - oldTime).Days;
                if (dani >= 2 || dani < 0)
                {
                    return false;
                }
            }
               
            appointmentService.UpdateAppointment(appointmentId, startTime, endTime, roomId, type);
            
            
            return true;
        }

        public Boolean DeleteAppointment(String appointmentId)
        {
            appointmentService.DeleteAppointment(appointmentId);
            return true;
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