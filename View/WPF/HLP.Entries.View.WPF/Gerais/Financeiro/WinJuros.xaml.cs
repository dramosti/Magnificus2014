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
using HLP.Entries.ViewModel.ViewModels.Comercial;
using HLP.Components.View.WPF;

namespace HLP.Entries.View.WPF.GestãoAdministrativa.Financeiro
{
    /// <summary>
    /// Interaction logic for WinJuros.xaml
    /// </summary>
    public partial class WinJuros : WindowsBase
    {
        public WinJuros()
        {
            InitializeComponent();
            this.ViewModel = new JurosViewModel();
        }

        public JurosViewModel ViewModel
        {
            get
            {
                return this.DataContext as JurosViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }
    }
}
