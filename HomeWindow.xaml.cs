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

namespace ftn_sims_hci_hospital
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        public HomeWindow()
        {
            InitializeComponent();
            menu.Items.Add("Home");
            menu.Items.Add("Your Profile");
            menu.Items.Add("Patients");
            menu.Items.Add("Appointments");
            menu.Items.Add("Notifications");
            menu.Items.Add("Exchange Patient Info");
            menu.SelectedItem = menu.Items[0];
        }
        private void menu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            int index = menu.SelectedIndex;
            switch (index)
            {
                case 0:
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


            }
        }
    }
}
