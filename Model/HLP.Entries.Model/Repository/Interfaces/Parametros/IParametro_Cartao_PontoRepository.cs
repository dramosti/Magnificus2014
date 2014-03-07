using HLP.Entries.Model.Models.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Interfaces.Parametros
{
    public interface IParametro_Cartao_PontoRepository
    {
        void Save(Parametro_Cartao_PontoModel objParametro_Cartao_Ponto);
        void Delete(int idParametroCartaoPonto);
        int Copy(int idParametroCartaoPonto);
        Parametro_Cartao_PontoModel GetParametro_Cartao_Ponto(int idEmpresa);
        List<Parametro_Cartao_PontoModel> GetAllParametro_Cartao_Ponto();
    }
}
