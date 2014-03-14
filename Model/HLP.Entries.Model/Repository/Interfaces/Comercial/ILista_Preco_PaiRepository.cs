using HLP.Comum.Model.Models;
using HLP.Entries.Model.Models.Comercial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Interfaces.Comercial
{
    public interface ILista_Preco_PaiRepository
    {
        void Save(Lista_Preco_PaiModel objLista_Preco_Pai);
        void Delete(int idListaPrecoPai);
        void Copy(Lista_Preco_PaiModel objLista_Preco_Pai);
        Lista_Preco_PaiModel GetLista_Preco_Pai(int idListaPrecoPai);
        List<int> GetAllIdListaPreco();
        int GetIdListaPreferencial();

        void BeginTransaction();
        void CommitTransaction();
        void RollackTransaction();
    }
}
