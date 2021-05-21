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
    /// Interaction logic for SecretaryPatients.xaml
    /// </summary>
    public partial class SecretaryPatients : Window
    {
        public SecretaryPatients()
        {
            InitializeComponent();
            menu.Items.Add("Home");
            menu.Items.Add("Your Profile");
            menu.Items.Add("Patients");
            menu.Items.Add("Appointments");
            menu.Items.Add("Notifications");
            menu.Items.Add("Exchange Patient Info");
            menu.SelectedItem = menu.Items[2];
            btnlistallpatients.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
        }

        private void btncreatepatient_Click(object sender, RoutedEventArgs e)
        {
            Window patientCreation = new PatientCreation();
            patientCreation.ShowDialog();
            btnlistallpatients.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
        }

        private void btnlistallpatients_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.patientController.patientService.patientRepository.PatientsInFile1 = MainWindow.patientController.GetAll();
            patientData.Items.Clear();
            foreach (Patient p in MainWindow.patientController.patientService.patientRepository.PatientsInFile1)
            {
                patientData.Items.Add(new User { Name1 = p.user.Name1, LastName1 = p.user.LastName1, Jmbg1 = p.user.Jmbg1, Username1 = p.user.Username1, Password1 = p.user.Password1 });
            }
        }

        private void btnviewpatient_Click(object sender, RoutedEventArgs e)
        {
            if (!patientData.Items.IsEmpty)
            {
                if (patientData.SelectedItem != null)
                {
                    User user = (User)patientData.SelectedItem;
                    String id = user.Jmbg1;
                    Window patientView = new PatientView(id);
                    patientView.ShowDialog();
                    btnlistallpatients.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                }
            }
        }

        private void btndeletepatient_Click(object sender, RoutedEventArgs e)
        {
            if (!patientData.Items.IsEmpty)
            {
                if (patientData.SelectedItem != null)
                {
                    User user = (User)patientData.SelectedItem;
                    MainWindow.patientController.Delete(user.Jmbg1);
                    MainWindow.patientController.UpdateAll(MainWindow.patientController.patientService.patientRepository.PatientsInFile1);
                    btnlistallpatients.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                }
            }
        }

        private void btnguest_Click(object sender, RoutedEventArgs e)
        {
            Window guestCreation = new GuestCreation();
            guestCreation.ShowDialog();
            btnlistallpatients.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
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
                    break;
                case 3:
                    Window appointments = new SecretaryAppointments();
                    this.Hide();
                    appointments.ShowDialog();
                    this.Close();
                    break;
                case 4:
                    Window notifications = new NotificationBoard();
                    this.Hide();
                    notifications.ShowDialog();
                    this.Close();
                    break;


            }
        }
    }
}
