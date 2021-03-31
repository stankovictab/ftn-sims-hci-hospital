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
    /// Interaction logic for AppointmentsListDoctorB.xaml
    /// </summary>
    
    public partial class AppointmentsListDoctorB : Window
    {
        public AppointmentsListDoctorB()
        {

            InitializeComponent();
            AppointmentFileStorage f = new AppointmentFileStorage();
            List<Appointment> appointments = f.GetAllByDoctorID("123");
            


            lvUsers.ItemsSource = appointments;

        }
    }
}
