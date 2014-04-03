using HLP.Comum.Resources.Models;
using HLP.Base.ClassesBases;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.ViewModel.Commands.Gerais;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HLP.Entries.ViewModel.ViewModels.Gerais
{
    public class siteViewModel : ViewModelBase<SiteModel>
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

        public bool bTreeCarregada = true;
        siteCommands comm;
        public BackgroundWorker bwHierarquia;

        public siteViewModel()
        {
            comm = new siteCommands(objViewModel: this);
        }

        private object _hierarquiaFunc;

        public object hierarquiaFunc
        {
            get { return _hierarquiaFunc; }
            set
            {
                _hierarquiaFunc = value;
                base.NotifyPropertyChanged(propertyName: "hierarquiaFunc");
            }
        }

        private modelToTreeView _lObjHierarquia;

        public modelToTreeView lObjHierarquia
        {
            get { return _lObjHierarquia; }
            set { _lObjHierarquia = value; }
        }

        public void MontaTreeView()
        {
            if (!bTreeCarregada)
            {
                this.comm.MontraTreeView();
            }
        }
    }
}
