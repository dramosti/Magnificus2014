using HLP.Entries.Model.Models.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Interfaces.Parametros
{
    public interface IParametro_ComercialRepository
    {
        void Save(Parametro_ComercialModel objParametro_Comercial);
        void Delete(int idParametroComercial);
        int Copy(int idParametroComercial);
        Parametro_ComercialModel GetParametro_Comercial(int idEmpresa);
        List<Parametro_ComercialModel> GetAllParametro_Comercial();
    }
}
