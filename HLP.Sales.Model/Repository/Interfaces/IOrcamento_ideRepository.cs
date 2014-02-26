using HLP.Sales.Model.Models.Comercial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Sales.Model.Repository.Interfaces
{
    public interface IOrcamento_ideRepository
    {
        void Save(Orcamento_ideModel objOrcamento_ide);
        void Delete(int idOrcamento);
        int Copy(int idOrcamento);
        Orcamento_ideModel GetOrcamento_ide(int idOrcamento);
        List<Orcamento_ideModel> GetAllOrcamento_ide();
        void BeginTransaction();
        void CommitTransaction();
        void RollackTransaction();
        Orcamento_ideModel GetOrcamentoByOrigem(int idOrcamento);
        Orcamento_ideModel GetOrcamentoFilho(int idOrcamento);
        int GetIdOrcamentoPai(int idOrcamento);
        int GetIdOrcamentoFilho(int idOrcamentoOrigem);
    }
}
