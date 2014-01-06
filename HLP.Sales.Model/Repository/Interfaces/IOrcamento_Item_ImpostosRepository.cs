using HLP.Sales.Model.Models.Comercial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Sales.Model.Repository.Interfaces
{
    public interface IOrcamento_Item_ImpostosRepository
    {
        void Save(Orcamento_Item_ImpostosModel objOrcamento_Item_Impostos);
        void Delete(int idOrcamentoTotalizadorImpostos);
        int Copy(int idOrcamentoTotalizadorImpostos, int idOrcamentoItem);
        Orcamento_Item_ImpostosModel GetOrcamento_Item_Impostos(int idOrcamentoTotalizadorImpostos);
        List<Orcamento_Item_ImpostosModel> GetAllOrcamento_Item_Impostos();
        Orcamento_Item_ImpostosModel GetOrcamento_Item_ImpostosByItem(int idOrcamento_Item);
    }
}
