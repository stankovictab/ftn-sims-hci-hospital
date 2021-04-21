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

namespace ManagerKT3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void _static_Click(object sender, RoutedEventArgs e)
        {
            Window Static = new Static();
            Static.ShowDialog();
        }

        private void dynamic_Click(object sender, RoutedEventArgs e)
        {
            Window Dynamic = new Dynamic();
            Dynamic.ShowDialog();
        }

        private void rooms_Click(object sender, RoutedEventArgs e)
        {
            Window Rooms = new Rooms();
            Rooms.ShowDialog();
        }

        private void staticMove_Click(object sender, RoutedEventArgs e)
        {
            Window StaticSchedule = new StaticSchedule();
            StaticSchedule.ShowDialog();
        }

    }
}
