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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ftn_sims_hci_hospital
{
    /// <summary>
    /// Interaction logic for AdvancedRenovationsPage.xaml
    /// </summary>
    public partial class AdvancedRenovationsPage : Page
    {
        AdvancedRenovationController advancedRenovationController = new AdvancedRenovationController();
        RoomController roomController = new RoomController();

        public AdvancedRenovationsPage()
        {
            InitializeComponent();
            //advancedRenovationController.UpdateTimeMerge(DateTime.Now);
            //advancedRenovationController.UpdateTimeSplit(DateTime.Now);
        }

        private void createMergeRenovationButton_Click(object sender, RoutedEventArgs e)
        {
            Window mergeRenovationCreation = new MergeRenovationCreation();
            mergeRenovationCreation.ShowDialog();
        }

        private void deleteAdvancedRenovationButton_Click(object sender, RoutedEventArgs e)
        {
            if (!advancedRenovationDataList.Items.IsEmpty && advancedRenovationDataList.SelectedItem != null)
            {
                string[] parts = advancedRenovationDataList.SelectedItem.ToString().Split(',');

                string[] parts2 = parts[0].Split(' ');
                int renovationToDelete = Convert.ToInt32(parts2[3]);

                string[] parts3 = parts[4].Split(' ');
                string roomToDelete1 = parts3[3];
                if (parts3[4] != "}")
                {
                    string roomToDelete2 = parts3[4];
                    _ = roomController.Delete(roomToDelete2);
                    roomController.UpdateFile(roomController.roomService.roomRepository.Rooms);
                }


                _ = advancedRenovationController.DeleteMerge(renovationToDelete);
                _ = advancedRenovationController.DeleteSplit(renovationToDelete);
                _ = roomController.Delete(roomToDelete1);
                advancedRenovationController.UpdateFileMerge(advancedRenovationController.advancedRenovationService.advancedMergeRenovationRepository.MergeRenovations);
                advancedRenovationController.UpdateFileSplit(advancedRenovationController.advancedRenovationService.advancedSplitRenovationRepository.SplitRenovations);
                roomController.UpdateFile(roomController.roomService.roomRepository.Rooms);
                viewAdvancedRenovations.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));

            }
        }

        private void viewAdvancedRenovations_Click(object sender, RoutedEventArgs e)
        {
            List<MergeRenovation> allMergeRenovations = new List<MergeRenovation>();
            allMergeRenovations = advancedRenovationController.GetAllMerge();
            List<SplitRenovation> allSplitRenovations = new List<SplitRenovation>();
            allSplitRenovations = advancedRenovationController.GetAllSplit();
            advancedRenovationDataList.Items.Clear();
            foreach (MergeRenovation mr in allMergeRenovations)
            {
                advancedRenovationDataList.Items.Add(new { renovationId = mr.Id.ToString(), renovationStartTime = mr.StartTime.ToString(), renovationEndTime = mr.EndTime.ToString(), renovationUnavailableRooms = mr.OldRoom1.RoomNumber + " " + mr.OldRoom2.RoomNumber, renovationNewRooms = mr.NewRoom.RoomNumber });
            }

            foreach (SplitRenovation sr in allSplitRenovations)
            {
                advancedRenovationDataList.Items.Add(new { renovationId = sr.Id.ToString(), renovationStartTime = sr.StartTime.ToString(), renovationEndTime = sr.EndTime.ToString(), renovationUnavailableRooms = sr.OldRoom.RoomNumber, renovationNewRooms = sr.NewRoom1.RoomNumber + " " + sr.NewRoom2.RoomNumber });
            }
        }

        private void createSplitRenovationButton_Click(object sender, RoutedEventArgs e)
        {
            Window splitRenovationCreation = new SplitRenovationCreation();
            splitRenovationCreation.ShowDialog();
        }

        private void inventoryButton_Click(object sender, RoutedEventArgs e)
        {
            StoragePage inventoryPage = new StoragePage();
            this.Content = new Frame() { Content = inventoryPage };
        }

        private void roomsButton_Click(object sender, RoutedEventArgs e)
        {
            RoomsPage roomPage = new RoomsPage();
            this.Content = new Frame() { Content = roomPage };
        }

        private void scheduleButton_Click(object sender, RoutedEventArgs e)
        {
            StaticSchedulePage schedulePage = new StaticSchedulePage();
            this.Content = new Frame() { Content = schedulePage };
        }

        private void basicRenovationsButton_Click(object sender, RoutedEventArgs e)
        {
            BasicRenovationsPage page = new BasicRenovationsPage();
            this.Content = new Frame() { Content = page };
        }

        private void advancedRenovationsButton_Click(object sender, RoutedEventArgs e)
        {
            AdvancedRenovationsPage page = new AdvancedRenovationsPage();
            this.Content = new Frame() { Content = page };
        }

        private void profilButton_Click(object sender, RoutedEventArgs e)
        {
            ProfilePage page = new ProfilePage();
            this.Content = new Frame() { Content = page };
        }

        private void medicineMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MedicineWindowPage page = new MedicineWindowPage();
            this.Content = new Frame() { Content = page };
        }

        private void signoutButton_Click(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Close();
        }
    }
}
