using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Classes;

namespace ftn_sims_hci_hospital.Admin
{
    public partial class AdminPanel : Window
    {
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void Doctor_Click(object sender, RoutedEventArgs e)
        {
            Window window = new AdminDoctorPanel();
            this.Close();
            window.ShowDialog();
        }

        private void Manager_Click(object sender, RoutedEventArgs e)
        {
            Window window = new AdminManagerPanel();
            this.Close();
            window.ShowDialog();
        }
    }
}
