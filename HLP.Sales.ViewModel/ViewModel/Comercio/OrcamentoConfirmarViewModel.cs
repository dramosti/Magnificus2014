using HLP.Sales.Model.Models.Comercial;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Sales.ViewModel.ViewModel.Comercio
{
    public class OrcamentoConfirmarViewModel
    {
        public OrcamentoConfirmarViewModel()
        {

        }

        private ObservableCollection<TrocaStatus_Orcamento_Itens> _lOrcamento_Itens;

        public ObservableCollection<TrocaStatus_Orcamento_Itens> lOrcamento_Itens
        {
            get { return _lOrcamento_Itens; }
            set { _lOrcamento_Itens = value; }
        }

    }
}
