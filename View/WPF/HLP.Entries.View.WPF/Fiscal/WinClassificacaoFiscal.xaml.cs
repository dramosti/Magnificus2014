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
using HLP.Entries.ViewModel.ViewModels.Fiscal;

namespace HLP.Entries.View.WPF.Fiscal
{
    /// <summary>
    /// Interaction logic for WinClassificacaoFiscal.xaml
    /// </summary>
    public partial class WinClassificacaoFiscal : WindowsBase
    {
        public WinClassificacaoFiscal()
        {
            InitializeComponent();
            this.ViewModel = new ClassificacaoFiscalViewModel();
        }

        public ClassificacaoFiscalViewModel ViewModel
        {
            get { return this.DataContext as ClassificacaoFiscalViewModel; }
            set { this.DataContext = value; }
        }
    }
}