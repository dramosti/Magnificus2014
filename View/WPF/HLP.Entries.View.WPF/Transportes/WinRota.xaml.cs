﻿using System;
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
using HLP.Entries.ViewModel.ViewModels.Transportes;
using HLP.Components.View.WPF;

namespace HLP.Entries.View.WPF.GestãoDeLogística
{
    /// <summary>
    /// Interaction logic for WinRota.xaml
    /// </summary>
    public partial class WinRota : WindowsBase
    {
        public WinRota()
        {
            InitializeComponent();
            this.ViewModel = new RotaViewModel();
        }

        public RotaViewModel ViewModel
        {
            get { return this.DataContext as RotaViewModel; }
            set { this.DataContext = value; }
        }
    }
}
