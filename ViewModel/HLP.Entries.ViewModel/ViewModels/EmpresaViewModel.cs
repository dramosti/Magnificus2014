using HLP.Comum.Resources.RecursosBases;
using HLP.Comum.ViewModel.ViewModels;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HLP.Entries.ViewModel.ViewModels
{
    public class EmpresaViewModel : ViewModelBase
    {

        #region IcommandsBase
        public ICommand commandSalvarBase
        {
            get
            {
                return base.salvarBaseCommand;
            }
        }

        public ICommand commandDeletarBase
        {
            get
            {
                return base.deletarBaseCommand;
            }
        }
        public ICommand commandNovoBase
        {
            get
            {
                return base.novoBaseCommand;
            }
        }
        public ICommand commandAlterarBase
        {
            get
            {
                return base.alterarBaseCommand;
            }
        }
        public ICommand commandCancelarBase
        {
            get
            {
                return base.cancelarBaseCommand;
            }
        }
        #endregion


        #region Icommands
        public ICommand commandSalvar { get; set; }
        public ICommand commandDeletar { get; set; }
        public ICommand commandNovo { get; set; }
        public ICommand commandAlterar { get; set; }
        public ICommand commandCancelar { get; set; }
        #endregion

        public List<int> lItensExcluidos = new List<int>();

        public EmpresaViewModel()
        {
            EmpresaCommands com = new EmpresaCommands(objViewModel: this);
            com.Pesquisar(1);            
        }

        private void CollectionChangedMethod(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (Empresa_EnderecoModel item in e.NewItems)
                {
                    item.status = statusModel.criado;
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (Empresa_EnderecoModel item in e.OldItems)
                {
                    lItensExcluidos.Add(item: (int)item.idEmpresaEndereco);
                }
            }
        }

        private EmpresaModel _currentModel;

        public EmpresaModel currentModel
        {
            get { return _currentModel; }
            set
            {
                _currentModel = value;
                if (value != null)
                    _currentModel.lEmpresa_endereco.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedMethod);
                base.NotifyPropertyChanged(propertyName: "currentModel");
            }
        }

    }
}
