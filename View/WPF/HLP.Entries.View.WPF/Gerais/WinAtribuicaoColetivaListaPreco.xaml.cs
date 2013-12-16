using HLP.Comum.Resources.Util;
using HLP.Entries.ViewModel.ViewModels.Gerais;
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

namespace HLP.Entries.View.WPF.Gerais
{
    /// <summary>
    /// Interaction logic for WinAtribuicaoColetivaListaPreco.xaml
    /// </summary>
    public partial class WinAtribuicaoColetivaListaPreco : Window
    {
        public WinAtribuicaoColetivaListaPreco()
        {
            InitializeComponent();
            this.ViewModel = new AtribuicaoColetivaListaPrecoViewModel();
        }

        public AtribuicaoColetivaListaPrecoViewModel ViewModel
        {
            get
            {
                return this.DataContext as AtribuicaoColetivaListaPrecoViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }

        private void cbSelDesTudo_Click(object sender, RoutedEventArgs e)
        {
            object cell;
            if (gridItens.ItemsSource != null)
            {
                foreach (object i in this.gridItens.ItemsSource)
                {
                    DataGridRow r = this.gridItens.ItemContainerGenerator.ContainerFromItem(item: i) as DataGridRow;

                    if (r != null)
                    {
                        cell = StaticUtil.GetCell(this.gridItens, r, 0);
                        ((CheckBox)((DataGridCell)cell).Content).IsChecked = this.cbSelDesTudo.IsChecked;
                    }
                }
            };
        }

        private void HlpComboBox_UCSelectionChanged(object sender, RoutedEventArgs e)
        {
            this.gridItens.Columns[2].Visibility =
                this.gridItens.Columns[3].Visibility =
                this.gridItens.Columns[4].Visibility =
                this.gridItens.Columns[5].Visibility =
                this.gridItens.Columns[6].Visibility =
                this.gridItens.Columns[7].Visibility = System.Windows.Visibility.Hidden;

            txtPor.Caption = "Por";
            txtPor.Width = 100;
            txtPor.WidthLabel = 50;

            switch (this.cbxCampos.SelectedIndex)
            {
                case 0:
                    {
                        this.gridItens.Columns[2].Visibility = System.Windows.Visibility.Visible;
                    } break;
                case 1:
                    {
                        this.gridItens.Columns[3].Visibility = System.Windows.Visibility.Visible;
                    } break;
                case 2:
                    {
                        this.gridItens.Columns[4].Visibility = System.Windows.Visibility.Visible;
                    } break;
                case 3:
                    {
                        this.gridItens.Columns[5].Visibility = System.Windows.Visibility.Visible;
                    } break;
                case 4:
                    {
                        this.gridItens.Columns[6].Visibility = System.Windows.Visibility.Visible;
                        txtPor.Caption = "Porcentagem de Aumento";
                        txtPor.Width = 250;
                        txtPor.WidthLabel = 200;
                    } break;
                case 5:
                    {
                        this.gridItens.Columns[7].Visibility = System.Windows.Visibility.Visible;
                        txtPor.Caption = "Porcentagem de Aumento";
                        txtPor.Width = 250;
                        txtPor.WidthLabel = 200;
                    } break;
            }
        }
    }
}
