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
using System.Windows.Shapes;
using Classes;

namespace ftn_sims_hci_hospital
{
    /// <summary>
    /// Interaction logic for NotificationCreation.xaml
    /// </summary>
    public partial class NotificationCreation : Window
    {
        public NotificationCreation()
        {
            InitializeComponent();
        }

        private void btncreatenotification_Click(object sender, RoutedEventArgs e)
        {
            string currentTitle = tbtitle.Text;
            string currentBody = tbbody.Text;
            List<Notification> allNotifications = MainWindow.notificationController.notificationService.notificationRepository.GetAll();
            string id = (Convert.ToInt32(allNotifications[allNotifications.Count()-1].Id) + 1).ToString();
            Notification newNotification = new Notification(id, currentTitle, currentBody, DateTime.Now, false, "", "");
            MainWindow.notificationController.notificationService.notificationRepository.Create(newNotification);
            MessageBox.Show("You have successfuly created a new notification!");
            this.Close();
        }
    }
}
