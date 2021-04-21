﻿using Manager;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ManagerKT3
{
    /// <summary>
    /// Interaction logic for StaticSchedule.xaml
    /// </summary>
    public partial class StaticSchedule : Window
    {
        EnschedulementController enschedulementController = new EnschedulementController();
        public StaticSchedule()
        {
            InitializeComponent();
            List<StaticEnschedulement> allEnschedulements = new List<StaticEnschedulement>();
            allEnschedulements = enschedulementController.GetAll();
            scheduleDataList.Items.Clear();
            foreach (StaticEnschedulement s in allEnschedulements)
            {
                scheduleDataList.Items.Add(new { time = s.Time.ToString(), fromRoom = s.FromRoom.RoomNumber, toRoom = s.ToRoom.RoomNumber, equipment = s.MovedEquipment.statName });
            }
        }

        private void staticMove_Click(object sender, RoutedEventArgs e)
        {
            Window staticMove = new StaticMove();
            staticMove.ShowDialog();
        }
    }
}
