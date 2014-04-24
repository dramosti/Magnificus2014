using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Entries.Model.Models.Gerais;
using HLP.Components.Model.Models;

namespace HLP.Entries.Model.Repository.Interfaces.Gerais
{
    public interface IContatoRepository
    {
        void Save(ContatoModel objContato);
        void Delete(int idContato);
        void Copy(ContatoModel objContato);
        ContatoModel GetContato(int idContato);
        List<ContatoModel> GetContato_ByClienteFornec(int idContato);
        List<ContatoModel> GetContato_ByForeignKey(int id, string tabela);
        void BeginTransaction();
        void CommitTransaction();
        void RollackTransaction();
    }
}
