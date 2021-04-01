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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btde_Click(object sender, RoutedEventArgs e)
        {
            Window doctorEpanel = new DoctorEPanel();
            doctorEpanel.ShowDialog();
        }
        private void bts_Click(object sender, RoutedEventArgs e) {
            Window secretaryWindow = new Secretary();
            this.Hide();
            secretaryWindow.ShowDialog();
            this.Show();
        }
        private void patientClick(object sender, RoutedEventArgs e)
        {
            PatientWindow win1 = new PatientWindow();
            win1.Show();
        }
    }
}
