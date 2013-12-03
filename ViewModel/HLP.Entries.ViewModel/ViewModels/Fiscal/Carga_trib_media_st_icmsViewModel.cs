using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HLP.Comum.ViewModel.ViewModels;
using HLP.Entries.Model.Models.Fiscal;
using HLP.Entries.ViewModel.Commands.Fiscal;

namespace HLP.Entries.ViewModel.ViewModels.Fiscal
{
    public class Carga_trib_media_st_icmsViewModel : ViewModelBase
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
        #endregion


        Carga_trib_media_st_icmsCommand commands;
        public Carga_trib_media_st_icmsViewModel() 
        {
            commands = new Carga_trib_media_st_icmsCommand(objViewModel: this);
        }
        
        private Carga_trib_media_st_icmsModel _currentModel;

        public Carga_trib_media_st_icmsModel currentModel
        {
            get { return _currentModel; }
            set
            {
                _currentModel = value;
                base.NotifyPropertyChanged(propertyName: "currentModel");
            }
        }
        
    }
}
