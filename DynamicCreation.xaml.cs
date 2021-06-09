using Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for DynamicCreation.xaml
    /// </summary>
    public partial class DynamicCreation : Window, INotifyPropertyChanged
    {
        EquipmentController equipmentController = new EquipmentController();
        RoomRepository roomRepository = new RoomRepository();
        public event PropertyChangedEventHandler PropertyChanged;

        private int id;
        private int amount;

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

        public int Amount
        {
            get
            {
                return amount;
            }
            set
            {
                if (value != amount)
                {
                    amount = value;
                    OnPropertyChanged("Amount");
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

        public DynamicCreation()
        {
            InitializeComponent();
            this.DataContext = this;
            List<Room> rooms = roomRepository.GetAll();
        }

        private void dynamicAdd_Click(object sender, RoutedEventArgs e)
        {
            equipmentController.equipmentService.dynamicEquipmentRepository.DynamicEquipment = equipmentController.GetAllDynamic();
            DynamicEquipment newDynamic = new DynamicEquipment(Convert.ToInt32(dynamicId.Text), dynamicName.Text, dynamicAmount.Text);
            _ = equipmentController.AddDynamic(newDynamic);
            this.Hide();
            MessageBox.Show("Success. Press View to Refresh.");
        }
    }
}
