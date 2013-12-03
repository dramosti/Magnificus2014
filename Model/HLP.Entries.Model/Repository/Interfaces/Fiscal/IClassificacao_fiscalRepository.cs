using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Entries.Model.Models.Fiscal;

namespace HLP.Entries.Model.Repository.Interfaces.Fiscal
{
    public interface IClassificacao_fiscalRepository
    {
        Classificacao_fiscalModel GetClassificacao(int idClassificacaoFiscal);
        void Save(Classificacao_fiscalModel classificacao);
        void Delete(int idClassificacaoFiscal);
        int Copy(int idClassificacaoFiscal);
    }
}
