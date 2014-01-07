using HLP.Sales.Model.Models.Comercial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Sales.Model.Repository.Interfaces
{
    public interface IOrcamento_ItemRepository
    {
        void Save(Orcamento_ItemModel objOrcamento_Item);
        void Delete(int idOrcamentoItem);
        int Copy(int idOrcamentoItem, int idOrcamento);
        Orcamento_ItemModel GetOrcamento_Item(int idOrcamentoItem);
        List<Orcamento_ItemModel> GetAllOrcamento_Item();
        List<Orcamento_ItemModel> GetAllOrcamento_Item(int idOrcamento);
        void BebingTransaction();
        void Commit();
        void Rollback();
    }
}
