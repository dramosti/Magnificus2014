using HLP.Sales.Model.Models.Comercial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Sales.Model.Repository.Interfaces
{
    public interface IOrcamento_retTranspRepository
    {
        void Save(Orcamento_retTranspModel objOrcamento_retTransp);
        void Delete(int idRetTransp);
        int Copy(int idRetTransp);
        Orcamento_retTranspModel GetOrcamento_retTransp(int idRetTransp);
        List<Orcamento_retTranspModel> GetAllOrcamento_retTransp();
        Orcamento_retTranspModel GetOrcamento_retTranspByIdOrcamento(int idOrcamento);
    }
}
