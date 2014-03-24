using HLP.Comum.Model.Models;
using HLP.Comum.Resources.RecursosBases;
using HLP.Comum.Resources.Util;
using HLP.Dependencies;
using HLP.Entries.Model.Repository.Interfaces.Gerais;
using HLP.Entries.Model.Repository.Interfaces.RecursosHumanos;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_Funcionario" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_Funcionario.svc or wcf_Funcionario.svc.cs at the Solution Explorer and start debugging.
    public class wcf_Funcionario : Iwcf_Funcionario
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
        public IFamilia_ProdutoRepository familia_ProdutoRepository { get; set; }

        //[Inject]
        //public IFuncionario_EnderecoRepository funcionario_EnderecoRepository { get; set; }
        [Inject]
        public HLP.Comum.Model.Repository.Interfaces.Components.IHlpEnderecoRepository hlpEnderecoRepository { get; set; }

        [Inject]
        public IFuncionario_Margem_Lucro_ComissaoRepository funcionario_Margem_Lucro_ComissaoRepository { get; set; }

        [Inject]
        public ICargoRepository cargo_Repository { get; set; }

        public wcf_Funcionario()
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

                var listaArquivos = this.funcionario_ArquivoRepository.GetAllFuncionario_Arquivo(
                    idFuncionario: idFuncionario);
                if (listaArquivos.Count > 0)
                    objFuncionario.lFuncionario_Arquivo = new ObservableCollectionBaseCadastros<HLP.Entries.Model.Models.Gerais.Funcionario_ArquivoModel>(list:
                        listaArquivos);

                var listaCertif = this.funcionario_CertificacaoRepository.GetAllFuncionario_Certificacao(
                    idFuncionario: idFuncionario);
                if (listaCertif.Count > 0)
                    objFuncionario.lFuncionario_Certificacao = new ObservableCollectionBaseCadastros<HLP.Entries.Model.Models.Gerais.Funcionario_CertificacaoModel>(list:
                        listaCertif);

                var listaComissaoProduto = this.funcionario_Comissao_ProdutoRepository.GetAllFuncionario_Comissao_Produto(
                    idFuncionario: idFuncionario);
                if (listaComissaoProduto.Count > 0)
                    objFuncionario.lFuncionario_Comissao_Produto = new ObservableCollectionBaseCadastros<HLP.Entries.Model.Models.Gerais.Funcionario_Comissao_ProdutoModel>(list:
                        listaComissaoProduto);

                var listaEndereco = this.hlpEnderecoRepository.GetAllObjetos(idPK:
                    idFuncionario, sPK: "idFuncionario");
                if (listaEndereco.Count > 0)
                    objFuncionario.lFuncionario_Endereco = new ObservableCollectionBaseCadastros<HLP.Comum.Model.Models.EnderecoModel>(list:
                        listaEndereco);

                var listaMargem = this.funcionario_Margem_Lucro_ComissaoRepository.GetAllFuncionario_Margem_Lucro_Comissao(
                    idFuncionario: idFuncionario);
                if (listaMargem.Count > 0)
                    objFuncionario.lFuncionario_Margem_Lucro_Comissao = new ObservableCollectionBaseCadastros<HLP.Entries.Model.Models.Gerais.Funcionario_Margem_Lucro_ComissaoModel>(list:
                        listaMargem);

                return objFuncionario;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public HLP.Entries.Model.Models.Gerais.FuncionarioModel saveFuncionario(HLP.Entries.Model.Models.Gerais.FuncionarioModel objFuncionario)
        {

            try
            {
                this.funcionarioRepository.BeginTransaction();
                this.funcionarioRepository.Save(objFuncionario: objFuncionario);

                foreach (HLP.Entries.Model.Models.Gerais.Funcionario_ArquivoModel item in objFuncionario.lFuncionario_Arquivo)
                {
                    switch (item.status)
                    {
                        case statusModel.criado:
                        case statusModel.alterado:
                            {
                                item.idFuncionario = (int)objFuncionario.idFuncionario;
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
                                item.idFuncionario = (int)objFuncionario.idFuncionario;
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
                                item.idFuncionario = (int)objFuncionario.idFuncionario;
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


                foreach (HLP.Comum.Model.Models.EnderecoModel item in objFuncionario.lFuncionario_Endereco)
                {
                    switch (item.status)
                    {
                        case statusModel.criado:
                        case statusModel.alterado:
                            {
                                item.idFuncionario = (int)objFuncionario.idFuncionario;
                                this.hlpEnderecoRepository.Save(item);
                            }
                            break;
                        case statusModel.excluido:
                            {
                                this.hlpEnderecoRepository.Delete(item);
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
                                item.idFuncionario = (int)objFuncionario.idFuncionario;
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

                if (objFuncionario.stComissao == 2 && objFuncionario.lFamiliaProduto != null)
                {
                    foreach (HLP.Entries.Model.Models.Gerais.Familia_produtoModel item in objFuncionario.lFamiliaProduto)
                    {

                        switch (item.status)
                        {
                            case statusModel.criado:
                            case statusModel.alterado:
                                {
                                    this.familia_ProdutoRepository.Save(familia_produto: item);
                                }
                                break;
                        }

                    }
                }

                this.funcionarioRepository.CommitTransaction();
                return objFuncionario;
            }
            catch (Exception ex)
            {
                this.funcionarioRepository.RollackTransaction();
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
                this.hlpEnderecoRepository.Delete(idFuncionario, "idFuncionario");
                this.funcionario_Margem_Lucro_ComissaoRepository.Delete(idFuncionario:
                    idFuncionario);
                this.funcionarioRepository.Delete(idFuncionario: idFuncionario);
                this.funcionarioRepository.CommitTransaction();
                return true;
            }
            catch (Exception ex)
            {
                this.funcionarioRepository.RollackTransaction();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public HLP.Entries.Model.Models.Gerais.FuncionarioModel copyFuncionario(HLP.Entries.Model.Models.Gerais.FuncionarioModel objFuncionario)
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

                foreach (HLP.Comum.Model.Models.EnderecoModel item in objFuncionario.lFuncionario_Endereco)
                {
                    item.idFuncionario = (int)objFuncionario.idFuncionario;
                    this.hlpEnderecoRepository.Copy(item);
                }

                foreach (HLP.Entries.Model.Models.Gerais.Funcionario_Margem_Lucro_ComissaoModel item in objFuncionario.lFuncionario_Margem_Lucro_Comissao)
                {
                    item.idFuncionario = (int)objFuncionario.idFuncionario;
                    this.funcionario_Margem_Lucro_ComissaoRepository.Copy(
                        objFuncionario_Margem_Lucro_Comissao: item);
                }

                this.funcionarioRepository.CommitTransaction();
                return objFuncionario;
            }
            catch (Exception ex)
            {
                this.funcionarioRepository.RollackTransaction();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }


        }

        public HLP.Comum.Resources.Models.modelToTreeView GetHierarquiaFuncionario(int idFuncionario)
        {
            if (idFuncionario == 0)
                return null;

            HLP.Comum.Resources.Models.modelToTreeView nodeTemp;

            HLP.Entries.Model.Models.Gerais.FuncionarioModel f = this.getFuncionario(idFuncionario: idFuncionario);
            int? idResponsavel = f.idResponsavel;
            HLP.Comum.Resources.Models.modelToTreeView nodeActual = new HLP.Comum.Resources.Models.modelToTreeView
            {
                id = (int)f.idFuncionario,
                xDisplay = f.xNome + " - " + this.cargo_Repository.GetCargo(idCargo: f.idCargo).xDescricao
            };

            while (f.idResponsavel != null)
            {
                f = this.funcionarioRepository.GetFuncionarioPai(idFuncionario: (int)f.idResponsavel);

                nodeTemp = new HLP.Comum.Resources.Models.modelToTreeView
                {
                    id = (int)f.idFuncionario,
                    xDisplay = f.xNome + " - " + this.cargo_Repository.GetCargo(idCargo: f.idCargo).xDescricao,
                    lFilhos = new List<HLP.Comum.Resources.Models.modelToTreeView>()
                    {
                        new HLP.Comum.Resources.Models.modelToTreeView
                        {
                            id = nodeActual.id,
                            xDisplay = nodeActual.xDisplay,
                            lFilhos = nodeActual.lFilhos
                        }
                    }
                };

                nodeActual = nodeTemp;

            }

            nodeTemp = nodeActual;
            while (nodeActual.id != idFuncionario)
            {
                nodeActual = nodeActual.lFilhos.FirstOrDefault();
            }

            var lFilhos = this.funcionarioRepository.GetFuncionarioFilho(idResponsavel: nodeActual.id);

            if (lFilhos != null)
            {
                nodeActual.lFilhos = new List<HLP.Comum.Resources.Models.modelToTreeView>();
                foreach (var i in lFilhos)
                {
                    nodeActual.lFilhos.Add(
                        item: new HLP.Comum.Resources.Models.modelToTreeView
                        {
                            id = (int)i.idFuncionario,
                            xDisplay = i.xNome + " - " + this.cargo_Repository.GetCargo(idCargo: f.idCargo).xDescricao
                        });
                }
            }
            return nodeTemp;
        }
    }
}
