using HLP.Comum.Model.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.SQLAnalyse.Model.Repository.Interfaces
{
    public class IOperacoesSqlRepository
    {
        DataTable GetTabelas();
        List<TabelaModel> GetDetalhes(string sNomeTabela);
        DataTable GetListaTabFilha(string nmTabPai);
        void SetStringConnection(string sString);

    }
}
