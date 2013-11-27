using HLP.Entries.Model.Models.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Interfaces.Parametros
{
    public interface IParametro_EstoqueRepository
    {
        void Save(Parametro_EstoqueModel objParametro_Estoque);
        void Delete(int idParametroEstoque);
        int Copy(int idParametroEstoque);
        Parametro_EstoqueModel GetParametro_Estoque(int idEmpresa);
        List<Parametro_EstoqueModel> GetAllParametro_Estoque();
    }
}
