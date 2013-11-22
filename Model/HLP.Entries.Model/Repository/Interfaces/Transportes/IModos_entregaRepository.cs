using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Entries.Model.Models.Transportes;

namespace HLP.Entries.Model.Repository.Interfaces.Transportes
{
    public interface IModos_entregaRepository
    {
        Modos_entregaModel GetModo(int idModosEntrega);
        void Save(Modos_entregaModel modo);
        void Delete(int idModosEntrega);
        int Copy(int idModosEntrega);
    }
}
