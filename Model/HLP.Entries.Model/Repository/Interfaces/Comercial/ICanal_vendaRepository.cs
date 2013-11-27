using HLP.Entries.Model.Models.Comercial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Interfaces.Comercial
{
    public interface ICanal_vendaRepository
    {
        Canal_vendaModel GetCanal(int idCanalVenda);
        void Save(Canal_vendaModel canal);
        void Delete(int idCanalVenda);
        int Copy(int idCanalVenda);
    }
}
