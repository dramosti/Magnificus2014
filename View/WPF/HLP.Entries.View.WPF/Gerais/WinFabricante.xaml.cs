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
using HLP.Entries.ViewModel.ViewModels.Gerais;
using HLP.Components.View.WPF;

namespace HLP.Entries.View.WPF.Gerais
{
    /// <summary>
    /// Interaction logic for WinFabricante.xaml
    /// </summary>
    public partial class WinFabricante : WindowsBase
    {
        public WinFabricante()
        {
            InitializeComponent();
            this.ViewModel = new FabricanteViewModel();
        }

        public FabricanteViewModel ViewModel
        {
            get
            {
                return this.DataContext as FabricanteViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }
    }
}
