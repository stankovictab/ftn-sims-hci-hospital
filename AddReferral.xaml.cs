using Classes;
using Models;
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
    /// Interaction logic for AddReferral.xaml
    /// </summary>
    public partial class AddReferral : Window
    {
        private Patient choosedPatient;
        private ReferralRepository referralRepository;
        private RoomController roomController;
        private StaticEquipmentRepository staticEquipmentRepository;
        private HospitalizationReferalRepository hospitalizationReferalRepository;
        public List<Room> rooms { get; set; }
        public List<StaticEquipment> beds { get; set; }
        
        public AddReferral(Patient patient)
        {
            InitializeComponent();
            referralRepository = new ReferralRepository();
            roomController = new RoomController();
            staticEquipmentRepository = new StaticEquipmentRepository();
            hospitalizationReferalRepository = new HospitalizationReferalRepository();
            
            choosedPatient = patient;

            fillRooms();
        }

        private void createReferral(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            int id = rnd.Next(1, 1000);

            //Referral newReferral = new Referral(id.ToString(),MainWindow.user.Jmbg1,choosedPatient.user.Jmbg1,txtDescription.Text,(DateTime)durationDate.SelectedDate, false);
            //referralRepository.Create(newReferral);
        }

        private void createHosReferral(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            Room room = getRoom();
            
            HospitalizationReferal hospitalizationReferal = new HospitalizationReferal(random.Next(1, 1000).ToString(), choosedPatient, txtDescription.Text, getStart() , getEnd() , room, getBed());
            hospitalizationReferalRepository.Create(hospitalizationReferal);
        }

        private DateTime getStart()
        {
            DateTime date = (DateTime)startDate.SelectedDate;
            DateTime start = new DateTime(date.Year, date.Month, date.Day, 12, 0, 0);
            return start;
        }

        private DateTime getEnd()
        {
            DateTime date = (DateTime) endDate.SelectedDate;
            DateTime end = new DateTime(date.Year, date.Month, date.Day, 12, 0, 0);
            return end;
        }

        private int getBed()
        {
            StaticEquipment bed = (StaticEquipment) bedsComboBox.SelectedItem;
            return bed.statId;
        }
        public void fillRooms()
        {
            rooms = roomController.GetAll();
            this.DataContext = this;
        }

        public void fillBeds(object sender, RoutedEventArgs e)
        {

            String roomString = roomsComboBox.SelectedItem.ToString();
            String[] components = roomString.Split('-');
            Room room = roomController.GetById(components[0]);

            beds = staticEquipmentRepository.GetByLocation(room);
            bedsComboBox.ItemsSource = beds;
            
        }

        private Room getRoom()
        {
            String roomString = roomsComboBox.SelectedItem.ToString();
            String[] components = roomString.Split('-');
            Room room = new Room();
            room.RoomNumber = components[0];
            return room;
        }
        
    }
}
