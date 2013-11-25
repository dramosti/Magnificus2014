using HLP.Entries.Model.Models.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Interfaces.Parametros
{
    public interface IParametro_ComprasRepository
    {
        void Save(Parametro_ComprasModel objParametro_Compras);
        void Delete(int idParametro_Compras);
        int Copy(int idParametro_Compras);
        Parametro_ComprasModel GetParametro_Compras(int idEmpresa);
        List<Parametro_ComprasModel> GetAllParametro_Compras();
    }
}
