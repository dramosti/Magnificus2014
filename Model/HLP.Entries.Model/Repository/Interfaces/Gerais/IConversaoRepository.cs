using HLP.Entries.Model.Models.Gerais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Interfaces.Gerais
{
    public interface IConversaoRepository
    {
        ConversaoModel GetConversao(int idConversao);
        List<ConversaoModel> GetAll(int idProduto);
        void Save(ConversaoModel conversao);
        void DeletePorProduto(int idProduto);
        void Delete(int idConversao);
        void Copy(ConversaoModel objConversao);
    }
}
