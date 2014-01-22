using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.Comum.Infrastructure.Static
{
    public static class CompanyData
    {
        public static int idEmpresa { get; set; }
        public static string xNome { get; set; }
        public static string xFantasia { get; set; }
        public static string xLinqLogoEmpresa { get; set; }
        public static bool stMaiusculo { get; set; }

        private static object _parametrosEmpresa;
        public static object parametrosEmpresa
        {
            get
            {
                return _parametrosEmpresa;
            }
            set
            {
                _parametrosEmpresa = value;
                Type t = CompanyData.parametrosEmpresa.GetType().GetProperty("empresaParametros").PropertyType;
                object parametro = Activator.CreateInstance(t);
                parametro = CompanyData.parametrosEmpresa.GetType().GetProperty("empresaParametros").GetValue(CompanyData.parametrosEmpresa);

                Type tParametro_Custo = parametro.GetType().GetProperty("ObjParametro_CustosModel").PropertyType;
                parametros_CustoEmpresa = Activator.CreateInstance(tParametro_Custo);
                parametros_CustoEmpresa = parametro.GetType().GetProperty("ObjParametro_CustosModel").GetValue(parametro);

                Type tParametro_Fiscal = parametro.GetType().GetProperty("ObjParametro_FiscalModel").PropertyType;
                parametros_FiscalEmpresa = Activator.CreateInstance(tParametro_Fiscal);
                parametros_FiscalEmpresa = parametro.GetType().GetProperty("ObjParametro_FiscalModel").GetValue(parametro);
            }
        }

        public static object parametros_CustoEmpresa { get; set; }

        public static object parametros_FiscalEmpresa { get; set; }
    }
}
