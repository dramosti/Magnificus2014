using HLP.Base.ClassesBases;
using HLP.Base.Static;
using HLP.Entries.Model.Models.Comercial;
using HLP.Entries.Model.Repository.Interfaces.Comercial;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Implementation.Comercial
{
    public class Canal_vendaRepository : ICanal_vendaRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<Canal_vendaModel> regCanalAccessor;

        public Canal_vendaModel GetCanal(int idCanalVenda)
        {
            if (regCanalAccessor == null)
            {
                regCanalAccessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("dbo.Proc_sel_canal_venda",
                                    new Parameters(UndTrabalho.dbPrincipal)
                                    .AddParameter<int>("idCanalVenda"),
                                    MapBuilder<Canal_vendaModel>.MapAllProperties().DoNotMap(i => i.status).Build());
            }
            return regCanalAccessor.Execute(idCanalVenda).FirstOrDefault();
        }

        public void Save(Canal_vendaModel canal)
        {
            if (canal.idCanalVenda == null)
            {
                int idCanalVenda = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                  "Proc_save_Canal_venda",
                 ParameterBase<Canal_vendaModel>.SetParameterValue(canal));
                canal.idCanalVenda = idCanalVenda;
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar(
                  "[dbo].[Proc_update_Canal_venda]",
                 ParameterBase<Canal_vendaModel>.SetParameterValue(canal));
            }
        }

        public void Delete(int idCanalVenda)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar(
                     "dbo.Proc_delete_canal_venda",
                      UserData.idUser,
                      idCanalVenda);
        }


        public int Copy(int idCanalVenda)
        {
            return (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                          "dbo.Proc_copy_canal_venda",
                           idCanalVenda);
        }
    }
}
