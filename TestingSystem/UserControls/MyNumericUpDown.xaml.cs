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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestingSystem.UserControls
{
    /// <summary>
    /// Interaction logic for MyNumericUpDown.xaml
    /// </summary>
    public partial class MyNumericUpDown : UserControl, INotifyPropertyChanged
    {
        public MyNumericUpDown()
        {
            Value = "0,5";
            InitializeComponent();
            DataContext = this;
        }

        private string _value;
        public string Value 
        { 
            get { return _value; } 
            set
            {
                _value = value;
                OnPropertyChanged(nameof(Value));
            }
        }
        
        private void IncreaseButton_Click(object sender, RoutedEventArgs e)
        {
            double temp = double.Parse(Value) + 0.5;
            Value = temp.ToString();
        }

        private void DecreaseButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.Parse(Value) > 0.5)
            {
                double temp = double.Parse(Value) - 0.5;
                Value = temp.ToString();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
