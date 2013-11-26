using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Infrastructure;
using HLP.Comum.Infrastructure.Static;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.Model.Repository.Interfaces.Gerais;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ninject;

namespace HLP.Entries.Model.Repository.Implementation.Gerais
{
    public class Familia_Produto_ClassesRepository : IFamilia_Produto_ClassesRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<Familia_Produto_ClassesModel> regFamilia_Produto_ClassesAccessor;

        public void Save(Familia_Produto_ClassesModel objFamilia_Produto_Classes)
        {
            try
            {
                if (objFamilia_Produto_Classes.idFamilia_Produto_Classes == null)
                {
                    objFamilia_Produto_Classes.idFamilia_Produto_Classes = (int)UndTrabalho.dbPrincipal.ExecuteScalar(UndTrabalho.dbTransaction, "dbo.Proc_save_Familia_Produto_Classes",
                    ParameterBase<Familia_Produto_ClassesModel>.SetParameterValue(objFamilia_Produto_Classes));
                }
                else
                {
                    UndTrabalho.dbPrincipal.ExecuteScalar(UndTrabalho.dbTransaction,
                        "[dbo].[Proc_update_Familia_Produto_Classes]",
                        ParameterBase<Familia_Produto_ClassesModel>.SetParameterValue(objFamilia_Produto_Classes));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        
           
        }

        public void DeleteFamiliasPorFamilia(int idFamiliaProduto)
        {
            UndTrabalho.dbPrincipal.ExecuteNonQuery(UndTrabalho.dbTransaction, System.Data.CommandType.Text,
              "DELETE Familia_Produto_Classes WHERE idFamiliaProduto = " + idFamiliaProduto);
        }

        public void Delete(int idFamilia_Produto_Classes)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar(UndTrabalho.dbTransaction, "dbo.Proc_delete_Familia_Produto_Classes",
                 UserData.idUser,
                 idFamilia_Produto_Classes);
        }

        public void Copy(Familia_Produto_ClassesModel objFamilia_Produto_Classes)
        {
            objFamilia_Produto_Classes.idFamilia_Produto_Classes = null;
            objFamilia_Produto_Classes.idFamilia_Produto_Classes = (int)UndTrabalho.dbPrincipal.ExecuteScalar(UndTrabalho.dbTransaction,
                      "dbo.Proc_save_Familia_Produto_Classes",
            ParameterBase<Familia_Produto_ClassesModel>.SetParameterValue(objFamilia_Produto_Classes));
        }

        public Familia_Produto_ClassesModel GetFamilia_Produto_Classes(int idFamilia_Produto_Classes)
        {
            if (regFamilia_Produto_ClassesAccessor == null)
            {
                regFamilia_Produto_ClassesAccessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("dbo.Proc_sel_Familia_Produto_Classes",
                                 new Parameters(UndTrabalho.dbPrincipal)
                                 .AddParameter<int>("idFamilia_Produto_Classes"),
                                 MapBuilder<Familia_Produto_ClassesModel>.MapAllProperties().Build());
            }

            return regFamilia_Produto_ClassesAccessor.Execute(idFamilia_Produto_Classes).FirstOrDefault();
        }

        public List<Familia_Produto_ClassesModel> GetAllFamilia_Produto_Classes(int idFamiliaProduto)
        {
            DataAccessor<Familia_Produto_ClassesModel> reg = UndTrabalho.dbPrincipal.CreateSqlStringAccessor
             ("select * from Familia_Produto_Classes where idFamiliaProduto = @idFamiliaProduto", new Parameters(UndTrabalho.dbPrincipal).AddParameter<int>("idFamiliaProduto"),
             MapBuilder<Familia_Produto_ClassesModel>.MapAllProperties().Build());

            return reg.Execute(idFamiliaProduto).ToList();
        }
    }
}
