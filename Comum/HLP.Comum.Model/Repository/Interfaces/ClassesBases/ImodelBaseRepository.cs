using HLP.Comum.Model.Components;
using HLP.Comum.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Comum.Model.Repository.Interfaces.ClassesBases
{
    public interface ImodelBaseRepository
    {
        List<PesquisaPadraoModelContract> getCamposSqlNotNull(string xTabela);
    }
}
