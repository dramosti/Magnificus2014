using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Entries.Model.Repository.Interfaces.Gerais;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ninject;
using HLP.Base.ClassesBases;
using HLP.Base.Static;

namespace HLP.Entries.Model.Models.Gerais
{
    public class Tipo_servicoRepository : ITipo_servicoRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<Tipo_servicoModel> regTipoAccessor;

        public Tipo_servicoModel GetTipo(int idTipoServico)
        {
            if (regTipoAccessor == null)
            {
                regTipoAccessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("dbo.Proc_sel_tipo_servico",
                                    new Parameters(UndTrabalho.dbPrincipal)
                                    .AddParameter<int>("idTipoServico"),
                                    MapBuilder<Tipo_servicoModel>.MapAllProperties().DoNotMap(c=>c.status).Build());
            }
            return regTipoAccessor.Execute(idTipoServico).FirstOrDefault();
        }

        public void Save(Tipo_servicoModel tipo)
        {
            if (tipo.idTipoServico == null)
            {
                int idTipoServico = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                 "dbo.Proc_save_tipo_servico",
                ParameterBase<Tipo_servicoModel>.SetParameterValue(tipo));

                tipo.idTipoServico = idTipoServico;
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar(
                 "[dbo].[Proc_update_Tipo_servico]",
                ParameterBase<Tipo_servicoModel>.SetParameterValue(tipo));
            }
        }

        public void Delete(int idTipoServico)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar(
                       "dbo.Proc_delete_tipo_servico",
                        UserData.idUser,
                        idTipoServico);
        }

        public int Copy(int idTipoServico)
        {
            return (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                       "dbo.Proc_copy_tipo_servico",
                        idTipoServico);
        }
    }
}
