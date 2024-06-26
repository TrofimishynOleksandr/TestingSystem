﻿using System;
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
    /// Interaction logic for GroupSelectItem.xaml
    /// </summary>
    public partial class GroupSelectItem : UserControl
    {
        public GroupSelectItem()
        {
            InitializeComponent();
            DataContext = this;
        }

        public GroupSelectItem(string text, bool isSelected)
        {
            Text = text;
            IsSelected = isSelected;
            InitializeComponent();
            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Text { get; set; }
        public bool IsSelected { get; set; }
    }
}
