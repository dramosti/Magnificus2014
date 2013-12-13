using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Model.Models;
using HLP.Entries.Model.Models.Comercial;
using HLP.Comum.ViewModel.ViewModels;
using HLP.Entries.ViewModel.Commands.Gerais;

namespace HLP.Entries.ViewModel.ViewModels.Gerais
{
    public class AtribuicaoColetivaListaPrecoViewModel : ViewModelBase
    {
        public AtribuicaoColetivaListaPrecoViewModel()
        {
        }

        private ObservableCollectionBaseCadastros<Lista_precoModel> _currentList;

        public ObservableCollectionBaseCadastros<Lista_precoModel> currentList
        {
            get { return _currentList; }
            set
            {
                _currentList = value;
                base.NotifyPropertyChanged(propertyName: "currentList");
            }
        }
    }
}