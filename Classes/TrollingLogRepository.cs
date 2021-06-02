using System;
using System.Collections.Generic;

namespace ftn_sims_hci_hospital.Classes
{
    public class TrollingLogRepository
    {
        private String FileLocation;
        public TrollingLogRepository()
        {
            FileLocation = "../../Text Files/trollingLog.txt";
        }

        public void Create(TrollingLog trollingLog)
        {
            string newLine = trollingLog.patientId + ";" + trollingLog.appointmentId + ";" + trollingLog.dateOfScheduling.ToString("yyyy,MM,dd") + ";" + trollingLog.canceled.ToString() + "\n";
            System.IO.File.AppendAllText(FileLocation, newLine);
        }

        public void UpdateCanceling(String appointmentId)
        {
            TrollingLog t = GetByAppointmentId(appointmentId);
            Delete(appointmentId);
            t.canceled = true;
            Create(t);
        }

        public TrollingLog GetByAppointmentId(String id)
        {
            String[] rows = System.IO.File.ReadAllLines(FileLocation);
            TrollingLog trollingLog = new TrollingLog();
            foreach (String row in rows)
            {
                String[] data = row.Split(';');
                if (data[1].Equals(id))
                {
                    trollingLog.patientId = data[0];
                    trollingLog.appointmentId = data[1];
                    String[] dateParts = data[2].Split(',');
                    trollingLog.dateOfScheduling = new DateTime(int.Parse(dateParts[0]), int.Parse(dateParts[1]), int.Parse(dateParts[2]));
                    trollingLog.canceled = Boolean.Parse(data[3]);
                }
            }
            return trollingLog;
        }

        public List<TrollingLog> GetLastWeekScheduledAppointmentsByPatientId(String patientId)
        {
            String[] rows = System.IO.File.ReadAllLines(FileLocation);
            List<TrollingLog> trollingLogs = new List<TrollingLog>();
            foreach (String row in rows)
            {
                String[] data = row.Split(';');
                if (data[0].Equals(patientId))
                {
                    TrollingLog trollingLog = new TrollingLog();
                    trollingLog.patientId = data[0];
                    trollingLog.appointmentId = data[1];
                    String[] dateParts = data[2].Split(',');
                    trollingLog.dateOfScheduling = new DateTime(int.Parse(dateParts[0]), int.Parse(dateParts[1]), int.Parse(dateParts[2]));
                    trollingLog.canceled = Boolean.Parse(data[3]);
                    if ((DateTime.Now - trollingLog.dateOfScheduling).Days <= 7)
                        trollingLogs.Add(trollingLog);
                }
            }
            return trollingLogs;
        }

        public void Delete(String appointmentId)
        {
            String[] rows = System.IO.File.ReadAllLines(FileLocation);
            List<String> novi = new List<string>();
            foreach (String row in rows)
            {
                String[] data = row.Split(';');
                if (!data[1].Equals(appointmentId))
                {
                    String r = String.Join(";", data);
                    novi.Add(r);
                }
            }
            System.IO.File.WriteAllLines(FileLocation, novi);
        }
    }
}
