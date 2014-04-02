using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Model.Models;
using HLP.Comum.Model.Components;

namespace HLP.Comum.Model.StaticModels
{
    public static class lCamposSqlNotNull
    {
        public static List<CamposSqlNotNullModel> _lCamposSql = new List<CamposSqlNotNullModel>();

        public static void AddCampoSql(CamposSqlNotNullModel objCamposSqlNotNull)
        {
            _lCamposSql.Add(item: objCamposSqlNotNull);
        }
    }

    public class CamposSqlNotNullModel
    {
        public string xTabela { get; set; }
        public List<PesquisaPadraoModelContract> lCamposSqlModel { get; set; }
    }
}
