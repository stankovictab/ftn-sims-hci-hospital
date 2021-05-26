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
using Classes;

namespace ftn_sims_hci_hospital
{
    
    public partial class MedicineList : Window
    {
        MedicineCotroller medicineController;
        Medicine medicineForUpadate;
        Medicine medicineForDelete;
        public MedicineList()
        {
            InitializeComponent();
            medicineController = new MedicineCotroller();
            List<Medicine> medicines = medicineController.GetAll();

            medicinesView.ItemsSource = medicines;
        }

        private void showUpdateCanvas(object sender, RoutedEventArgs e)
        {
            medicineForUpadate = (Medicine)medicinesView.SelectedItem;
            medicineName.Text = medicineForUpadate.Name;
            medicineDescription.Text = medicineForUpadate.Description;

            updateCanvas.Visibility = Visibility.Visible;
        }

        private void saveChanges(object sender, RoutedEventArgs e)
        {
            medicineForUpadate.Name = medicineName.Text;
            medicineForUpadate.Description = medicineDescription.Text;

            medicineController.Update(medicineForUpadate);
        }

        private void reloadMedicineList(object sender, RoutedEventArgs e)
        {
            List<Medicine> medicines = medicineController.GetAll();
            medicinesView.ItemsSource = medicines;

            updateCanvas.Visibility = Visibility.Hidden;
            declineCanvas.Visibility = Visibility.Hidden;
        }

        private void deleteMedicine(object sender, RoutedEventArgs e)
        {
            medicineController.Decline(medicineForDelete);
        }

        private void declineMedicine(object sender, RoutedEventArgs e)
        {
            medicineForDelete = (Medicine)medicinesView.SelectedItem;
            if (medicineForDelete.Status == MedicineStatus.OnHold)
                declineCanvas.Visibility = Visibility.Visible;
            else
                MessageBox.Show("already verified!");
        }

        
        private void approveMedicine(object sender, RoutedEventArgs e)
        {
            Medicine medicineForApprove = (Medicine)medicinesView.SelectedItem;
            if (medicineForApprove.Status == MedicineStatus.OnHold)
            {
                medicineController.Approve(medicineForApprove);
            } else
                MessageBox.Show("already verified!");

        }
    }
}
