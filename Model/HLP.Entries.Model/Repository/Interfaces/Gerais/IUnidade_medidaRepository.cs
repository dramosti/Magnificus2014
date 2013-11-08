using HLP.Entries.Model.Models.Gerais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Interfaces.Gerais
{
    public interface IUnidade_medidaRepository
    {
        Unidade_medidaModel GetUnidade(int idUnidadeMedida);
        void Save(Unidade_medidaModel unidade);
        void Delete(int idUnidadeMedida);
        int Copy(int idUnidadeMedida);
        bool IsNew(string xSiglaPadrao);
        List<Unidade_medidaModel> GetUnidadeByConversaoProduto(int idParaUnidadeMedida, int idProduto);
    }
}
