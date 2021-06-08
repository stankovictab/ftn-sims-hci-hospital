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
    /// Interaction logic for SecretaryCreateDoctor.xaml
    /// </summary>
    public partial class SecretaryCreateDoctor : Window
    { 
        private List<Room> rooms = new List<Room>();
        public SecretaryCreateDoctor()
        {
            InitializeComponent();
            initShifts();
            initSpecializations();
            initRooms();
        }

        private void initShifts()
        {
            cbshift.Items.Add(Shift.MORNING);
            cbshift.Items.Add(Shift.AFTERNOON);
        }

        private void initSpecializations()
        {
            cbspecialization.Items.Add(DoctorSpecialization.GeneralPractice);
            cbspecialization.Items.Add(DoctorSpecialization.Specialist);
        }

        private void initRooms()
        {
            rooms = MainWindow.roomController.GetAll();
            foreach (Room room in rooms)
            {
                cbroom.Items.Add(room.RoomNumber1);
            }
        }

        private void btncreate_Click(object sender, RoutedEventArgs e)
        {
            if(tbname.Text!=""&&tblastname.Text!=""&&tbjmbg.Text!=""&& tbusername.Text != "" && tbpassword.Text != "" &&cbshift.SelectedItem!=null&&cbspecialization.SelectedItem!=null&&cbroom.SelectedItem!=null)
            {
                Doctor newDoctor = createDoctor();
                bool fleg = validateNewDoctor(newDoctor);
                if (!fleg)
                {
                    MainWindow.doctorController.Create(newDoctor);
                    MessageBox.Show("You have successfuly created a new account!");
                    this.Close();
                }
            }
        }

        private static bool validateNewDoctor(Doctor newDoctor)
        {
            List<Doctor> doctors = MainWindow.doctorController.GetAll();
            bool fleg = false;
            foreach (Doctor doctor in doctors)
            {
                if (newDoctor.user.Jmbg1.Equals(doctor.user.Jmbg1))
                {
                    MessageBox.Show("An account with the same id(jmbg) already exists!");
                    fleg = true;
                    break;
                }
                if (newDoctor.user.Username1.Equals(doctor.user.Username1))
                {
                    MessageBox.Show("An account with the same username already exists!");
                    fleg = true;
                    break;
                }
            }

            return fleg;
        }

        private Doctor createDoctor()
        {
            Room room = MainWindow.roomController.GetById(cbroom.SelectedItem.ToString());
            User user = new User(tbname.Text, tblastname.Text, tbusername.Text, tbpassword.Text, "", tbjmbg.Text, "", 'N', false, Roles.Doctor, false);
            Doctor newDoctor = new Doctor(user, room, (DoctorSpecialization)cbspecialization.SelectedItem, null, null, null, null);
            newDoctor.shift = (Shift)cbshift.SelectedItem;
            return newDoctor;
        }
    }
}
