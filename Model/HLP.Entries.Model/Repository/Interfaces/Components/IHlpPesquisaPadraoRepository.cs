using HLP.Base.ClassesBases;
using HLP.Entries.Model.Models.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Interfaces.Components
{
    public interface IHlpPesquisaPadraoRepository
    {
        object GetData(string sSelect, bool addDefault = false, string sWhere = "", bool bOrdena = true);
        PesquisaPadraoModel[] GetTableInformation(string sViewName);
        PesquisaPadraoModelContract[] GetTableInformationContract(string sViewName);
        List<PesquisaPadraoModelContract> getCamposSqlNotNull(string xTabela);
    }
}
