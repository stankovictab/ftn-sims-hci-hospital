using ftn_sims_hci_hospital;
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
        public TrollingLogService trollingLogService;
        public TrollingLogRepository trollingLogRepository;

        public AppointmentService()
        {
            appointmentRepository = new AppointmentRepository();
            doctorRepository = new DoctorRepository();
            patientRepository = new PatientRepository();
            roomRepository = new RoomRepository();
            trollingLogService = new TrollingLogService();
            trollingLogRepository = new TrollingLogRepository();
        }

        public List<Appointment> ShowAvailableAppointments(Priority priority, String doctorId, DateTime startTime, DateTime endTime, AppointmentType type)
        {
            List<Appointment> slots = GeneratePossibleSlots(startTime, endTime);
            List<Appointment> filteredAppointments = new List<Appointment>();

            List<Appointment> appointments = appointmentRepository.GetAllByDoctorID(doctorId);
            available(filteredAppointments, slots, appointments, doctorId);

            if (filteredAppointments.Count > 0 || priority == Priority.None)
                return filteredAppointments;

            if (priority == Priority.Date)
            {
                List<String> zauzeti = new List<string>();
                List<String> slobodni = new List<string>();
                appointments = appointmentRepository.GetAll();
                foreach (Appointment slot in slots)
                {
                    foreach (Appointment appointment in appointments)
                    {
                        if (slot.StartTime.Equals(appointment.StartTime))
                        {
                            zauzeti.Add(appointment.doctor.user.Jmbg1);
                        }
                    }
                    List<Doctor> doctors = doctorRepository.GetAll();
                    foreach (Doctor doctor in doctors)
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
            int day;
            if (priority == Priority.Doctor)
            {
                if (startTime.Day + 2 > DateTime.DaysInMonth(startTime.Year, startTime.Month))
                {
                    day = startTime.Day + 2 - DateTime.DaysInMonth(startTime.Year, startTime.Month);
                    if (startTime.Month == 12)
                    {
                        slots = GeneratePossibleSlots(startTime, new DateTime(endTime.Year + 1, endTime.Month + 1, day));
                    }
                    else
                    {
                        slots = GeneratePossibleSlots(startTime, new DateTime(endTime.Year, endTime.Month + 1, day));
                    }
                }
                else
                {
                    slots = GeneratePossibleSlots(startTime, new DateTime(endTime.Year, endTime.Month, endTime.Day + 2));
                }
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
                    DateTime begin;
                    DateTime end;
                    if (startTime.Day + i > DateTime.DaysInMonth(startTime.Year, startTime.Month))
                    {
                        int day = startTime.Day + i - DateTime.DaysInMonth(startTime.Year, startTime.Month);
                        if (startTime.Month == 12)
                        {
                            begin = new DateTime(startTime.Year + 1, 1, day, startTime.Hour + 8 + j, startTime.Minute, startTime.Second);
                            end = new DateTime(startTime.Year + 1, 1, day, startTime.Hour + 8 + j + 1, startTime.Minute, startTime.Second);
                        }
                        else
                        {
                            begin = new DateTime(startTime.Year, startTime.Month + 1, day, startTime.Hour + 8 + j, startTime.Minute, startTime.Second);
                            end = new DateTime(startTime.Year, startTime.Month + 1, day, startTime.Hour + 8 + j + 1, startTime.Minute, startTime.Second);
                        }
                    }
                    else
                    {
                        begin = new DateTime(startTime.Year, startTime.Month, startTime.Day + i, startTime.Hour + 8 + j, startTime.Minute, startTime.Second);
                        end = new DateTime(startTime.Year, startTime.Month, startTime.Day + i, startTime.Hour + 8 + j + 1, startTime.Minute, startTime.Second);
                    }
                    Appointment a = new Appointment("1", "", "", begin, end);
                    possibleSlots.Add(a);
                }
            }
            return possibleSlots;
        }

        public Boolean CreateAppointment(String doctorId, String patientId, DateTime startTime, DateTime endTime, int type, String roomId)
        {
            if (MainWindow.user.Role1 == Roles.Patient)
            {
                List<Appointment> appointments = appointmentRepository.GetAll();
                String newAppointmentId = appointmentRepository.GenerateNewId();
                appointmentRepository.Create(new Appointment(newAppointmentId, doctorId, patientId, startTime, endTime, roomId));
                trollingLogRepository.Create(new TrollingLog(MainWindow.user.Jmbg1, newAppointmentId, DateTime.Now, false));
                return true;
            }
            else
            {
                Random random = new Random();
                Appointment app = new Appointment(random.Next(1, 1000).ToString(), doctorId, patientId, startTime, endTime, roomId);
                app.Type = (AppointmentType)type;
                appointmentRepository.Create(app);
                return true;
            }
        }

        public List<String> ShowAvailableAppointmentsUpdate(String appointmentId, DateTime newDate)
        {
            // TODO: implement
            return null;
        }

        public Boolean UpdateAppointment(String appointmentId, DateTime startTime, DateTime endTime, String roomId, int type)
        {
            Appointment appointment = appointmentRepository.GetByID(appointmentId);
            appointment.StartTime = startTime;
            appointment.EndTime = endTime;
            appointment.Room.RoomNumber1 = roomId;
            appointment.Type = (AppointmentType)type;
            appointmentRepository.Update(appointment);
            return true;
        }

        public Boolean DeleteAppointment(String appointmentId)
        {
            if (appointmentRepository.Delete(appointmentId))
            {
                trollingLogRepository.UpdateCanceling(appointmentId);
                if (trollingLogService.TrollCounter(MainWindow.user.Jmbg1) > 3)
                {
                    trollingLogService.BlockUser(MainWindow.user.Jmbg1);
                }
            }
            return false;
        }

        public List<Appointment> GetAllOperationsByDoctorId(String doctorId)
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
            return appointmentRepository.GetAllByDoctorID(doctorId);
        }

        public Boolean AreDatesValid(DateTime start, DateTime end)
        {
            // TODO: implement
            return false;
        }

    }
}