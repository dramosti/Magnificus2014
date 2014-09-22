using HLP.Base.ClassesBases;
using HLP.Comum.ViewModel.ViewModel;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.ViewModel.Commands.Gerais;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace HLP.Entries.ViewModel.ViewModels.Gerais
{
    public class EspelhoPontoViewModel : viewModelComum<FuncionarioPonto>
    {
        #region Icommands
        public ICommand commandSalvar { get; set; }
        public ICommand commandDeletar { get; set; }
        public ICommand commandNovo { get; set; }
        public ICommand commandAlterar { get; set; }
        public ICommand commandCancelar { get; set; }
        public ICommand commandCopiar { get; set; }
        public ICommand commandPesquisar { get; set; }
        public ICommand navegarCommand { get; set; }
        public ICommand commandImprimir { get; set; }


        public ICommand carregarCommand { get; set; }
        public ICommand commandFecharMes { get; set; }
        public ICommand commandReabrirMes { get; set; }
        public ICommand commandNavegaData { get; set; }
        public ICommand CorrigirSaidaCommand { get; set; }


        #endregion

        public List<Control> lControlsPonto { get; set; }
        public EspelhoPontoCommand command;
        public Button btnCarregar { get; set; }

        public EspelhoPontoViewModel(List<Control> lControlsPonto, Button btnCarregar)
        {            
            this.lControlsPonto = lControlsPonto;
            this.btnCarregar = btnCarregar;
            command = new EspelhoPontoCommand(this);
            this.bIsEnabled = true;
        }
        public EspelhoPontoViewModel()
        {
        }

        private string _PrimeiroDia;
        public string PrimeiroDia
        {
            get { return _PrimeiroDia; }
            set { _PrimeiroDia = value; this.NotifyPropertyChanged("PrimeiroDia"); }
        }

        private string _SegundoDia;
        public string SegundoDia
        {
            get { return _SegundoDia; }
            set { _SegundoDia = value; this.NotifyPropertyChanged("SegundoDia"); }
        }

        private string _TerceiroDia;
        public string TerceiroDia
        {
            get { return _TerceiroDia; }
            set { _TerceiroDia = value; this.NotifyPropertyChanged("TerceiroDia"); }
        }

        private string _QuartoDia;
        public string QuartoDia
        {
            get { return _QuartoDia; }
            set { _QuartoDia = value; this.NotifyPropertyChanged("QuartoDia"); }
        }

        private string _QuintoDia;
        public string QuintoDia
        {
            get { return _QuintoDia; }
            set { _QuintoDia = value; this.NotifyPropertyChanged("QuintoDia"); }
        }

        private string _SextoDia;
        public string SextoDia
        {
            get { return _SextoDia; }
            set { _SextoDia = value; this.NotifyPropertyChanged("SextoDia"); }
        }

        private string _SetimoDia;
        public string SetimoDia
        {
            get { return _SetimoDia; }
            set { _SetimoDia = value; this.NotifyPropertyChanged("SetimoDia"); }
        }


        //private TimeSpan? _tsBancoHorasFechado = null;
        //public TimeSpan? tsBancoHorasFechado
        //{
        //    get { return _tsBancoHorasFechado; }
        //    set { _tsBancoHorasFechado = value; }
        //}


    }
}
