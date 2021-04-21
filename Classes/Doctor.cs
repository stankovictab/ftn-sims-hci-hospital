using System;
using System.Collections;
using System.Collections.Generic;
namespace Classes
{
    public class Doctor
    {
        public User user { get; set; }
        public Room room;
        public DoctorSpecialization specialization;
        public List<Appointment> appointments;
        public List<HolidayRequest> holidayRequests;
        public List<DynamicEquipmentRequest> dynamicEquipmentRequests;
        private List<Notification> notifications;

        // Ovaj treba da se brise, vidi gde je referenca
		public Doctor(User user, Room room, List<Appointment> appointments, List<HolidayRequest> holidayRequests)
        {
            this.user = user;
            this.room = room;
            this.appointments = appointments;
            this.holidayRequests = holidayRequests;
        }

        public Doctor(String id)
        {
            User user1 = new User(id);
            user = user1;
        }

        public Doctor(User user, Room room, DoctorSpecialization specialization, List<Appointment> appointments, List<HolidayRequest> holidayRequests, List<DynamicEquipmentRequest> dynamicEquipmentRequests, List<Notification> notifications)
        {
            this.user = user;
            this.room = room;
            this.specialization = specialization;
            this.appointments = appointments;
            this.holidayRequests = holidayRequests;
            this.dynamicEquipmentRequests = dynamicEquipmentRequests;
            this.notifications = notifications;
        }

        public List<DynamicEquipmentRequest> GetDynamicEquipmentRequests()
        {
            if (dynamicEquipmentRequests == null)
                dynamicEquipmentRequests = new List<DynamicEquipmentRequest>();
            return dynamicEquipmentRequests;
        }

        public void SetDynamicEquipmentRequests(List<DynamicEquipmentRequest> newDynamicEquipmentRequests)
        {
            RemoveAllDynamicEquipmentRequests();
            foreach (DynamicEquipmentRequest oDynamicEquipmentRequest in newDynamicEquipmentRequests)
                AddDynamicEquipmentRequests(oDynamicEquipmentRequest);
        }

        public void AddDynamicEquipmentRequests(DynamicEquipmentRequest newDynamicEquipmentRequest)
        {
            if (newDynamicEquipmentRequest == null)
                return;
            if (this.dynamicEquipmentRequests == null)
                this.dynamicEquipmentRequests = new List<DynamicEquipmentRequest>();
            if (!this.dynamicEquipmentRequests.Contains(newDynamicEquipmentRequest))
            {
                this.dynamicEquipmentRequests.Add(newDynamicEquipmentRequest);
                newDynamicEquipmentRequest.SetDoctor(this);
            }
        }

        public void RemoveDynamicEquipmentRequests(DynamicEquipmentRequest oldDynamicEquipmentRequest)
        {
            if (oldDynamicEquipmentRequest == null)
                return;
            if (this.dynamicEquipmentRequests != null)
                if (this.dynamicEquipmentRequests.Contains(oldDynamicEquipmentRequest))
                {
                    this.dynamicEquipmentRequests.Remove(oldDynamicEquipmentRequest);
                    oldDynamicEquipmentRequest.SetDoctor((Doctor)null);
                }
        }

        public void RemoveAllDynamicEquipmentRequests()
        {
            if (dynamicEquipmentRequests != null)
            {
                System.Collections.ArrayList tmpDynamicEquipmentRequests = new System.Collections.ArrayList();
                foreach (DynamicEquipmentRequest oldDynamicEquipmentRequest in dynamicEquipmentRequests)
                    tmpDynamicEquipmentRequests.Add(oldDynamicEquipmentRequest);
                dynamicEquipmentRequests.Clear();
                foreach (DynamicEquipmentRequest oldDynamicEquipmentRequest in tmpDynamicEquipmentRequests)
                    oldDynamicEquipmentRequest.SetDoctor((Doctor)null);
                tmpDynamicEquipmentRequests.Clear();
            }
        }

        public List<HolidayRequest> GetHolidayRequests()
        {
            if (holidayRequests == null)
                holidayRequests = new List<HolidayRequest>();
            return holidayRequests;
        }

        public void SetHolidayRequests(List<HolidayRequest> newHolidayRequests)
        {
            RemoveAllHolidayRequests();
            foreach (HolidayRequest oHolidayRequest in newHolidayRequests)
                AddHolidayRequests(oHolidayRequest);
        }

        public void AddHolidayRequests(HolidayRequest newHolidayRequest)
        {
            if (newHolidayRequest == null)
                return;
            if (this.holidayRequests == null)
                this.holidayRequests = new List<HolidayRequest>();
            if (!this.holidayRequests.Contains(newHolidayRequest))
            {
                this.holidayRequests.Add(newHolidayRequest);
                newHolidayRequest.SetDoctor(this);
            }
        }

        public void RemoveHolidayRequests(HolidayRequest oldHolidayRequest)
        {
            if (oldHolidayRequest == null)
                return;
            if (this.holidayRequests != null)
                if (this.holidayRequests.Contains(oldHolidayRequest))
                {
                    this.holidayRequests.Remove(oldHolidayRequest);
                    oldHolidayRequest.SetDoctor((Doctor)null);
                }
        }

        public void RemoveAllHolidayRequests()
        {
            if (holidayRequests != null)
            {
                System.Collections.ArrayList tmpHolidayRequests = new System.Collections.ArrayList();
                foreach (HolidayRequest oldHolidayRequest in holidayRequests)
                    tmpHolidayRequests.Add(oldHolidayRequest);
                holidayRequests.Clear();
                foreach (HolidayRequest oldHolidayRequest in tmpHolidayRequests)
                    oldHolidayRequest.SetDoctor((Doctor)null);
                tmpHolidayRequests.Clear();
            }
        }

        public List<Appointment> GetAppointments()
        {
            if (appointments == null)
                appointments = new List<Appointment>();
            return appointments;
        }

        public void SetAppointments(List<Appointment> newAppointments)
        {
            RemoveAllAppointments();
            foreach (Appointment oAppointment in newAppointments)
                AddAppointments(oAppointment);
        }

        public void AddAppointments(Appointment newAppointment)
        {
            if (newAppointment == null)
                return;
            if (this.appointments == null)
                this.appointments = new List<Appointment>();
            if (!this.appointments.Contains(newAppointment))
            {
                this.appointments.Add(newAppointment);
               // newAppointment.SetDoctor(this);
            }
        }

        public void RemoveAppointments(Appointment oldAppointment)
        {
            if (oldAppointment == null)
                return;
            if (this.appointments != null)
                if (this.appointments.Contains(oldAppointment))
                {
                    this.appointments.Remove(oldAppointment);
                   // oldAppointment.SetDoctor((Doctor)null);
                }
        }

        public void RemoveAllAppointments()
        {
            if (appointments != null)
            {
                System.Collections.ArrayList tmpAppointments = new System.Collections.ArrayList();
                foreach (Appointment oldAppointment in appointments)
                    tmpAppointments.Add(oldAppointment);
                appointments.Clear();
                foreach (Appointment oldAppointment in tmpAppointments)
                   // oldAppointment.SetDoctor((Doctor)null);
                tmpAppointments.Clear();
            }
        }
    }
}