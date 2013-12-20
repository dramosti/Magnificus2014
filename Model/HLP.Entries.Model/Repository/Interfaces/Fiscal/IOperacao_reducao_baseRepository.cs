using HLP.Entries.Model.Models.Fiscal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Interfaces.Fiscal
{
    public interface IOperacao_reducao_baseRepository
    {
        List<Operacao_reducao_baseModel> GetAll(int idTipoOperacao);
        void Save(Operacao_reducao_baseModel operacaoReducao);
        void Delete(int idOperacaoReducaoBase);
        void Delete(int idTipoOperacao, List<int?> lidOperacaoReducaoBase);
        void Copy(Operacao_reducao_baseModel operacaoReducaoBase);
    }
}
