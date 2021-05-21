using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Classes;

namespace ftn_sims_hci_hospital
{
    public partial class HolidayRequestPastApprovals : Window
    {
        public HolidayRequestPastApprovals()
        {
            InitializeComponent();
            MainWindow.holidayRequestController.GetAll();

            List<HolidayRequest> list = MainWindow.holidayRequestController.GetAll();
            holidayRequestListView.Items.Clear();
            foreach (HolidayRequest req in list)
            {
                if (req.Status1 != HolidayRequestStatus.OnHold)
                {
                    string doc = req.doctor.user.Name1 + " " + req.doctor.user.LastName1;
                    // Ovde treba da stoji new {...} umesto new Classes.HolidayRequest {...}? Mozda ne?
                    holidayRequestListView.Items.Add(new { RequestID1 = req.RequestID1, DoctorFullName1 = doc, Status1 = req.Status1, Description1 = req.Description1, StartDate1 = req.StartDate1, EndDate1 = req.EndDate1, RequestDate1 = req.RequestDate1, Commentary1 = req.Commentary1});
                }
            }
        }
    }
}
