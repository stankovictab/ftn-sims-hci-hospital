using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Classes;

namespace ftn_sims_hci_hospital
{
    public partial class DoctorPanel : Window
    {
        private string selectedRHID;

        public DoctorPanel()
        {
            InitializeComponent();
        }

        private void btnHolidayRequestPanel_Click(object sender, RoutedEventArgs e)
        {
            Window holidayRequestPanel = new HolidayRequestPanel();
            holidayRequestPanel.ShowDialog();
        }

        private void btnDynamicEquipmentPanel_Click(object sender, RoutedEventArgs e)
        {
            Window dynamicEquipmentRequestPanel = new DynamicEquipmentRequestPanel();
            dynamicEquipmentRequestPanel.ShowDialog();
        }
    }
}
