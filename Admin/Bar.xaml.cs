﻿using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ftn_sims_hci_hospital.Admin
{
    public partial class Bar : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(info));
        }

        private double _value;
        public double Value
        {
            get { return _value; }
            set
            {
                _value = value;
                UpdateBarHeight();
                NotifyPropertyChanged("Value");
            }
        }

        private double maxValue;
        public double MaxValue
        {
            get { return maxValue; }
            set
            {
                maxValue = value;
                UpdateBarHeight();
                NotifyPropertyChanged("MaxValue");
            }
        }

        private double barHeight;
        public double BarHeight
        {
            get { return barHeight; }
            private set { barHeight = value; NotifyPropertyChanged("BarHeight"); }
        }

        private Brush color;
        public Brush Color
        {
            get { return color; }
            set { color = value; NotifyPropertyChanged("Color"); }
        }

        private void UpdateBarHeight()
        {
            if (maxValue > 0)
            {
                var percent = (_value * 100) / maxValue;
                BarHeight = (percent * this.ActualHeight) / 100;
            }
        }

        public Bar()
        {
            InitializeComponent();
            this.DataContext = this;
            Color = Brushes.Black;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateBarHeight();
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateBarHeight();
        }
    }
}
