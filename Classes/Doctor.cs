using System;
using System.Collections.Generic;
using System.IO;

namespace Classes
{
    public class Doctor
    {
        public System.Collections.ArrayList holidayRequests;
        public User user;
        public Room room;
        public System.Collections.ArrayList appointments;



        /// <pdGenerated>default getter</pdGenerated>
        public System.Collections.ArrayList GetHolidayRequests()
        {
            if (holidayRequests == null)
                holidayRequests = new System.Collections.ArrayList();
            return holidayRequests;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetHolidayRequests(System.Collections.ArrayList newHolidayRequests)
        {
            RemoveAllHolidayRequests();
            foreach (HolidayRequest oHolidayRequest in newHolidayRequests)
                AddHolidayRequests(oHolidayRequest);
        }

        /// <pdGenerated>default Add</pdGenerated>
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

        /// <pdGenerated>default Remove</pdGenerated>
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

        /// <pdGenerated>default removeAll</pdGenerated>
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

        /// <pdGenerated>default getter</pdGenerated>
        public System.Collections.ArrayList GetAppointments()
        {
            if (appointments == null)
                appointments = new System.Collections.ArrayList();
            return appointments;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetAppointments(System.Collections.ArrayList newAppointments)
        {
            RemoveAllAppointments();
            foreach (Appointment oAppointment in newAppointments)
                AddAppointments(oAppointment);
        }

        /// <pdGenerated>default Add</pdGenerated>
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

        /// <pdGenerated>default Remove</pdGenerated>
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

        /// <pdGenerated>default removeAll</pdGenerated>
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