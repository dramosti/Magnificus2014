using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.ViewModel.Commands;
using System.Windows.Input;
using HLP.Base.ClassesBases;
using HLP.Entries.Model.Models;
using HLP.Comum.ViewModel.ViewModel;
using System.Windows;

namespace HLP.Entries.ViewModel.ViewModels
{
    public class CidadeViewModel : viewModelComum<CidadeModel>
    {

        #region Icommands
        public ICommand commandSalvar { get; set; }
        public ICommand commandDeletar { get; set; }
        public ICommand commandNovo { get; set; }
        public ICommand commandAlterar { get; set; }
        public ICommand commandCancelar { get; set; }
        public ICommand commandPesquisar { get; set; }
        public ICommand commandCopiar { get; set; }
        public ICommand navegarCommand { get; set; }
        #endregion

        private ObservableCollection<CidadeModel> _lCidade;

        public ObservableCollection<CidadeModel> lCidade
        {
            get { return _lCidade; }
            set
            {
                _lCidade = value;
                base.NotifyPropertyChanged("lCidade");
            }
        }

        public CidadeCommands objCidadeCommands;

        public CidadeViewModel()
            : base()
        {
            bool designTime = System.ComponentModel.DesignerProperties.GetIsInDesignMode(
    new DependencyObject());

            if (!designTime)
            {
                objCidadeCommands = new CidadeCommands(objViewModel: this);
            }
        }

        public void GetCidadeByUf(int idUF)
        {
            objCidadeCommands.GetCidadeByUf(idUF: idUF);
        }
    }
}
