using HLP.Entries.Model.Models.Gerais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Interfaces.Gerais
{
    public interface IDepositoRepository
    {
        List<DepositoModel> GetBySite(int idSite);
        DepositoModel GetDeposito(int idDeposito);
        void Save(DepositoModel deposito);
        void Delete(int idDeposito);
        int Copy(int idDeposito);
    }
}
