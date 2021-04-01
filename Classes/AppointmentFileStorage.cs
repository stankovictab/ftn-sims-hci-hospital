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
            string newLine = app.AppointmentID + ";" + app.doctor.user.Jmbg + ";" + app.patient.user.Jmbg + ";" + app.StartTime.ToString("yyyy,MM,dd,hh,mm,ss") + ";" + app.EndTime.ToString("yyyy,MM,dd,hh,mm,ss") + ";" + "0" + "\n";
            System.IO.File.AppendAllText(FileLocation, newLine);
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
            List<Appointment> ret = new List<Appointment>();
            string[] lines = System.IO.File.ReadAllLines(FileLocation);
            foreach (string line in lines)
            {
                string[] parts = line.Split(';');
                if (parts[1].Equals(doctorID)) 
                {
                    String appointmentId = parts[0];
                    string[] startParts = parts[3].Split(',');
                    DateTime start = new DateTime(int.Parse(startParts[0]), int.Parse(startParts[1]), int.Parse(startParts[2]), int.Parse(startParts[3]), int.Parse(startParts[4]), int.Parse(startParts[5]));
                    
                    string[] endParts = parts[4].Split(',');
                    DateTime end = new DateTime(int.Parse(endParts[0]), int.Parse(endParts[1]), int.Parse(endParts[2]), int.Parse(endParts[3]), int.Parse(endParts[4]), int.Parse(endParts[5]));

                    Appointment a = new Appointment(parts[0], parts[1], parts[2], start, end);
                    ret.Add(a);
                }
            }

            return ret;
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
            if (Delete(app.AppointmentID))
            {
                Create(app);
                return true;
            }
            
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
            List<String> novi = new List<string>();

            foreach(String row in rows)
            {
                String[] data = row.Split(';');
                if (!data[0].Equals(id))
                {
                    String r = String.Join(";", data);
                    novi.Add(r);
                }
                else
                {
                    if (!data[2].Equals("Pavle"))
                    {
                        String r = String.Join(";", data);
                        novi.Add(r);
                    }
                    else
                    {
                        found = true;
                    }
                }
            }

            System.IO.File.WriteAllLines(FileLocation, novi);
            if (found)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}