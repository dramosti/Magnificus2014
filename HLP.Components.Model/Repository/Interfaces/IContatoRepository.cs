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
        int Copy(ContatoModel obj);
        ContatoModel GetContato(int idContato);
        List<ContatoModel> GetAllContato();
        List<ContatoModel> GetContato_ByClienteFornec(int idContato);
        List<ContatoModel> GetContato_ByForeignKey(int id, string xForeignKey);
        void DeleteContato_ByForeignKey(int id, string xForeignKey);
        void BeginTransaction();
        void CommitTransaction();
        void RollackTransaction();
    }
}
