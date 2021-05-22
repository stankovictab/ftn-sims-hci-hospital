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
    /// Interaction logic for UpdateNotification.xaml
    /// </summary>
    public partial class UpdateNotification : Window
    {
        public Notification currentNotification = new Notification();
        public UpdateNotification(String id)
        {
            InitializeComponent();
            currentNotification = MainWindow.notificationController.notificationService.notificationRepository.GetByID(id);
            tbbody.Text = currentNotification.Body;
            tbtitle.Text = currentNotification.Title;
        }

        private void btnupdatenotification_Click(object sender, RoutedEventArgs e)
        {
            currentNotification.Title = tbtitle.Text;
            currentNotification.Body = tbbody.Text;
            currentNotification.Date = DateTime.Now;
            MainWindow.notificationController.notificationService.notificationRepository.Update(currentNotification.Id,currentNotification);
            MessageBox.Show("You have successfully updated the notification!");
            this.Close();
        }
    }
}
