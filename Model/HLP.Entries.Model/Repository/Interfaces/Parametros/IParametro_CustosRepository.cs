using HLP.Entries.Model.Models.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Interfaces.Parametros
{
    public interface IParametro_CustosRepository
    {
        void Save(Parametro_CustosModel objParametro_Custos);
        void Delete(int idParametroCustos);
        int Copy(int idParametroCustos);
        Parametro_CustosModel GetParametro_Custos(int idEmpresa);
        List<Parametro_CustosModel> GetAllParametro_Custos();
    }
}
