﻿using HLP.Components.View.WPF;
using HLP.Entries.ViewModel.ViewModels;
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

namespace HLP.Entries.View.WPF.RecursosHumanos
{
    /// <summary>
    /// Interaction logic for WinCargo.xaml
    /// </summary>
    public partial class WinCargo : WindowsBase
    {
        public WinCargo()
        {
            InitializeComponent();
            this.ViewModel = new CargoViewModel();
        }

        public CargoViewModel ViewModel
        {
            get
            {
                return this.DataContext as CargoViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }
    }
}
