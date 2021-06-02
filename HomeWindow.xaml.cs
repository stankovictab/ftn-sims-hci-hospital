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
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        public HomeWindow()
        {
            InitializeComponent();
            initMenu();
            menu.SelectedItem = menu.Items[0];
            updateDoctorsList();
        }

        private void initMenu()
        {
            menu.Items.Add("Home");
            menu.Items.Add("Your Profile");
            menu.Items.Add("Patients");
            menu.Items.Add("Appointments");
            menu.Items.Add("Notifications");
            menu.Items.Add("Exchange Patient Info");
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
                case 4:
                    Window notifications = new NotificationBoard();
                    this.Hide();
                    notifications.ShowDialog();
                    this.Close();
                    break;

            }
        }

        private void btncreatedoctor_Click(object sender, RoutedEventArgs e)
        {
            Window secretaryCreateDoctor = new SecretaryCreateDoctor();
            secretaryCreateDoctor.ShowDialog();
            doctorData.Items.Clear();
            updateDoctorsList();
        }

        private void btnviewdoctor_Click(object sender, RoutedEventArgs e)
        {
            if (!doctorData.Items.IsEmpty)
            {
                if (doctorData.SelectedItem != null)
                {
                    Doctor selectedDoctor = (Doctor)doctorData.SelectedItem;
                    String id = selectedDoctor.user.Jmbg1;
                    Window doctorView = new SecretaryViewDoctor(id);
                    doctorView.ShowDialog();
                    doctorData.Items.Clear();
                    updateDoctorsList();
                }
            }
        }

        private void updateDoctorsList()
        {
            List<Doctor> allDoctors = MainWindow.doctorController.GetAll();
            foreach (Doctor doctor in allDoctors)
            {
                doctorData.Items.Add(new Doctor { user = doctor.user, specialization = doctor.specialization });
            }
        }

        private void btndeletedoctor_Click(object sender, RoutedEventArgs e)
        {
            if (!doctorData.Items.IsEmpty)
            {
                if (doctorData.SelectedItem != null)
                {
                    String id = ((Doctor)doctorData.SelectedItem).user.Jmbg1;
                    MainWindow.doctorController.Delete(id);
                    MessageBox.Show("You have successfuly deleted a doctor!");
                    doctorData.Items.Clear();
                    updateDoctorsList();
                }
            }
        }
    }
}
