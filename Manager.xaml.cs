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
using Classes;

namespace ftn_sims_hci_hospital
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Manager : Window
    {
        EnschedulementController enschedulementController = new EnschedulementController();
        BasicRenovationController basicRenovationController = new BasicRenovationController();
        public Manager()
        {
            InitializeComponent();
        }

        private void _static_Click(object sender, RoutedEventArgs e)
        {
            Window Static = new Static();
            Static.ShowDialog();
        }

        private void dynamic_Click(object sender, RoutedEventArgs e)
        {
            Window Dynamic = new Dynamic();
            Dynamic.ShowDialog();
        }

        private void rooms_Click(object sender, RoutedEventArgs e)
        {
            Window Rooms = new Rooms();
            Rooms.ShowDialog();
        }

        private void staticMove_Click(object sender, RoutedEventArgs e)
        {
            Window StaticSchedule = new StaticSchedule();
            StaticSchedule.ShowDialog();
        }
        private void medicine_Click(object sender, RoutedEventArgs e)
        {
            Window medicine = new MedicineWindow();
            medicine.ShowDialog();
        }

        private void storage_Click(object sender, RoutedEventArgs e)
        {
            Window storage = new Storage();
            storage.ShowDialog();
        }

        private void basicRenovations_Click(object sender, RoutedEventArgs e)
        {
            Window basicRenovations = new BasicRenovations();
            basicRenovations.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window advancedRenovations = new AdvancedRenovations();
            advancedRenovations.ShowDialog();
        }
    }
}
