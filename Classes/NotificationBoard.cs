namespace Classes
{
    public class NotificationBoard
    {
        public System.Collections.ArrayList notifications;

        public System.Collections.ArrayList GetNotifications()
        {
            if (notifications == null)
                notifications = new System.Collections.ArrayList();
            return notifications;
        }

        public void SetNotifications(System.Collections.ArrayList newNotifications)
        {
            RemoveAllNotifications();
            foreach (Notification oNotification in newNotifications)
                AddNotifications(oNotification);
        }

        public void AddNotifications(Notification newNotification)
        {
            if (newNotification == null)
                return;
            if (this.notifications == null)
                this.notifications = new System.Collections.ArrayList();
            if (!this.notifications.Contains(newNotification))
                this.notifications.Add(newNotification);
        }

        public void RemoveNotifications(Notification oldNotification)
        {
            if (oldNotification == null)
                return;
            if (this.notifications != null)
                if (this.notifications.Contains(oldNotification))
                    this.notifications.Remove(oldNotification);
        }

        public void RemoveAllNotifications()
        {
            if (notifications != null)
                notifications.Clear();
        }

    }
}