﻿using System;
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
<<<<<<< HEAD
    /// <summary> //klklkl
    /// Interaction logic for PatientWindow.xaml
    /// </summary>
=======
>>>>>>> 05231df76c5a2437a5498ffa63d6b61147061b41
    public partial class PatientWindow : Window
    {
        public PatientWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AllAppointments allApp = new AllAppointments();
            allApp.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CreateAppointment c = new CreateAppointment();
            c.Show();
        }
    }
}
