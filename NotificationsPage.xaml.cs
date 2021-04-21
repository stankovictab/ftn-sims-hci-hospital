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
            List<Notification> notifications = notificationController.GetByPatientID(PatientWindow.user.Jmbg1);
            notificationTable.ItemsSource = notifications;
        }
    }
}
