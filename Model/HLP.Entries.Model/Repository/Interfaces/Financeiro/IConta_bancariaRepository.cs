using HLP.Entries.Model.Models.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Interfaces.Financeiro
{
    public interface IConta_bancariaRepository
    {
        List<Conta_bancariaModel> GetByAgencia(int idAgencia);
        Conta_bancariaModel GetConta(int idContaBancaria);
        void Save(Conta_bancariaModel conta);
        void Delete(int idContaBancaria);
        int Copy(int idContaBancaria);
    }
}
