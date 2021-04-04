using System;
using System.Collections;

namespace Classes
{
    public class Doctor
    {
        public System.Collections.ArrayList holidayRequests;
        public User user { get; set; }
        public Room room;
        public System.Collections.ArrayList appointments;

        public Doctor(User user, Room room, ArrayList appointments, ArrayList holidayRequests)
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

        public System.Collections.ArrayList GetHolidayRequests()
        {
            if (holidayRequests == null)
                holidayRequests = new System.Collections.ArrayList();
            return holidayRequests;
        }

        public void SetHolidayRequests(System.Collections.ArrayList newHolidayRequests)
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
                this.holidayRequests = new System.Collections.ArrayList();
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

        public System.Collections.ArrayList GetAppointments()
        {
            if (appointments == null)
                appointments = new System.Collections.ArrayList();
            return appointments;
        }

        public void SetAppointments(System.Collections.ArrayList newAppointments)
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
                this.appointments = new System.Collections.ArrayList();
            if (!this.appointments.Contains(newAppointment))
            {
                this.appointments.Add(newAppointment);
                newAppointment.SetDoctor(this);
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
                    oldAppointment.SetDoctor((Doctor)null);
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
                    oldAppointment.SetDoctor((Doctor)null);
                tmpAppointments.Clear();
            }
        }

    }
}