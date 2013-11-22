using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HLP.Comum.Infrastructure;
using HLP.Comum.Infrastructure.Static;
using HLP.Comum.Model.Components;
using HLP.Comum.Model.Repository.Interfaces.Components;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ninject;

namespace HLP.Comum.Model.Repository.Implementation.Components
{
    public class HlpPesquisaRapidaRepository : IHlpPesquisaRapidaRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        DataAccessor<PesquisaRapidaModel> regAcessor = null;


        public string GetValorDisplay(string _TableView, string[] _Items, string _FieldPesquisa, int idEmpresa, int? _iValorPesquisa)
        {
            try
            {
                string sDisplay = string.Empty;
                if (UndTrabalho.TableExistis(_TableView))
                {
                    if (regAcessor == null)
                    {

                        if (_FieldPesquisa == null)
                            throw new Exception("Campo FieldPesquisa não foi configurado!");
                        if (UndTrabalho.ColunaExistis(_TableView, _FieldPesquisa) == false)
                            throw new Exception(string.Format("Campo FieldPesquisa ({0}) configurado no componente não existe!", _FieldPesquisa));
                                                                        
                        foreach (string col in (_Items.ToList()).Distinct())
                        {
                            if (UndTrabalho.ColunaExistis(_TableView, col.ToString()))
                            {
                                if (sDisplay == string.Empty)
                                    sDisplay += string.Format("CAST({0} as varchar)", col);
                                else
                                    sDisplay += " + ' - '," + string.Format("CAST({0} as varchar)", col);
                            }
                        }

                        if (sDisplay == string.Empty)
                            throw new Exception("Nenhuma coluna válida foi encontrada!");

                        StringBuilder sQuery = new StringBuilder();
                        sQuery.Append("SELECT ");
                        sQuery.Append(_iValorPesquisa + " as Valor ,");
                        if (sDisplay.Split('-').Count() > 1)
                            sQuery.Append("CONCAT(" + sDisplay + ") as Display ");
                        else
                            sQuery.Append(" " + sDisplay + " as Display ");
                        sQuery.Append("FROM " + _TableView);
                        sQuery.Append(" WHERE ");
                        sQuery.Append(_FieldPesquisa + " = @FieldPesquisa ");
                        if (UndTrabalho.ColunaExistis(_TableView, "idEmpresa"))
                            sQuery.Append(" AND idEmpresa = '" + idEmpresa + "' ");
                        if (UndTrabalho.ColunaExistis(_TableView, "Ativo"))
                            sQuery.Append(" AND Ativo = 'S'");

                        regAcessor = UndTrabalho.dbPrincipal.CreateSqlStringAccessor(sQuery.ToString(),
                            new Parameters(UndTrabalho.dbPrincipal).AddParameter<int>("FieldPesquisa"),
                            MapBuilder<PesquisaRapidaModel>.MapAllProperties().Build());
                    }


                    List<PesquisaRapidaModel> lResult = regAcessor.Execute(_iValorPesquisa).ToList();
                    sDisplay = "";
                    if (lResult != null)
                    {
                        if (lResult.Count > 0)
                        {
                            sDisplay = regAcessor.Execute(_iValorPesquisa).FirstOrDefault().Display;
                        }
                    }
                    return sDisplay;
                }
                else
                {
                    throw new Exception("Tabela/View não existente na base de dados!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




    }
}
