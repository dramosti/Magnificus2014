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
using HLP.Entries.ViewModel.ViewModels.Crm;
using HLP.Components.View.WPF;


namespace HLP.Entries.View.WPF.Crm
{
    /// <summary>
    /// Interaction logic for WinPersonalidade.xaml
    /// </summary>
    public partial class WinPersonalidade : WindowsBase
    {
        public WinPersonalidade()
        {
            InitializeComponent();
            this.viewModel = new PersonalidadeViewModel();
        }

        public PersonalidadeViewModel viewModel
        {
            get
            {
                return this.DataContext as PersonalidadeViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }
    }
}
