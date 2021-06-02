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
    /// Interaction logic for SecretaryViewDoctor.xaml
    /// </summary>
    public partial class SecretaryViewDoctor : Window
    {
        private Doctor currentDoctor=new Doctor();
        public SecretaryViewDoctor(String id)
        {
            InitializeComponent();
            currentDoctor = MainWindow.doctorController.GetByID(id);
            initTextBoxes();
            initShifts();
        }

        private void initTextBoxes()
        {
            tbfirstname.Text = currentDoctor.user.Name1;
            tblastname.Text = currentDoctor.user.LastName1;
            tbgender.Text = currentDoctor.user.Gender1.ToString();
            tbjmbg.Text = currentDoctor.user.Jmbg1;
            tbspecialization.Text = currentDoctor.specialization.ToString();
        }

        private void initShifts()
        {
            cbshift.Items.Add(Shift.MORNING);
            cbshift.Items.Add(Shift.AFTERNOON);
            cbshift.SelectedIndex = Convert.ToInt32(currentDoctor.shift);
        }

        private void btnsave_Click(object sender, RoutedEventArgs e)
        {
            currentDoctor.shift = (Shift)cbshift.SelectedIndex;
            MainWindow.doctorController.Update(currentDoctor);
            MessageBox.Show("You have successfuly saved your changes!");
            this.Close();
        }
    }
}
