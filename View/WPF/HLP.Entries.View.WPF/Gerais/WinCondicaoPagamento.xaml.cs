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

namespace HLP.Entries.View.WPF.GestãoAdministrativa.Financeiro
{
    /// <summary>
    /// Interaction logic for WinCondicaoPagamento.xaml
    /// </summary>
    public partial class WinCondicaoPagamento : WindowsBase
    {
        public WinCondicaoPagamento()
        {
            InitializeComponent();
            this.ViewModel = new Condicao_PagamentoViewModel();
            this.gridPrincipal.KeyUp += base.Window_KeyUp;
        }

        public Condicao_PagamentoViewModel ViewModel
        {
            get
            {
                return this.DataContext as Condicao_PagamentoViewModel;
            }
            set
            {
                this.DataContext = value;
            }

        }
    }
}
