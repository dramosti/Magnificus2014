using HLP.Entries.Model.Models.Gerais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Interfaces.Gerais
{
    public interface IMoedaRepository
    {
        MoedaModel GetMoeda(int idMoeda);
        void Save(MoedaModel moeda);
        void Delete(int idMoeda);
        bool IsNew(string xSiglaMoeda);
        int Copy(int idMoeda);
    }
}
