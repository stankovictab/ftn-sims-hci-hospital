using Classes;
using System;
using System.Collections.Generic;

namespace ftn_sims_hci_hospital.Classes
{
    public class ReminderRepository
    {
        private String FileLocation;
        private PatientRepository patientRepository;
        public ReminderRepository()
        {
            FileLocation = "../../Text Files/reminders.txt";
            patientRepository = new PatientRepository();
        }

        public Boolean Create(Reminder r)
        {
            string newLine = r.Id + ";" + r.Patient.user.Jmbg1 + ";" + r.Name + ";" + r.Description + ";" +
                r.Date.Year.ToString() + "," + r.Date.Month.ToString() + "," + r.Date.Day.ToString() + ","
                + r.Date.Hour.ToString() + "," + r.Date.Minute.ToString() + "," + r.Date.Second.ToString() + ";" +
                r.Highlighted + ";" + r.Seen + ";" + r.FrequencyInHours + "\n";
            System.IO.File.AppendAllText(FileLocation, newLine);
            return true;
        }

        public Reminder GetByID(String id)
        {
            string[] lines = System.IO.File.ReadAllLines(FileLocation);
            foreach (string line in lines)
            {
                string[] parts = line.Split(';');
                if (parts[0].Equals(id))
                {
                    String remindertId = parts[0];
                    string[] dateParts = parts[4].Split(',');
                    DateTime date = new DateTime(int.Parse(dateParts[0]), int.Parse(dateParts[1]), int.Parse(dateParts[2]), int.Parse(dateParts[3]), int.Parse(dateParts[4]), int.Parse(dateParts[5]));

                    Patient p = patientRepository.GetByID(parts[1]);
                    Reminder r = new Reminder(p, parts[2], parts[3], date, Boolean.Parse(parts[5]), Boolean.Parse(parts[6]), int.Parse(parts[7]));
                    r.Id = parts[0];
                    return r;
                }
            }
            return null;
        }

        public List<Reminder> GetAllByPatientID(String id, Boolean getHighlighted)
        {
            String[] rows = System.IO.File.ReadAllLines(FileLocation);
            List<Reminder> reminders = new List<Reminder>();
            foreach (String row in rows)
            {
                String[] parts = row.Split(';');
                if (getHighlighted)
                {
                    if (parts[1].Equals(id) && Boolean.Parse(parts[5]))
                    {
                        addToList(parts, reminders);
                    }
                }
                else
                {
                    if (parts[1].Equals(id) && !Boolean.Parse(parts[5]))
                    {
                        addToList(parts, reminders);
                    }
                }

            }
            return reminders;
        }
        private void addToList(String[] parts, List<Reminder> reminders)
        {
            String remindertId = parts[0];
            string[] dateParts = parts[4].Split(',');
            DateTime date = new DateTime(int.Parse(dateParts[0]), int.Parse(dateParts[1]), int.Parse(dateParts[2]), int.Parse(dateParts[3]), int.Parse(dateParts[4]), int.Parse(dateParts[5]));

            Patient p = patientRepository.GetByID(parts[1]);
            Reminder r = new Reminder(p, parts[2], parts[3], date, Boolean.Parse(parts[5]), Boolean.Parse(parts[6]), int.Parse(parts[7]));
            r.Id = parts[0];
            reminders.Add(r);
        }

        public List<Reminder> GetAll()
        {
            String[] rows = System.IO.File.ReadAllLines(FileLocation);
            List<Reminder> reminders = new List<Reminder>();
            foreach (String row in rows)
            {
                String[] parts = row.Split(';');
                String remindertId = parts[0];
                string[] dateParts = parts[4].Split(',');
                DateTime date = new DateTime(int.Parse(dateParts[0]), int.Parse(dateParts[1]), int.Parse(dateParts[2]), int.Parse(dateParts[3]), int.Parse(dateParts[4]), int.Parse(dateParts[5]));

                Patient p = patientRepository.GetByID(parts[1]);
                Reminder r = new Reminder(p, parts[2], parts[3], date, Boolean.Parse(parts[5]), Boolean.Parse(parts[6]), int.Parse(parts[7]));
                r.Id = parts[0];
                reminders.Add(r);
            }
            return reminders;
        }

        public Boolean Update(Reminder r)
        {
            if (Delete(r.Id))
            {
                Create(r);
                return true;
            }

            return false;
        }

        public Boolean Delete(String id)
        {
            String[] rows = System.IO.File.ReadAllLines(FileLocation);
            List<Reminder> appointments = new List<Reminder>();
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
