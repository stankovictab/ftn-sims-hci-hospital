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

        public List<Appointment> ShowAvailableAppointments(int priority, String doctorId, DateTime startTime, DateTime endTime, int type)
        {
            // TODO: implement
            return null;
        }

        public List<Appointment> generateTimeSlots( DateTime startTime, DateTime endTime)
        {
            List<Appointment> possibleSlots = new List<Appointment>();
            var interval=endTime - startTime;
            for (int i = 0; i < interval.Days; i++)
            {
                
                for (int j = 0; j < 12; j++)
                {
                    DateTime begin = new DateTime(startTime.Year, startTime.Month, startTime.Day + i, startTime.Hour + 8 + j, startTime.Minute, startTime.Second);
                    DateTime end = new DateTime(startTime.Year, startTime.Month, startTime.Day + i, startTime.Hour + 8 + j+1, startTime.Minute, startTime.Second);
                    Appointment a = new Appointment("1", "", "", begin, end);
                    possibleSlots.Add(a);
                }

            }
            return possibleSlots;
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

        public Boolean AreDatesValid(DateTime start, DateTime end)
        {
            // TODO: implement
            return false;
        }
    }
}