﻿using Classes;
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

namespace ftn_sims_hci_hospital
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
            //enschedulementController.UpdateTime(DateTime.Now);

            List<StaticEnschedulement> allEnschedulements = new List<StaticEnschedulement>();
            allEnschedulements = enschedulementController.GetAll();

            List<StaticEnschedulement> allFinishedEnschedulements = new List<StaticEnschedulement>();
            allFinishedEnschedulements = enschedulementController.GetAllFinished();

            scheduleDataList.Items.Clear();
            movedDataList.Items.Clear();
            //ciscenje fajla
            
        }

        private void staticMove_Click(object sender, RoutedEventArgs e)
        {
            Window staticMove = new StaticMove();
            staticMove.ShowDialog();
        }

        private void triggerMoveButton_Click(object sender, RoutedEventArgs e)
        {
            List <StaticEnschedulement> moved = new List<StaticEnschedulement>();
            moved = enschedulementController.DateCheck(DateTime.Parse(triggerMoveDate.Text));

            movedDataList.Items.Clear();
            foreach (StaticEnschedulement s in moved)
            {
                movedDataList.Items.Add(new { time = s.Time.ToString(), fromRoom = s.FromRoom.RoomNumber, toRoom = s.ToRoom.RoomNumber, equipment = s.MovedEquipment.statName });
                scheduleDataList.Items.Remove(new { time = s.Time.ToString(), fromRoom = s.FromRoom.RoomNumber, toRoom = s.ToRoom.RoomNumber, equipment = s.MovedEquipment.statName });
            }
        }
    }
}
