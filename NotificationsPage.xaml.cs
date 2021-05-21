using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ftn_sims_hci_hospital
{
    /// <summary>
    /// Interaction logic for NotificationsPage.xaml
    /// </summary>
    public partial class NotificationsPage : Page
    {
        NotificationController notificationController;
        public NotificationsPage()
        {
            InitializeComponent();
            notificationController = new NotificationController();
            List<Notification> notifications = notificationController.GetByPatientID(MainWindow.user.Jmbg1);
            //notificationTable.ItemsSource = notifications;
            foreach(Notification notification in notifications)
            {
                notificationTable.Items.Add(new Notification
                {
                    Id = notification.Id,
                    Title = notification.Title,
                    Body = notification.Body,
                    Date = notification.Date,
                    Read = notification.Read,
                    PatientId = notification.PatientId,
                    DoctorId = notification.DoctorId
                });
            }
        }
    }
}
