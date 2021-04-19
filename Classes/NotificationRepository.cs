using System;
using System.Collections.Generic;

namespace Classes
{
    public class NotificationRepository
    {
        private String FileLocation;
        private List<Notification> NotificationsInFile;

        public Boolean Create(Notification notification)
        {
            // TODO: implement
            return false;
        }

        public Notification GetByPatientID(String id)
        {
            // TODO: implement
            return null;
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