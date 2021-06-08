using Classes;
using System;
using System.Collections.Generic;
using System.Windows;

namespace ftn_sims_hci_hospital.Admin
{
    public partial class AdminManagerReportPDF : Window
    {
        public AdminManagerReportPDF(DateTime start, DateTime end, List<DynamicEquipmentRequest> list)
        {
            InitializeComponent();
            issuedBy.Content = "Mihajlo Mihajlovic"; // TODO: Ovo stoji ovako dok ne proradi log in
            dateIssued.Content = DateTime.Now.ToString();

            dynamicEquipmentRequestListView.Items.Clear();
            foreach (DynamicEquipmentRequest req in list)
            {
                string doc = req.doctor.user.Name1 + " " + req.doctor.user.LastName1;
                dynamicEquipmentRequestListView.Items.Add(new { RequestID1 = req.ID1, DoctorFullName1 = doc, Status1 = req.Status1, EquipmentName1 = req.EquipmentName1, RequestDate1 = req.CreationDate1, Commentary1 = req.Commentary1 });
            }
        }
    }
}
