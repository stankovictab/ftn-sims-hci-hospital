using Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for SplitInventoryIntoRooms.xaml
    /// </summary>
    public partial class SplitInventoryIntoRooms : Window
    {
        EquipmentController equipmentController = new EquipmentController();
        Point startPoint = new Point();
        Room oldRoom = new Room();
        Room newRoom1 = new Room();
        Room newRoom2 = new Room();

        public SplitInventoryIntoRooms(Room or, Room nr1, Room nr2)
        {
            InitializeComponent();
            storageDataList1.Items.Clear();
            this.DataContext = this;

            List<StaticEquipment> allStatic = new List<StaticEquipment>();
            allStatic = equipmentController.GetAllStatic();
            List<StaticEquipment> list = new List<StaticEquipment>();

            foreach (StaticEquipment s in allStatic)
            {
                if (s.statLocation == or.RoomNumber)
                    storageDataList1.Items.Add(new { equipmentId = s.statId, equipmentName = s.statName, equipmentType = "Static" });
            }

            newRoomLabel1.Content = nr1.RoomNumber;
            newRoomLabel2.Content = nr2.RoomNumber;

            oldRoom = or;
            newRoom1 = nr1;
            newRoom2 = nr2;
        }

        private void storageDataList1_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }

        private void storageDataList1_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                // Get the dragged ListViewItem
                ListView listView = sender as ListView;
                ListViewItem listViewItem =
                FindAncestor<ListViewItem>((DependencyObject)e.OriginalSource);

                if (listViewItem == null) return;

                string[] components2 = listViewItem.ToString().Split('=');
                string[] components3 = components2[1].Split(',');
                string id = components3[0];
                id = id.Trim();
                // string id = listViewItem.DataContext
                StaticEquipment staticEquipment = equipmentController.GetStaticById(id);

                // Initialize the drag & drop operation
                DataObject dragData = new DataObject("myFormat", staticEquipment);
                DragDrop.DoDragDrop(listViewItem, dragData, DragDropEffects.Move);
            }
        }

        private static T FindAncestor<T>(DependencyObject current) where T : DependencyObject
        {
            do
            {
                if (current is T)
                {
                    return (T)current;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            while (current != null);
            return null;
        }

        private void newRoomStorage1_DragOver(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("myFormat") || e.Source == sender)
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void newRoomStorage1_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("myFormat"))
            {
                StaticEquipment eq = e.Data.GetData("myFormat") as StaticEquipment;
                equipmentController.DeleteStatic(eq.statId.ToString());
                eq.statLocation = newRoom1.RoomNumber;
                equipmentController.AddStatic(eq);

                List<StaticEquipment> allStatic = equipmentController.GetAllStatic();
                storageDataList1.Items.Clear();
                foreach (StaticEquipment s in allStatic)
                {
                    if (s.statLocation == oldRoom.RoomNumber)
                        storageDataList1.Items.Add(new { equipmentId = s.statId, equipmentName = s.statName, equipmentType = "Static" });
                    else if(s.statLocation == newRoom1.RoomNumber)
                        newRoomStorage1.Items.Add(new { equipmentId = s.statId, equipmentName = s.statName, equipmentType = "Static" });
                }
            }
        }

        private void newRoomStorage2_DragOver(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("myFormat") || e.Source == sender)
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void newRoomStorage2_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("myFormat"))
            {
                StaticEquipment eq = e.Data.GetData("myFormat") as StaticEquipment;
                equipmentController.DeleteStatic(eq.statId.ToString());
                eq.statLocation = newRoom2.RoomNumber;
                equipmentController.AddStatic(eq);

                List<StaticEquipment> allStatic = equipmentController.GetAllStatic();
                storageDataList1.Items.Clear();
                foreach (StaticEquipment s in allStatic)
                {
                    if (s.statLocation == oldRoom.RoomNumber)
                        storageDataList1.Items.Add(new { equipmentId = s.statId, equipmentName = s.statName, equipmentType = "Static" });
                    else if (s.statLocation == newRoom1.RoomNumber)
                        newRoomStorage2.Items.Add(new { equipmentId = s.statId, equipmentName = s.statName, equipmentType = "Static" });
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ManagerNew window = new ManagerNew();
            window.ShowDialog();
        }
    }
}
