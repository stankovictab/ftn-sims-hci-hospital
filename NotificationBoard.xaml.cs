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
    /// Interaction logic for NotificationBoard.xaml
    /// </summary>
    public partial class NotificationBoard : Window
    {
        public Secretary currentUser=new Secretary();
        public NotificationBoard()
        {
            InitializeComponent();
            menu.Items.Add("Home");
            menu.Items.Add("Your Profile");
            menu.Items.Add("Patients");
            menu.Items.Add("Appointments");
            menu.Items.Add("Notifications");
            menu.Items.Add("Exchange Patient Info");
            menu.SelectedItem = menu.Items[4];
            btnlistallnotifications.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
        }

        private void menu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = menu.SelectedIndex;
            switch (index)
            {
                case 0:
                    Window home = new HomeWindow();
                    this.Hide();
                    home.ShowDialog();
                    this.Close();
                    break;
                case 1:
                    Window profile = new ProfileWindow();
                    this.Hide();
                    profile.ShowDialog();
                    this.Close();
                    break;
                case 2:
                    Window patients = new SecretaryPatients();
                    this.Hide();
                    patients.ShowDialog();
                    this.Close();
                    break;
                case 3:
                    Window appointments = new SecretaryAppointments();
                    this.Hide();
                    appointments.ShowDialog();
                    this.Close();
                    break;
                case 4:
                    break;


            }
        }

        private void btncreatenotification_Click(object sender, RoutedEventArgs e)
        {
            Window notificationCreation = new NotificationCreation();
            notificationCreation.ShowDialog();
            btnlistallnotifications.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
        }

        private void btndeletenotification_Click(object sender, RoutedEventArgs e)
        {
            if (!notificationData.Items.IsEmpty)
            {
                if (notificationData.SelectedItem != null)
                {
                    Notification currentNotification = (Notification)notificationData.SelectedItem;
                    MainWindow.notificationController.notificationService.notificationRepository.Delete(currentNotification.Id);
                    btnlistallnotifications.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                }
            }
        }

        private void btnlistallnotifications_Click(object sender, RoutedEventArgs e)
        {
            currentUser.notificationBoard.Notifications = MainWindow.notificationController.notificationService.notificationRepository.GetPublicNotifications();
            notificationData.Items.Clear();
            foreach (Notification n in currentUser.notificationBoard.Notifications)
            {
                notificationData.Items.Add(new Notification(n.Id,n.Title,n.Body,n.Date,n.Read,n.PatientId,n.DoctorId));
            }
        }

        private void btnviewnotification_Click(object sender, RoutedEventArgs e)
        {
            if (!notificationData.Items.IsEmpty)
            {
                if (notificationData.SelectedItem != null)
                {
                    Notification currentNotification = (Notification)notificationData.SelectedItem;
                    String id = currentNotification.Id;
                    Window updateNotification = new UpdateNotification(id);
                    updateNotification.ShowDialog();
                    btnlistallnotifications.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                }
            }
        }
    }
}
