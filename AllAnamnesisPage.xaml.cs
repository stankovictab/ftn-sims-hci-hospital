using Classes;
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
    public partial class AllAnamnesisPage : Page
    {
        private AnamnesisRepository anamnesisRepository;
        public AllAnamnesisPage()
        {
            anamnesisRepository = new AnamnesisRepository();
            InitializeComponent();
            anamnesisTable.ItemsSource = anamnesisRepository.GetAllByPatientId(MainWindow.user.Jmbg1);
        }
    }
}
