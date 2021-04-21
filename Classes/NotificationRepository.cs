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
            // TODO: implement
            return false;
        }

        public List<Notification> GetByPatientID(String id)
        {
            String[] rows = System.IO.File.ReadAllLines(FileLocation);
            List<Notification> notifications = new List<Notification>();
            foreach (String row in rows)
            {
                String[] data = row.Split(';');
                if (data[5].Equals(id))
                {
                    String idNotification = data[0];
                    String title = data[1];
                    String body = data[2];
                    String read = data[4];
                    Boolean readBool;
                    if (read.Equals("False"))
                    {
                        readBool = false;
                    }
                    else
                    {
                        readBool = true;
                    }
                    String patientId = data[5];
                    String doctorId = data[6];
                    String[] startParts = data[3].Split(',');
                    DateTime start = new DateTime(int.Parse(startParts[0]), int.Parse(startParts[1]), int.Parse(startParts[2]), int.Parse(startParts[3]), int.Parse(startParts[4]), int.Parse(startParts[5]));
                    Notification a = new Notification(id, title, body, start, readBool, patientId, doctorId);
                    notifications.Add(a);
                }
            }
            return notifications;
        }

        public List<Notification> GetByDoctorID(String id)
        {
            
            return null;
        }

        public Notification GetByID(String id)
        {
            // TODO: implement
            return null;
        }

        public List<Notification> GetAll()
        {
            // TODO: implement
            return null;
        }

        public Boolean Update(String id, Notification notification)
        {
            // TODO: implement
            return false;
        }

        public Boolean Delete(String id)
        {
            // TODO: implement
            return false;
        }

        public Boolean Read(String id)
        {
            // TODO: implement
            return false;
        }
    }
}