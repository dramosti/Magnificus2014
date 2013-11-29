using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Entries.Model.Models.Financeiro;

namespace HLP.Entries.Model.Repository.Interfaces.Financeiro
{
    public interface IDescontos_AvistaRepository
    {
        Descontos_AvistaModel GetDesconto(int idDescontosAvista);
        List<Descontos_AvistaModel> GetAll();
        void Save(Descontos_AvistaModel desconto);
        void Delete(int idDescontosAvista);
        int Copy(int idDescontosAvista);
    }
}
