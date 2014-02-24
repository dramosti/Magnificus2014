﻿using HLP.Sales.ViewModel.ViewModel.Comercio;
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

namespace HLP.Sales.View.WPF.Comercial
{
    /// <summary>
    /// Interaction logic for StatusItensOrcamento.xaml
    /// </summary>
    public partial class StatusItensOrcamento : Window
    {
        public StatusItensOrcamento()
        {
            InitializeComponent();
            this.ViewModel = new OrcamentoConfirmarViewModel();
        }

        public OrcamentoConfirmarViewModel ViewModel
        {
            get
            {
                return this.DataContext as OrcamentoConfirmarViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }
    }
}
