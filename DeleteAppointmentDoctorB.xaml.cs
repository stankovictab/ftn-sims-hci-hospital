﻿using Classes;
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

namespace ftn_sims_hci_hospital
{
    /// <summary>
    /// Interaction logic for DeleteAppointmentDoctorB.xaml
    /// </summary>
    public partial class DeleteAppointmentDoctorB : Window
    {
        public DeleteAppointmentDoctorB()
        {
            InitializeComponent();
        }

        private void deleteAppointment(Object sender, RoutedEventArgs e)
        {
            AppointmentFileStorage f = new AppointmentFileStorage();
            f.Delete(txtDel.Text);

        }
    }
}
