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
using HLP.Comum.View.Formularios;
using HLP.Entries.ViewModel.ViewModels.Financeiro;

namespace HLP.Entries.View.WPF.Gerais.Financeiro
{
    /// <summary>
    /// Interaction logic for WinContaBancaria.xaml
    /// </summary>
    public partial class WinContaBancaria : WindowsBase
    {
        public WinContaBancaria()
        {
            InitializeComponent();
            ViewModel = new Conta_BancariaViewModel();
        }

        public Conta_BancariaViewModel ViewModel
        {
            get
            {
                return this.DataContext as Conta_BancariaViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }
    }
}
