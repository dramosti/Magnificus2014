using HLP.Base.ClassesBases;
using HLP.Comum.ViewModel.ViewModel;
using HLP.Sales.Model.Models.Comercial;
using HLP.Sales.ViewModel.Commands.Comercio;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HLP.Sales.ViewModel.ViewModel.Comercio
{
    public class OrcamentoItensRepresentanteViewModel : viewModelComum<Orcamento_Item_RepresentantesModel>
    {
        public ICommand applyCommand { get; set; }

        OrcamentoItensRepresentanteCommands comm;
        public OrcamentoItensRepresentanteViewModel(object lRepresentantes)
        {
            comm = new OrcamentoItensRepresentanteCommands(objViewModel: this);

            if (lRepresentantes != null)
                this.orcamentoItensRepresentantes = new ObservableCollection<Orcamento_Item_RepresentantesModel>(
                    collection: lRepresentantes as ObservableCollectionBaseCadastros<Orcamento_Item_RepresentantesModel>);
            else
                this.orcamentoItensRepresentantes = new ObservableCollection<Orcamento_Item_RepresentantesModel>();
        }


        private ObservableCollection<Orcamento_Item_RepresentantesModel> _orcamentoItensRepresentantes;

        public ObservableCollection<Orcamento_Item_RepresentantesModel> orcamentoItensRepresentantes
        {
            get { return _orcamentoItensRepresentantes; }
            set
            {
                _orcamentoItensRepresentantes = value;
                base.NotifyPropertyChanged(propertyName: "orcamentoItensRepresentantes");
            }
        }


        private bool _bSave;

        public bool bSave
        {
            get { return _bSave; }
            set
            {
                _bSave = value;
                base.NotifyPropertyChanged(propertyName: "bSabe");
            }
        }


    }
}
