using HLP.Entries.Model.Models.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Interfaces.Financeiro
{
    public interface IBancoRepository
    {
        List<BancoModel> GetAll();
        BancoModel GetBanco(int idBanco);
        void Save(BancoModel banco);
        void Delete(int idBanco);
        int Copy(int idBanco);
    }
}
