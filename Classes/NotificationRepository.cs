using System;
using System.Collections.Generic;

namespace Classes
{
    public class NotificationRepository
    {
        private String FileLocation;
        private List<Notification> NotificationsInFile;

        public NotificationRepository()
        {
            FileLocation = "../../Text Files/notifications.txt";
        }
        public Boolean Create(Notification notification)
        {
            string newLine = notification.Id + ";" + notification.PatientId + ";" + notification.DoctorId + ";" + notification.Body + ";" + notification.Title + ";" + notification.Read + ";" + notification.Date.ToString("yyyy,MM,dd,hh,mm,ss") + "\n";
            System.IO.File.AppendAllText(FileLocation, newLine);
            return true;
        }

        public List<Notification> GetByPatientID(String id)
        {
            string[] lines = System.IO.File.ReadAllLines(FileLocation);
            List<Notification> notifications = new List<Notification>();
            foreach (string line in lines)
            {
                string[] parts = line.Split(';');
                if (parts[1].Equals(id))
                {
                    String notificationId = parts[0];
                    string[] dateParts = parts[6].Split(',');
                    DateTime date = new DateTime(int.Parse(dateParts[0]), int.Parse(dateParts[1]), int.Parse(dateParts[2]), int.Parse(dateParts[3]), int.Parse(dateParts[4]), int.Parse(dateParts[5]));
                    Notification notification = new Notification(parts[0], parts[4], parts[3], date, Convert.ToBoolean(parts[5]), parts[1], parts[2]);
                    notifications.Add(notification);
                }
            }
            return notifications;
        }

        public List<Notification> GetByDoctorID(String id)
        {
            string[] lines = System.IO.File.ReadAllLines(FileLocation);
            List<Notification> notifications = new List<Notification>();
            foreach (string line in lines)
            {
                string[] parts = line.Split(';');
                if (parts[2].Equals(id))
                {
                    String notificationId = parts[0];
                    string[] dateParts = parts[6].Split(',');
                    DateTime date = new DateTime(int.Parse(dateParts[0]), int.Parse(dateParts[1]), int.Parse(dateParts[2]), int.Parse(dateParts[3]), int.Parse(dateParts[4]), int.Parse(dateParts[5]));
                    Notification notification = new Notification(parts[0], parts[4], parts[3], date, Convert.ToBoolean(parts[5]), parts[1], parts[2]);
                    notifications.Add(notification);
                }
            }
            return notifications;
        }
        public List<Notification> GetPublicNotifications()
        {
            string[] lines = System.IO.File.ReadAllLines(FileLocation);
            List<Notification> notifications = new List<Notification>();
            foreach (string line in lines)
            {
                string[] parts = line.Split(';');
                if (parts[2].Equals("")&&parts[1].Equals(""))
                {
                    String notificationId = parts[0];
                    string[] dateParts = parts[6].Split(',');
                    DateTime date = new DateTime(int.Parse(dateParts[0]), int.Parse(dateParts[1]), int.Parse(dateParts[2]), int.Parse(dateParts[3]), int.Parse(dateParts[4]), int.Parse(dateParts[5]));
                    Notification notification = new Notification(parts[0], parts[4], parts[3], date, Convert.ToBoolean(parts[5]), parts[1], parts[2]);
                    notifications.Add(notification);
                }
            }
            return notifications;
        }

        public Notification GetByID(String id)
        {
            string[] lines = System.IO.File.ReadAllLines(FileLocation);
            foreach (string line in lines)
            {
                string[] parts = line.Split(';');
                if (parts[0].Equals(id))
                {
                    String notificationId = parts[0];
                    string[] dateParts = parts[6].Split(',');
                    DateTime date = new DateTime(int.Parse(dateParts[0]), int.Parse(dateParts[1]), int.Parse(dateParts[2]), int.Parse(dateParts[3]), int.Parse(dateParts[4]), int.Parse(dateParts[5]));
                    Notification notification = new Notification(parts[0], parts[4], parts[3], date, Convert.ToBoolean(parts[5]), parts[1], parts[2]);
                    return notification;
                }
            }
            return null;
        }

        public List<Notification> GetAll()
        {
            string[] lines = System.IO.File.ReadAllLines(FileLocation);
            List<Notification> notifications = new List<Notification>();
            foreach (string line in lines)
            {
                string[] parts = line.Split(';');
                String notificationId = parts[0];
                string[] dateParts = parts[6].Split(',');
                DateTime date = new DateTime(int.Parse(dateParts[0]), int.Parse(dateParts[1]), int.Parse(dateParts[2]), int.Parse(dateParts[3]), int.Parse(dateParts[4]), int.Parse(dateParts[5]));
                Notification notification = new Notification(parts[0], parts[4], parts[3], date, Convert.ToBoolean(parts[5]), parts[1], parts[2]);
                notifications.Add(notification);
            }
            return notifications;
        }

        public Boolean Update(String id, Notification notification)
        {
            if (Delete(id))
            {
                Create(notification);
                return true;
            }

            return false;
        }

        public Boolean Delete(String id)
        {
            String[] rows = System.IO.File.ReadAllLines(FileLocation);
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

        public Boolean Read(String id)
        {
            // TODO: implement
            return false;
        }
    }
}