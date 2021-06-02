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
using System.Windows.Shapes;

namespace ftn_sims_hci_hospital
{
    /// <summary>
    /// Interaction logic for BasicRenovations.xaml
    /// </summary>
    public partial class BasicRenovations : Window
    {
        BasicRenovationController basicRenovationController = new BasicRenovationController();

        public BasicRenovations()
        {
            InitializeComponent();
            //basicRenovationController.UpdateTime(DateTime.Now);

            List<BasicRenovation> allRenovations = basicRenovationController.GetAll();
            
        }

        private void addBasicRenovation_Click(object sender, RoutedEventArgs e)
        {
            Window basicRenovationCreation = new BasicRenovationCreation();
            basicRenovationCreation.ShowDialog();
        }

        private void viewBasicRenovations_Click(object sender, RoutedEventArgs e)
        {
            List<BasicRenovation> allBasicRenovations = new List<BasicRenovation>();
            allBasicRenovations = basicRenovationController.GetAll();
            basicRenovationDataList.Items.Clear();
            foreach (BasicRenovation r in allBasicRenovations)
            {
                basicRenovationDataList.Items.Add(new { renovationId = r.Id.ToString(), renovationRoom = r.Room.RoomNumber, renovationTime = r.DateTime.ToString(), renovationDuration = r.Duration.ToString() });
            }
        }

        private void deleteBasicRenovation_Click(object sender, RoutedEventArgs e)
        {
            if (!basicRenovationDataList.Items.IsEmpty && basicRenovationDataList.SelectedItem != null)
            {
                string[] parts = basicRenovationDataList.SelectedItem.ToString().Split(',');
                string[] parts2 = parts[0].Split(' ');
                int toDelete = Convert.ToInt32(parts2[3]);
                _ = basicRenovationController.Delete(toDelete);
                basicRenovationController.UpdateFile(basicRenovationController.basicRenovationService.basicRenovationRepository.AccessBasicRenovations);
                viewBasicRenovations.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));

            }
        }

    }
}
