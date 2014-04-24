using HLP.Components.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Components.Model.Repository.Interfaces
{
    public interface IContatoRepository
    {
        void Save(ContatoModel objContato);
        void Delete(int idContato);
        int Copy(int idContato);
        ContatoModel GetContato(int idContato);
        List<ContatoModel> GetAllContato();
        List<ContatoModel> GetContato_ByClienteFornec(int idContato);
        List<ContatoModel> GetContato_ByForeignKey(int id, string tabela);
        void DeleteContato_ByForeignKey(int id, string tabela);
        void BeginTransaction();
        void CommitTransaction();
        void RollackTransaction();
    }
}
