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
    /// Interaction logic for ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        public ReportWindow(Medicine m)
        {
            InitializeComponent();
            medicineName.Text = m.Name;
            medicineStatus.Text = m.Status.ToString();
            medicineDescription.Text = m.Description;
            medicineIngredients.Text = m.Ingredients;
            medicineAlternatives.Text = m.Alternatives;
        }
    }
}
