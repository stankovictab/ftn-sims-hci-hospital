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

        private void btnHolidayRequestApproval_Click(object sender, RoutedEventArgs e)
        {
            Window holidayRequestApproval = new HolidayRequestApproval();
            holidayRequestApproval.ShowDialog();
        }

        private void btnDynamicEquipmentRequestApproval_Click(object sender, RoutedEventArgs e)
        {
            Window dynamicEquipmentRequestApproval = new DynamicEquipmentRequestApproval();
            dynamicEquipmentRequestApproval.ShowDialog();
        }

        private void btnDynamicEquipmentOrderCreation_Click(object sender, RoutedEventArgs e)
        {
            Window dynamicEquipmentOrderCreation = new DynamicEquipmentOrderCreation();
            dynamicEquipmentOrderCreation.ShowDialog();
        }

        private void btnDynamicEquipmentOrderPanel_Click(object sender, RoutedEventArgs e)
        {
            Window dynamicEquipmentOrderPanel = new DynamicEquipmentOrderPanel();
            dynamicEquipmentOrderPanel.ShowDialog();
        }

        private void btnPollResults_Click(object sender, RoutedEventArgs e)
        {
            Window pollResults = new PollResultsPanel();
            pollResults.ShowDialog();
        }
    }
}
