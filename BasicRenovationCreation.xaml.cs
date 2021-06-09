using Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for BasicRenovationCreation.xaml
    /// </summary>
    public partial class BasicRenovationCreation : Window, INotifyPropertyChanged
    {
        RoomController roomController = new RoomController();
        BasicRenovationController basicRenovationController = new BasicRenovationController();
        public event PropertyChangedEventHandler PropertyChanged;

        private int id;
        private int duration;

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                if (value != id)
                {
                    id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        public int Duration
        {
            get
            {
                return duration;
            }
            set
            {
                if (value != duration)
                {
                    duration = value;
                    OnPropertyChanged("Duration");
                }
            }
        }

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public BasicRenovationCreation()
        {
            InitializeComponent();
            this.DataContext = this;
            List<Room> rooms = roomController.roomService.roomRepository.GetAll();
            foreach (Room r in rooms)
            {
                renovatedRoomCombo.Items.Add(r.RoomNumber);
            }
        }

        private void createBasicRenovation_Click(object sender, RoutedEventArgs e)
        {
            basicRenovationController.basicRenovationService.basicRenovationRepository.BasicRenovations = basicRenovationController.GetAll();
            BasicRenovation newBasicRenovation = new BasicRenovation(Convert.ToInt32(renovationIdTextbox.Text), roomController.GetById(renovatedRoomCombo.SelectedItem.ToString()), Convert.ToDateTime(renovationTime.Text), Convert.ToInt32(durationTextbox.Text));
            bool success = basicRenovationController.Create(newBasicRenovation);
            
            if (!success)
                MessageBox.Show("Room is already busy at that time!");
            
            this.Hide();
            MessageBox.Show("Success. Press View to Refresh.");
        }
    }
}
