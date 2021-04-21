using System;
using System.Collections.Generic;

namespace Classes
{
    public class NotificationService
    {
        public NotificationRepository notificationRepository=new NotificationRepository();

        public Boolean Create(String patientID, String doctorID, String title, String body)
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

        public Boolean Read(String id)
        {
            // TODO: implement
            return false;
        }
    }
}