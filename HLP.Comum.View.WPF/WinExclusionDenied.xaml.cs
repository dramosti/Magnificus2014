﻿using HLP.ComumView.ViewModel.ViewModel;
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

namespace HLP.Comum.View.WPF
{
    /// <summary>
    /// Interaction logic for WinExclusionDenied.xaml
    /// </summary>
    public partial class WinExclusionDenied : Window
    {
        public WinExclusionDenied()
        {
            InitializeComponent();
            this.DataContext = new messageDeleteNotAllowedFK();
        }
    }
}
