using System;
using System.Collections.Generic;

namespace Classes
{
    public class NotificationController
    {
        public NotificationService notificationService;

        public NotificationController()
        {
            notificationService = new NotificationService();
        }

        public Boolean Create(String patientID, String doctorID, String title, String body)
        {
            // TODO: implement
            return false;
        }

        public List<Notification> GetByPatientID(String id)
        {
            List<Notification> notifications = notificationService.GetByPatientID(id);
            return notifications;
        }

        public Notification GetByDoctorID(String id)
        {
            // TODO: implement
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

        public Boolean Update(String id, String title, String body)
        {
            // TODO: implement
            return false;
        }

        public Boolean Delete(String id)
        {
            // TODO: implement
            return false;
        }
    }
}