﻿using HLP.Comum.Model.Models;
using HLP.Comum.Resources.RecursosBases;
using HLP.Comum.Resources.Util;
using HLP.Dependencies;
using HLP.Entries.Model.Repository.Interfaces.Gerais;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "serviceFuncionario" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select serviceFuncionario.svc or serviceFuncionario.svc.cs at the Solution Explorer and start debugging.
    public class serviceFuncionario : IserviceFuncionario
    {
        [Inject]
        public IFuncionarioRepository funcionarioRepository { get; set; }

        [Inject]
        public IFuncionario_ArquivoRepository funcionario_ArquivoRepository { get; set; }

        [Inject]
        public IFuncionario_CertificacaoRepository funcionario_CertificacaoRepository { get; set; }

        [Inject]
        public IFuncionario_Comissao_ProdutoRepository funcionario_Comissao_ProdutoRepository { get; set; }

        [Inject]
        public IFuncionario_EnderecoRepository funcionario_EnderecoRepository { get; set; }

        [Inject]
        public IFuncionario_Margem_Lucro_ComissaoRepository funcionario_Margem_Lucro_ComissaoRepository { get; set; }

        [Inject]
        public IAcessoRepository acessoRepository { get; set; }

        public serviceFuncionario()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public HLP.Entries.Model.Models.Gerais.FuncionarioModel getFuncionario(int idFuncionario)
        {
            try
            {
                HLP.Entries.Model.Models.Gerais.FuncionarioModel objFuncionario = this.funcionarioRepository.GetFuncionario(
                    idFuncionario: idFuncionario);

                objFuncionario.lFuncionario_Acesso = new ObservableCollectionBaseCadastros<HLP.Entries.Model.Models.Gerais.Funcionario_AcessoModel>(list:
                    this.acessoRepository.GetAllAcesso_Funcionario(
                    idFuncionario: idFuncionario));

                objFuncionario.lFuncionario_Arquivo = new ObservableCollectionBaseCadastros<HLP.Entries.Model.Models.Gerais.Funcionario_ArquivoModel>(list:
                    this.funcionario_ArquivoRepository.GetAllFuncionario_Arquivo(
                    idFuncionario: idFuncionario));

                objFuncionario.lFuncionario_Certificacao = new ObservableCollectionBaseCadastros<HLP.Entries.Model.Models.Gerais.Funcionario_CertificacaoModel>(list:
                    this.funcionario_CertificacaoRepository.GetAllFuncionario_Certificacao(
                    idFuncionario: idFuncionario));

                objFuncionario.lFuncionario_Comissao_Produto = new ObservableCollectionBaseCadastros<HLP.Entries.Model.Models.Gerais.Funcionario_Comissao_ProdutoModel>(list:
                    this.funcionario_Comissao_ProdutoRepository.GetAllFuncionario_Comissao_Produto(
                    idFuncionario: idFuncionario));

                objFuncionario.lFuncionario_Endereco = new ObservableCollectionBaseCadastros<HLP.Entries.Model.Models.Gerais.Funcionario_EnderecoModel>(list:
                    this.funcionario_EnderecoRepository.GetAllFuncionario_Endereco(idFuncionario:
                    idFuncionario));

                objFuncionario.lFuncionario_Margem_Lucro_Comissao = new ObservableCollectionBaseCadastros<HLP.Entries.Model.Models.Gerais.Funcionario_Margem_Lucro_ComissaoModel>(list:
                    this.funcionario_Margem_Lucro_ComissaoRepository.GetAllFuncionario_Margem_Lucro_Comissao(
                    idFuncionario: idFuncionario));

                return objFuncionario;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public int saveFuncionario(HLP.Entries.Model.Models.Gerais.FuncionarioModel objFuncionario)
        {

            try
            {
                this.funcionarioRepository.Save(objFuncionario: objFuncionario);

                foreach (HLP.Entries.Model.Models.Gerais.Funcionario_AcessoModel item in objFuncionario.lFuncionario_Acesso)
                {
                    switch (item.status)
                    {
                        case statusModel.criado:
                        case statusModel.alterado:
                            {
                                this.acessoRepository.Save(objAcesso:
                                    item);
                            }
                            break;
                        case statusModel.excluido:
                            {
                                this.acessoRepository.Delete(objAcesso:
                                    item);
                            }
                            break;
                    }
                }


                foreach (HLP.Entries.Model.Models.Gerais.Funcionario_ArquivoModel item in objFuncionario.lFuncionario_Arquivo)
                {
                    switch (item.status)
                    {
                        case statusModel.criado:
                        case statusModel.alterado:
                            {
                                this.funcionario_ArquivoRepository.Save(
                                    objFuncionario_Arquivo: item);
                            }
                            break;
                        case statusModel.excluido:
                            {
                                this.funcionario_ArquivoRepository.Delete(
                                    objFuncionario_Arquivo: item);
                            }
                            break;
                    }
                }


                foreach (HLP.Entries.Model.Models.Gerais.Funcionario_CertificacaoModel item in objFuncionario.lFuncionario_Certificacao)
                {
                    switch (item.status)
                    {
                        case statusModel.criado:
                        case statusModel.alterado:
                            {
                                this.funcionario_CertificacaoRepository.Save(
                                    objFuncionario_Certificacao: item);
                            }
                            break;
                        case statusModel.excluido:
                            {
                                this.funcionario_CertificacaoRepository.Delete(
                                    objFuncionario_Certificacao: item);
                            }
                            break;
                    }
                }


                foreach (HLP.Entries.Model.Models.Gerais.Funcionario_Comissao_ProdutoModel item in objFuncionario.lFuncionario_Comissao_Produto)
                {
                    switch (item.status)
                    {
                        case statusModel.criado:
                        case statusModel.alterado:
                            {
                                this.funcionario_Comissao_ProdutoRepository.Save(
                                    objFuncionario_Comissao_Produto: item);
                            }
                            break;
                        case statusModel.excluido:
                            {
                                this.funcionario_Comissao_ProdutoRepository.Delete(
                                    objFuncionario_Comissao_Produto: item);
                            }
                            break;
                    }
                }


                foreach (HLP.Entries.Model.Models.Gerais.Funcionario_EnderecoModel item in objFuncionario.lFuncionario_Endereco)
                {
                    switch (item.status)
                    {
                        case statusModel.criado:
                        case statusModel.alterado:
                            {
                                this.funcionario_EnderecoRepository.Save(
                                    objFuncionario_Endereco: item);
                            }
                            break;
                        case statusModel.excluido:
                            {
                                this.funcionario_EnderecoRepository.Delete(
                                    objFuncionario_Endereco: item);
                            }
                            break;
                    }
                }


                foreach (HLP.Entries.Model.Models.Gerais.Funcionario_Margem_Lucro_ComissaoModel item in objFuncionario.lFuncionario_Margem_Lucro_Comissao)
                {
                    switch (item.status)
                    {
                        case statusModel.criado:
                        case statusModel.alterado:
                            {
                                this.funcionario_Margem_Lucro_ComissaoRepository.Save(
                                    objFuncionario_Margem_Lucro_Comissao: item);
                            }
                            break;
                        case statusModel.excluido:
                            {
                                this.funcionario_Margem_Lucro_ComissaoRepository.Delete(
                                    objFuncionario_Margem_Lucro_Comissao: item);
                            }
                            break;
                    }
                }



                return (int)objFuncionario.idFuncionario;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }




        }

        public bool deleteFuncionario(int idFuncionario)
        {

            try
            {
                this.funcionarioRepository.BeginTransaction();
                this.funcionario_ArquivoRepository.Delete(idFuncionario:
                    idFuncionario);
                this.funcionario_CertificacaoRepository.Delete(idFuncionario:
                    idFuncionario);
                this.funcionario_Comissao_ProdutoRepository.Delete(idFuncionario:
                    idFuncionario);
                this.funcionario_EnderecoRepository.Delete(idFuncionario:
                    idFuncionario);
                this.funcionario_Margem_Lucro_ComissaoRepository.Delete(idFuncionario:
                    idFuncionario);
                this.funcionarioRepository.Delete(idFuncionario: idFuncionario);
                this.funcionarioRepository.CommitTransaction();
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                this.funcionarioRepository.RollackTransaction();
                throw new FaultException(reason: ex.Message);
            }

        }

        public int copyFuncionario(HLP.Entries.Model.Models.Gerais.FuncionarioModel objFuncionario)
        {

            try
            {
                this.funcionarioRepository.BeginTransaction();
                this.funcionarioRepository.Copy(objFuncionario: objFuncionario);

                foreach (HLP.Entries.Model.Models.Gerais.Funcionario_ArquivoModel item in objFuncionario.lFuncionario_Arquivo)
                {
                    item.idFuncionario = (int)objFuncionario.idFuncionario;
                    this.funcionario_ArquivoRepository.Copy(
                        objFuncionario_Arquivo: item);
                }

                foreach (HLP.Entries.Model.Models.Gerais.Funcionario_CertificacaoModel item in objFuncionario.lFuncionario_Certificacao)
                {
                    item.idFuncionario = (int)objFuncionario.idFuncionario;
                    this.funcionario_CertificacaoRepository.Copy(
                        objFuncionario_Certificacao: item);
                }

                foreach (HLP.Entries.Model.Models.Gerais.Funcionario_Comissao_ProdutoModel item in objFuncionario.lFuncionario_Comissao_Produto)
                {
                    item.idFuncionario = (int)objFuncionario.idFuncionario;
                    this.funcionario_Comissao_ProdutoRepository.Copy(
                        objFuncionario_Comissao_Produto: item);
                }

                foreach (HLP.Entries.Model.Models.Gerais.Funcionario_EnderecoModel item in objFuncionario.lFuncionario_Endereco)
                {
                    item.idFuncionario = (int)objFuncionario.idFuncionario;
                    this.funcionario_EnderecoRepository.Copy(
                        objFuncionario_Endereco: item);
                }

                foreach (HLP.Entries.Model.Models.Gerais.Funcionario_Margem_Lucro_ComissaoModel item in objFuncionario.lFuncionario_Margem_Lucro_Comissao)
                {
                    item.idFuncionario = (int)objFuncionario.idFuncionario;
                    this.funcionario_Margem_Lucro_ComissaoRepository.Copy(
                        objFuncionario_Margem_Lucro_Comissao: item);
                }

                this.funcionarioRepository.CommitTransaction();
                return (int)objFuncionario.idFuncionario;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                this.funcionarioRepository.RollackTransaction();
                throw new FaultException(reason: ex.Message);
            }


        }
    }
}