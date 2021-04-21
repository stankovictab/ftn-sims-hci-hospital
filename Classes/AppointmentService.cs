using ftn_sims_hci_hospital.Classes;
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

        public List<Appointment> ShowAvailableAppointments(Priority priority, String doctorId, DateTime startTime, DateTime endTime, AppointmentType type)
        {
            List<Appointment> slots = GeneratePossibleSlots(startTime, endTime);
            List<Appointment> filteredAppointments = new List<Appointment>();

            List<Appointment> appointments = appointmentRepository.GetAllByDoctorID(doctorId);
            available(filteredAppointments, slots, appointments, doctorId);

            if (filteredAppointments.Count > 0 || priority == Priority.None)
                return filteredAppointments;

            if(priority == Priority.Date)
            {
                List<String> zauzeti = new List<string>();
                List<String> slobodni = new List<string>();
                appointments = appointmentRepository.GetAll();
                foreach(Appointment slot in slots)
                {
                    foreach(Appointment appointment in appointments)
                    {
                        if (slot.StartTime.Equals(appointment.StartTime))
                        {
                            zauzeti.Add(appointment.doctor.user.Jmbg1);
                        }
                    }
                    List<Doctor> doctors = doctorRepository.GetAll();
                    foreach(Doctor doctor in doctors)
                    {
                        if (!zauzeti.Contains(doctor.user.Jmbg1))
                        {
                            Appointment app = new Appointment("", doctor.user.Jmbg1, "", slot.StartTime, slot.EndTime);
                            filteredAppointments.Add(app);
                        }
                    }
                    zauzeti.Clear();
                }
            }

            if (priority == Priority.Doctor)
            {
                slots = GeneratePossibleSlots(startTime, new DateTime(endTime.Year, endTime.Month, endTime.Day + 7));
                //appointments = appointmentRepository.GetAll();
                available(filteredAppointments, slots, appointments, doctorId);
            }

            return filteredAppointments;
        }

        void available(List<Appointment> filtered, List<Appointment> slots, List<Appointment> appointments, String doctorId)
        {
            int i = 0;
            foreach (Appointment slot in slots)
            {
                while (!slot.StartTime.Equals(appointments[i].StartTime))
                {
                    i++;
                    if (i == appointments.Count)
                        break;
                }
                if (i == appointments.Count)
                {
                    slot.doctor.user.Jmbg1 = doctorId;
                    filtered.Add(slot);
                }
                i = 0;
            }
            return;
        }

        List<Appointment> GeneratePossibleSlots(DateTime startTime, DateTime endTime)
        {
            List<Appointment> possibleSlots = new List<Appointment>();
            var interval = endTime - startTime;
            for (int i = 0; i < interval.Days; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    DateTime begin = new DateTime(startTime.Year, startTime.Month, startTime.Day + i, startTime.Hour + 8 + j, startTime.Minute, startTime.Second);
                    DateTime end = new DateTime(startTime.Year, startTime.Month, startTime.Day + i, startTime.Hour + 8 + j + 1, startTime.Minute, startTime.Second);
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

        public Boolean UpdateAppointment(String appointmentId, DateTime startTime, DateTime endTime, String roomId)
        {
            Appointment appointment = appointmentRepository.GetByID(appointmentId);
            appointment.StartTime = startTime;
            appointment.EndTime = endTime;
            appointmentRepository.Update(appointment);
            return true;
        }

        public Boolean DeleteAppointment(String appointmentId)
        {
            appointmentRepository.Delete(appointmentId);
            return false;
        }

        public List<Appointment> GetAllOperaionsByDoctorId(String doctorId)
        {
            // TODO: implement
            return null;
        }

        public List<Appointment> GetAllByPatientId(String patientId)
        {
            List<Appointment> app = appointmentRepository.GetAllByPatientID(patientId);
            return app;
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