using System;
using System.Collections.Generic;

namespace Classes
{
    public class AppointmentRepository
    {
        private String FileLocation;
        private List<Appointment> AppointmentsInFile;

        public List<Appointment> AppointmentsInFile1 { get => AppointmentsInFile; set => AppointmentsInFile = value; }

        public AppointmentRepository()
        {
            FileLocation = "../../Text Files/appointments.txt";
        }

        public Boolean Create(Appointment app)
        {
            string newLine = app.AppointmentID + ";" + app.doctor.user.Jmbg1 + ";" + app.patient.user.Jmbg1 + ";" + app.StartTime.Year.ToString()+"," + app.StartTime.Month.ToString() + ","+ app.StartTime.Day.ToString() + "," + app.StartTime.Hour.ToString() + "," + app.StartTime.Minute.ToString() + "," + app.StartTime.Second.ToString() + ";" + app.EndTime.Year.ToString() + "," + app.EndTime.Month.ToString() + "," + app.EndTime.Day.ToString() + "," + app.EndTime.Hour.ToString() + "," + app.EndTime.Minute.ToString() + "," + app.EndTime.Second.ToString() + ";" + app.Room.RoomNumber1 + ";" + (int)app.Type  + "\n";
            System.IO.File.AppendAllText(FileLocation, newLine);
            return true;
        }

        public Appointment GetByID(String id)
        {
            string[] lines = System.IO.File.ReadAllLines(FileLocation);
            foreach (string line in lines)
            {
                string[] parts = line.Split(';');
                if (parts[0].Equals(id))
                {
                    String appointmentId = parts[0];
                    string[] startParts = parts[3].Split(',');
                    DateTime start = new DateTime(int.Parse(startParts[0]), int.Parse(startParts[1]), int.Parse(startParts[2]), int.Parse(startParts[3]), int.Parse(startParts[4]), int.Parse(startParts[5]));

                    string[] endParts = parts[4].Split(',');
                    DateTime end = new DateTime(int.Parse(endParts[0]), int.Parse(endParts[1]), int.Parse(endParts[2]), int.Parse(endParts[3]), int.Parse(endParts[4]), int.Parse(endParts[5]));

                    Appointment a = new Appointment(parts[0], parts[1], parts[2], start, end, "213");
                    return a;
                }
            }
            return null;
        }

        public List<Appointment> GetAll()
        {
            String[] rows = System.IO.File.ReadAllLines(FileLocation);
            List<Appointment> appointments = new List<Appointment>();
            foreach (String row in rows)
            {
                String[] data = row.Split(';');
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
            return appointments;
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

                    Appointment a = new Appointment(parts[0], parts[1], parts[2], start, end, parts[5]);
                    a.Type = (AppointmentType) int.Parse(parts[6]);
                    ret.Add(a);
                }
            }

            return ret;
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

        public Boolean Delete(String id)
        { 
            String[] rows = System.IO.File.ReadAllLines(FileLocation);
            List<Appointment> appointments = new List<Appointment>();
            List<String> novi = new List<string>();
            foreach (String row in rows)
            {
                String[] data = row.Split(';');
                if (!data[0].Equals(id))
                {
                    String r = String.Join(";", data);
                    novi.Add(r);
                }
            }
            System.IO.File.WriteAllLines(FileLocation, novi);
            return true;
        }
    }
}