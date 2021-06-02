using Classes;
using System;
using System.Collections.Generic;
using System.Windows;

namespace ftn_sims_hci_hospital
{
    public partial class CreateAppointmentDoctorB : Window
    {
        StaticEquipmentRepository staticEquipmentRepository;
        AppointmentType type;
        public CreateAppointmentDoctorB()
        {
            InitializeComponent();
            staticEquipmentRepository = new StaticEquipmentRepository();
        }

        public void createAppointment(Object sender, RoutedEventArgs e)
        {
            if(radioOperation.IsChecked == true || radioRegular.IsChecked == true) { 
                AppointmentController f = new AppointmentController();
                string[] startTxt = txtS.Text.Split(':');
                string[] date = txtD.Text.Split('.');
                string[] endTxt = txtE.Text.Split(':');
                Random random = new Random();
                int type;

                if(radioRegular.IsChecked == true)
                {
                    type = 0;
                }
                else { type = 1; }

                DateTime start = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]), int.Parse(startTxt[0]), int.Parse(startTxt[1]), int.Parse(startTxt[2]));
                DateTime end = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]), int.Parse(endTxt[0]), int.Parse(endTxt[1]), int.Parse(endTxt[2]));
                
                
                if(radioRegular.IsChecked == true)
                    f.CreateAppointment(MainWindow.user.Jmbg1, txtP.Text, start, end, type, "217");  

                if(radioOperation.IsChecked == true)
                {
                    Room room = (Room)rooms.SelectedItem;
                    f.CreateAppointment(MainWindow.user.Jmbg1, txtP.Text, start, end, type, room.RoomNumber1);
                }

            }else
            {
                MessageBox.Show("Choose apointment type!");
            }
        }

        private void radioOperation_Checked(object sender, RoutedEventArgs e)
        {
            RoomController roomController = new RoomController();
            List<Room> roomList = roomController.GetAll();

            btnRoomDetails.Visibility = Visibility.Visible;
            rooms.ItemsSource = roomList;
            rooms.Visibility = Visibility.Visible;
        }

        private void showRoomEquipment(object sender, RoutedEventArgs e)
        {
            Room room = (Room)rooms.SelectedItem;
            List<StaticEquipment> equipmentInRoom = staticEquipmentRepository.GetByLocation(room);

            string message = room.RoomNumber + ":";
            foreach(StaticEquipment equipment in equipmentInRoom){
                message += "\n" + equipment.statName; 
            }

            MessageBox.Show(message);

        }

        private void radioRegular_Checked(object sender, RoutedEventArgs e)
        {
            rooms.Visibility = Visibility.Hidden;
            btnRoomDetails.Visibility = Visibility.Hidden;
        }
    }
}
