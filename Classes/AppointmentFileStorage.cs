/***********************************************************************
 * Module:  AppointmentFileStorage.cs
 * Author:  stankovictab
 * Purpose: Definition of the Class Patient.AppointmentFileStorage
 ***********************************************************************/

using System;
using System.Collections.Generic;

namespace Classes
{
    public class AppointmentFileStorage
    {
        private String FileLocation;
        private List<Appointment> AppointmentsInFile;

        public AppointmentFileStorage()
        {
            FileLocation = "AppointmentFileStorage.txt";
        }


        public Boolean Create(Appointment app)
        {
            // TODO: implement
            return false;
        }

        public Appointment GetByID(String id)
        {
            // TODO: implement
            return null;
        }

        public Appointment GetByStartTime(DateTime startTime)
        {
            // TODO: implement
            return null;
        }

        public List<Appointment> GetAllByDoctorID(String doctorID)
        {
            // TODO: implement
            return null;
        }

        public List<Appointment> GetAllByPatientID(String patientID)
        {
            String[] rows = System.IO.File.ReadAllLines(FileLocation);
            List<Appointment> appointments = new List<Appointment>();
            foreach (String row in rows)
            {
                String[] data = row.Split(';');
                if (data[2].Equals(patientID))
                {
                    String doctorId = data[1];
                    String patientId = data[2];
                    String id = data[0];
                    String[] startParts = data[3].Split(',');
                    String[] endParts = data[4].Split(',');
                    DateTime start = new DateTime(int.Parse(startParts[0]), int.Parse(startParts[1]), int.Parse(startParts[2]), int.Parse(startParts[3]), int.Parse(startParts[4]), int.Parse(startParts[5]));
                    DateTime end = new DateTime(int.Parse(startParts[0]), int.Parse(startParts[1]), int.Parse(startParts[2]), int.Parse(startParts[3]), int.Parse(startParts[4]), int.Parse(startParts[5]));
                    Appointment a = new Appointment(id, doctorId, patientId, start, end);
                    appointments.Add(a);
                }
            }

            return appointments;
        }

        public List<Appointment> GetAll()
        {
            /* Appointment a1 = new Appointment();
             Appointment a2 = new Appointment();
             List<Appointment> appointments = new List<Appointment>();
             appointments.Add(a1);
             appointments.Add(a2);
             return appointments;*/
            return null;
        }

        public Boolean Update(Appointment app)
        {
            // TODO: implement
            return false;
        }

        public Boolean UpdateAll(List<Appointment> aif)
        {
            // TODO: implement
            return false;
        }

        public Boolean Delete(String id)
        {
            String[] rows = System.IO.File.ReadAllLines(FileLocation);
            List<Appointment> appointments = new List<Appointment>();
            String[] rowsNew = new String[rows.Length - 1];
            int j = 0;
            Boolean found = false;
            for(int i = 0; i < rows.Length; i++)
            {
                if(i != j)
                {
                    found = true;
                }
                int first = rows[i].IndexOf(";");
                if (!id.Equals(rows[i].Substring(0, first))){
                    if(!found && i == rows.Length - 1)
                    {
                        return false;
                    }
                    else
                    {
                        rowsNew[j] = rows[i];
                        j++;
                    }
                }
            }
            System.IO.File.WriteAllLines(FileLocation, rowsNew);
            return true;
        }
    }
}