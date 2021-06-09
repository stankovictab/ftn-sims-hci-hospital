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
using ViewModels;

namespace ftn_sims_hci_hospital.Views
{
    /// <summary>
    /// Interaction logic for RoomEquipment.xaml
    /// </summary>
    public partial class RoomEquipment : Page
    {
        private RoomEquipmentViewModel viewModel;
        public RoomEquipment()
        {
            viewModel = new RoomEquipmentViewModel();
            InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}
