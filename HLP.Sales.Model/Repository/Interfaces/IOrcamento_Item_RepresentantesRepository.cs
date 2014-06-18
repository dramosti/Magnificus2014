using HLP.Sales.Model.Models.Comercial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Sales.Model.Repository.Interfaces
{
    public interface IOrcamento_Item_RepresentantesRepository
    {
        void Save(Orcamento_Item_RepresentantesModel objOrcamento_Item_Representantes);
        void Delete(int idOrcamentoItemRepresentate);
        int Copy(int idOrcamentoItemRepresentate);
        Orcamento_Item_RepresentantesModel GetOrcamento_Item_Representantes(int idOrcamentoItemRepresentate);
        List<Orcamento_Item_RepresentantesModel> GetAllOrcamento_Item_Representantes();
        List<Orcamento_Item_RepresentantesModel> GetOrcamento_Item_Representantes_ByIdOrcamentoItem(int idOrcamentoItem);
    }
}
