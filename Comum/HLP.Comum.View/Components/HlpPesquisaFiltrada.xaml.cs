using HLP.Components.ViewModel.ViewModels;
using HLP.Comum.Resources.Util;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HLP.Comum.View.Components
{
    /// <summary>
    /// Interaction logic for HlpPesquisaFiltrada.xaml
    /// </summary>
    public partial class HlpPesquisaFiltrada : Window
    {
        public HlpPesquisaFiltrada()
        {
            InitializeComponent();
            this.ViewModel = new HlpPesquisaFiltradaViewModel();
        }

        public HlpPesquisaFiltradaViewModel ViewModel
        {
            get
            {
                return this.DataContext as HlpPesquisaFiltradaViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void FocusCellInicial(DataGrid dgv)
        {
            DataGridRow row = dgv.ItemContainerGenerator.ContainerFromIndex(0) as DataGridRow;
            if (row != null)
            {
                DataGridCell cell = StaticUtil.GetCell(grid: dgv, row: row, column: 2);
                if (cell != null)
                {
                    cell.Focus();
                    cell.IsEditing = true;
                }
            }
        }

        private void wdPesquisa_Loaded(object sender, RoutedEventArgs e)
        {
            this.FocusCellInicial(dgv: this.dgvFilter);
        }

    }
}
