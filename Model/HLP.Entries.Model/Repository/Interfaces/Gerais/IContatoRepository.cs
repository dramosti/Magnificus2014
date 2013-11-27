using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Entries.Model.Models.Gerais;

namespace HLP.Entries.Model.Repository.Interfaces.Gerais
{
    public interface IContatoRepository
    {
        void Save(ContatoModel objContato);
        void Delete(int idContato);
        void Copy(ContatoModel objContato);
        ContatoModel GetContato(int idContato);
        List<ContatoModel> GetContato_ByClienteFornec(int idContato);

        void BeginTransaction();
        void CommitTransaction();
        void RollackTransaction();
    }
}
