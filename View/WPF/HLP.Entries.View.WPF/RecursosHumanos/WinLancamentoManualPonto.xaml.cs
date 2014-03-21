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

namespace HLP.Entries.View.WPF.RecursosHumanos
{
    /// <summary>
    /// Interaction logic for WinLancamentoManualPonto.xaml
    /// </summary>
    public partial class WinLancamentoManualPonto : Window
    {
        public WinLancamentoManualPonto()
        {
            InitializeComponent();
            this.SetDataContext(2, DateTime.Today);
        }

        public Funcionario_Controle_Horas_PontoViewModel ViewModel
        {
            get { return this.DataContext as Funcionario_Controle_Horas_PontoViewModel; }
            set { this.DataContext = value; }
        }

        public void SetDataContext(int idFuncionario, DateTime data)
        {
            this.ViewModel = new Funcionario_Controle_Horas_PontoViewModel(idFuncionario, data);
            this.pFuncionario.Text = idFuncionario.ToString();
            this.dtPonto.Text = data.ToShortDateString();

        }


    }
}
