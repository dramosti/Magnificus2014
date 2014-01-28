using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Model.Models;
using HLP.Entries.Model.Models.Comercial;
using HLP.Comum.ViewModel.ViewModels;
using HLP.Entries.ViewModel.Commands.Gerais;
using System.Windows.Input;
using HLP.Entries.Model.Models.Gerais;

namespace HLP.Entries.ViewModel.ViewModels.Gerais
{
    public class AtribuicaoColetivaListaPrecoViewModel : ViewModelBase<CalendarioModel>
    {
        public ICommand commAplicarAtribuicaoColetiva { get; set; }


        private decimal _valor;

        public decimal valor
        {
            get { return _valor; }
            set
            {
                _valor = value;
                base.NotifyPropertyChanged(propertyName: "valor");
            }
        }

        
        private int _selectedIndex;
        
        public int selectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                _selectedIndex = value;
                base.NotifyPropertyChanged(propertyName: "selectedIndex");
            }
        }
        

        public AtribuicaoColetivaListaPrecoViewModel()
        {
            AtribuicaoColetivaListaPrecoCommands comm = new AtribuicaoColetivaListaPrecoCommands(objViewModel: this);
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