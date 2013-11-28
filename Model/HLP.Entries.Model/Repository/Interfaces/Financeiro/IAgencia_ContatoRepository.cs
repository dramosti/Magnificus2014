using HLP.Entries.Model.Models.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Interfaces.Financeiro
{
    public interface IAgencia_ContatoRepository
    {
        void Save(Agencia_ContatoModel objAgencia_Contato);
        void Delete(int idAgenciaContato);
        void DeletePorAgencia(int idAgencia);
        void Copy(Agencia_ContatoModel objAgencia_Contato);
        Agencia_ContatoModel GetAgencia_Contato(int idAgenciaContato);
        List<Agencia_ContatoModel> GetAllAgencia_Contato(int idAgencia);
    }
}
