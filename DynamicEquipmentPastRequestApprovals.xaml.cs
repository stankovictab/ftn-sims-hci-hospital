using Classes;
using System.Collections.Generic;
using System.Windows;

namespace ftn_sims_hci_hospital
{
    public partial class DynamicEquipmentPastRequestApprovals : Window
    {
        public DynamicEquipmentPastRequestApprovals()
        {
            InitializeComponent();
            MainWindow.dynamicEquipmentRequestController.GetAll();

            List<DynamicEquipmentRequest> list = MainWindow.dynamicEquipmentRequestController.GetAll();
            dynamicEquipmentRequestListView.Items.Clear();
            foreach (DynamicEquipmentRequest req in list)
            {
                if (req.Status1 != DynamicEquipmentRequestStatus.OnHold)
                {
                    string doc = req.doctor.user.Name1 + " " + req.doctor.user.LastName1;
                    // Ovde treba da stoji new {...} umesto new Classes.HolidayRequest {...}? Mozda ne?
                    dynamicEquipmentRequestListView.Items.Add(new {RequestID1 = req.RequestID1, DoctorFullName1 = doc, Status1 = req.Status1, EquipmentName1 = req.EquipmentName1, RequestDate1 = req.RequestDate1, Commentary1 = req.Commentary1});
                }
            }
        }
    }
}
