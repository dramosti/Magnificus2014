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
using HLP.Entries.ViewModel.ViewModels.Comercial;
using HLP.Components.View.WPF;

namespace HLP.Entries.View.WPF.Comercial
{
    /// <summary>
    /// Interaction logic for WinProduto.xaml
    /// </summary>
    public partial class WinProduto : WindowsBase
    {
        public WinProduto()
        {
            InitializeComponent();
            this.ViewModel = new ProdutoViewModel();
            base.SetEventsTabControl(tabControl: this.tbPrincipal);
        }

        public ProdutoViewModel ViewModel
        {
            get
            {
                return this.DataContext as ProdutoViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }
    }
}
