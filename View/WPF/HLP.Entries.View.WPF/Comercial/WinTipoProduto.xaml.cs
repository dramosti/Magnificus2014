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

namespace HLP.Entries.View.WPF.Gerais
{
    /// <summary>
    /// Interaction logic for WinTipoProduto.xaml
    /// </summary>
    public partial class WinTipoProduto : WindowsBase
    {
        public WinTipoProduto()
        {
            InitializeComponent();
            this.ViewModel = new Tipo_ProdutoViewModel();
        }

        public Tipo_ProdutoViewModel ViewModel
        {
            get
            {
                return this.DataContext as Tipo_ProdutoViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }
    }
}
