/***********************************************************************
 * Module:  NotificationBoard.cs
 * Author:  Mihajlo
 * Purpose: Definition of the Class NotificationBoard
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.IO;

namespace Classes
{
   public class NotificationBoard
   {
      public System.Collections.ArrayList notifications;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetNotifications()
      {
         if (notifications == null)
            notifications = new System.Collections.ArrayList();
         return notifications;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetNotifications(System.Collections.ArrayList newNotifications)
      {
         RemoveAllNotifications();
         foreach (Notification oNotification in newNotifications)
            AddNotifications(oNotification);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddNotifications(Notification newNotification)
      {
         if (newNotification == null)
            return;
         if (this.notifications == null)
            this.notifications = new System.Collections.ArrayList();
         if (!this.notifications.Contains(newNotification))
            this.notifications.Add(newNotification);
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveNotifications(Notification oldNotification)
      {
         if (oldNotification == null)
            return;
         if (this.notifications != null)
            if (this.notifications.Contains(oldNotification))
               this.notifications.Remove(oldNotification);
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllNotifications()
      {
         if (notifications != null)
            notifications.Clear();
      }
   
   }
}