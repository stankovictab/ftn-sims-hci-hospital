using System;
namespace Classes
{
    public class Secretary
    {
        public User user;
        public NotificationBoard notificationBoard;

        public Secretary()
        {
            user = new User();
            notificationBoard = new NotificationBoard();
        }
        public String SharePatientInfo()
        {
            // TODO: implement
            return null;
        }

        public Appointment CreateAppointment()
        {
            // TODO: implement
            return null;
        }

        public Boolean UpdateAppointment()
        {
            // TODO: implement
            return false;
        }

        public Boolean CancelAppointment()
        {
            // TODO: implement
            return false;
        }
    }
}