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
using HLP.Entries.ViewModel.ViewModels.Fiscal;
using HLP.Components.View.WPF;

namespace HLP.Entries.View.WPF.Fiscal
{
    /// <summary>
    /// Interaction logic for WinCfop.xaml
    /// </summary>
    public partial class WinCfop : WindowsBase
    {
        public WinCfop()
        {
            InitializeComponent();
            this.ViewModel = new CfopViewModel();

        }
        public CfopViewModel ViewModel
        {
            get { return this.DataContext as CfopViewModel; }
            set { this.DataContext = value; }
        }
    }
}
