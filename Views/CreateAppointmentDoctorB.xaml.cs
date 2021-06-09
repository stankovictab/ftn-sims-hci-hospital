using Classes;
using System;
using System.Collections.Generic;
using System.Windows;
using ftn_sims_hci_hospital;
using ftn_sims_hci_hospital.Views;

namespace Views
{
    public partial class CreateAppointmentDoctorB : Window
    {
        StaticEquipmentRepository staticEquipmentRepository;
        RoomController roomController = new RoomController();
        ReferralRepository referralRepository = new ReferralRepository();
        AppointmentController appointmentController = new AppointmentController();
        AppointmentType type;
        Patient patient;
        public List<Doctor> doctors {get; set;}
        public CreateAppointmentDoctorB(Patient patient)
        {
            this.patient = patient;
            InitializeComponent();
            staticEquipmentRepository = new StaticEquipmentRepository();
            fillDoctors();
        }

        public void createAppointment(Object sender, RoutedEventArgs e)
        {
            if (radioOperation.IsChecked == true || radioRegular.IsChecked == true)
            {
                AppointmentController f = new AppointmentController();

                string[] endTxt = txtE.Text.Split(':');
                Random random = new Random();

                if ((bool)radioOperation.IsChecked)
                {
                    if (!(bool)radioMe.IsChecked)
                        MessageBox.Show("You can't create refferal for operation for other doctor.", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.No);
                    else
                    {
                        appointmentController.CreateAppointment(MainWindow.user.Jmbg1, patient.user.Jmbg1, getStart(), getEnd(), 0, ((Room)rooms.SelectedItem).RoomNumber1);
                    }
                }

                if ((bool)radioRegular.IsChecked)
                {
                    if ((bool)radioMe.IsChecked)
                        appointmentController.CreateAppointment(MainWindow.user.Jmbg1, patient.user.Jmbg1, getStart(), getEnd(), 1, ((Room)rooms.SelectedItem).RoomNumber1);

                    else
                    {
                        referralRepository.Create(new Referral((random.Next(1, 1000)).ToString(), MainWindow.user.Jmbg1, patient.user.Jmbg1, txtD.Text, getValidUntil(), false));
                    }
                }
            }
            else
            {
                MessageBox.Show("Choose apointment type!");
            }
        }

        private void radioOperation_Checked(object sender, RoutedEventArgs e)
        {
            
            List<Room> roomList = roomController.GetAll();

            btnRoomDetails.Visibility = Visibility.Visible;
            rooms.ItemsSource = roomList;
        }

        private void showRoomEquipment(object sender, RoutedEventArgs e)
        {
           
            Room room = (Room)rooms.SelectedItem;
            List<StaticEquipment> equipmentInRoom = staticEquipmentRepository.GetByLocation(room);

            string message = room.RoomNumber + ":";
            foreach(StaticEquipment equipment in equipmentInRoom){
                message += "\n" + equipment.statName; 
            }

            MessageBox.Show(message, "Room equipment");
         
        }

        private void radioRegular_Checked(object sender, RoutedEventArgs e)
        {
            rooms.ItemsSource = new List<Room>();
            btnRoomDetails.Visibility = Visibility.Hidden;
        }

        private DateTime getStart()
        {
            DateTime dateWpf = (DateTime) date.SelectedDate;
            string[] startTxt = txtS.Text.Split(':');
            return new DateTime(dateWpf.Year, dateWpf.Month, dateWpf.Day, int.Parse(startTxt[0]) , int.Parse(startTxt[1]), 0); 
        }

        private DateTime getEnd()
        {
            DateTime dateWpf = (DateTime)date.SelectedDate;
            string[] startTxt = txtE.Text.Split(':');
            return new DateTime(dateWpf.Year, dateWpf.Month, dateWpf.Day, int.Parse(startTxt[0]), int.Parse(startTxt[1]), 0);
        }
        private DateTime getValidUntil()
        {
            DateTime dateWpf = (DateTime)validUntil.SelectedDate;
            return new DateTime(dateWpf.Year, dateWpf.Month, dateWpf.Day, 23, 59, 59);
        }

        private void radioMe_Checked(object sender, RoutedEventArgs e)
        {
            canvasMe.Visibility = Visibility.Visible;
            canvasOther.Visibility = Visibility.Hidden;
        }

        private void fillDoctors()
        {
            DoctorRepository doctorRepository = new DoctorRepository();
            doctors = doctorRepository.GetAll();
            this.DataContext = this;
        }
    }
}
