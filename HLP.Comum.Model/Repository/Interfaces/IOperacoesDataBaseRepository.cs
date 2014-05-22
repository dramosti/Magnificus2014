using HLP.Comum.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Comum.Model.Repository.Interfaces
{
    public interface IOperacoesDataBaseRepository
    {
        bool FieldExist(string xTable, string xCampo = "");
        List<RecordsSqlModel> GetRegistros(string xQuery);

        object GetRecord(string nameView, string xCampo, string xValue, int idEmpresa = 0);
    }
}
