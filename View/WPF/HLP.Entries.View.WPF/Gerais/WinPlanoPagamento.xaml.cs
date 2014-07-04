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
using HLP.Entries.ViewModel.ViewModels.Gerais;
using HLP.Components.View.WPF;
using HLP.Components.View.WPF.Converter;

namespace HLP.Entries.View.WPF.GestãoAdministrativa.Financeiro
{
    /// <summary>
    /// Interaction logic for WinPlanoPagamento.xaml
    /// </summary>
    public partial class WinPlanoPagamento : WindowsBase
    {
        public WinPlanoPagamento()
        {
            InitializeComponent();
            this.ViewModel = new PlanoPagamentoViewModel();
        }

        public PlanoPagamentoViewModel ViewModel
        {
            get
            {
                return this.DataContext as PlanoPagamentoViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }

        //Private Sub CmbSchedule_SelectionChanged(ByVal sender As Object, ByVal e As SelectionChangedEventArgs)
        private void CollStTipo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Binding="{Binding Path=nValorouPorcentagem, UpdateSourceTrigger=PropertyChanged}" 

            if ((sender as ComboBox).SelectedIndex < 0)
            {
                return;
            }

            Binding b = new Binding();

            b.Path = new PropertyPath(path: "nValorouPorcentagem", pathParameters: new object[] { });
            b.UpdateSourceTrigger = UpdateSourceTrigger.LostFocus;

            if ((sender as ComboBox).SelectedIndex == 0)
                b.Converter = new PorcentagemConverter();
            else if ((sender as ComboBox).SelectedIndex == 1)
                b.Converter = new MoedaConverter();

            //txtCollValorPorcentagem.Binding = b;
        }
    }
}
