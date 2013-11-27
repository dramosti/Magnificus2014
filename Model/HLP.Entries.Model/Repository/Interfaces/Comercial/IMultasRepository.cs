using HLP.Entries.Model.Models.Comercial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Interfaces.Comercial
{
    public interface IMultasRepository
    {
        MultasModel GetMulta(int idMultas);
        void Save(MultasModel multa);
        void Delete(int idMultas);
        int Copy(int idMultas);
    }
}
