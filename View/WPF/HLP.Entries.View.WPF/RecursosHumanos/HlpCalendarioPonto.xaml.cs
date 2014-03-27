using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.ViewModel.Services.Gerais;
using HLP.Entries.ViewModel.ViewModels.Gerais;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HLP.Entries.View.WPF.RecursosHumanos
{
    /// <summary>
    /// Interaction logic for HlpCalendarioPonto.xaml
    /// </summary>
    public partial class HlpCalendarioPonto : UserControl
    {
        public HlpCalendarioPonto()
        {
            InitializeComponent();
            this.ViewModel = new HlpCalendarioPontoViewModel();
              
        }

        private int _idFuncionario;
        public int idFuncionario
        {
            get { return _idFuncionario; }
            set { _idFuncionario = value; this.ViewModel.idFuncionario = value; }
        }

        private string _dtPonto;
        public string dtPonto
        {
            get { return _dtPonto; }
            set { _dtPonto = value; this.ViewModel.dataPonto = value; }
        }

        public HlpCalendarioPontoViewModel ViewModel
        {
            get { return this.DataContext as HlpCalendarioPontoViewModel; }
            set { this.DataContext = value; }
        }
        public void CarregaDados()
        {
            if (this.ViewModel.command != null)
                this.ViewModel.command.CarregaDados();
        }

        public TimeSpan totalHoras { get { return this.ViewModel.hTotal; } }

        public void RefreshWindowPrincipal(Action method) 
        {
            this.ViewModel.actionAtualizaWindowPrincipal = method;
        }

    }
}
