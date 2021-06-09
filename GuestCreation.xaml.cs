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
    /// Interaction logic for GuestCreation.xaml
    /// </summary>
    public partial class GuestCreation : Window
    {
        public GuestCreation()
        {
            InitializeComponent();
        }

        private void btnregister_Click(object sender, RoutedEventArgs e)
        {
            string name = tbfirstname.Text;
            string lastname = tblastname.Text;
            string jmbg = tbjmbg.Text;
            User user = new User(name, lastname, "guest" + (++MainWindow.guestCounter).ToString(), "hcihospital","", jmbg, "", 'N', false, Roles.Patient);
            Patient patient = new Patient(user, null, null, null);
            if (!MainWindow.patientController.Create(patient))
            {
                MessageBox.Show("There already is a patient with that JMBG!");
            }
            else 
            { 
                MessageBox.Show("You have successfully created a new account!");
            }
            this.Close();
        }
    }
}
