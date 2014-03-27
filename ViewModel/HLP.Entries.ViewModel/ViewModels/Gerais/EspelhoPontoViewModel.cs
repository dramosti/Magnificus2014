using HLP.Comum.ViewModel.ViewModels;
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
    public class EspelhoPontoViewModel : ViewModelBase<FuncionarioPonto>
    {
        #region Icommands
        public ICommand commandPesquisar { get; set; }
        public ICommand navegarCommand { get; set; }
        public ICommand carregarCommand { get; set; }
        public ICommand commandAlterar { get; set; }
        #endregion

        public List<Control> lControlsPonto { get; set; }
        public EspelhoPontoCommand command;


        public EspelhoPontoViewModel(List<Control> lControlsPonto)
        {
            this.currentModel = new FuncionarioPonto();
            this.lControlsPonto = lControlsPonto;
            command = new EspelhoPontoCommand(this);
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
            get { return _SetimoDia;  }
            set { _SetimoDia = value; this.NotifyPropertyChanged("SetimoDia"); }
        }
        
        
        
        
    }
}
