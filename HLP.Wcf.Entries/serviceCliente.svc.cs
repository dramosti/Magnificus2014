using HLP.Comum.Model.Models;
using HLP.Comum.Resources.RecursosBases;
using HLP.Comum.Resources.Util;
using HLP.Dependencies;
using HLP.Entries.Model.Repository.Interfaces.Comercial;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "serviceCliente" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select serviceCliente.svc or serviceCliente.svc.cs at the Solution Explorer and start debugging.
    public class serviceCliente : IserviceCliente
    {
        [Inject]
        public ICliente_fornecedorRepository cliente_fornecedorRepository { get; set; }

        [Inject]
        public ICliente_fornecedor_arquivoRepository cliente_fornecedor_arquivoRepository { get; set; }

        [Inject]
        public ICliente_fornecedor_contatoRepository cliente_fornecedor_contatoRepository { get; set; }

        [Inject]
        public ICliente_fornecedor_EnderecoRepository cliente_fornecedor_enderecoRepository { get; set; }

        [Inject]
        public ICliente_Fornecedor_ObservacaoRepository cliente_fornecedor_observacaoRepository { get; set; }

        [Inject]
        public ICliente_fornecedor_produtoRepository cliente_fornecedor_produtoRepository { get; set; }

        [Inject]
        public ICliente_fornecedor_representanteRepository cliente_fornecedor_representanteRepository { get; set; }

        [Inject]
        public ICliente_fornecedor_fiscalRepository cliente_fornecedor_fiscalRepository { get; set; }

        public serviceCliente()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public HLP.Entries.Model.Models.Comercial.Cliente_fornecedorModel getCliente(int idCliente)
        {
            try
            {
                HLP.Entries.Model.Models.Comercial.Cliente_fornecedorModel objCliente =
                    this.cliente_fornecedorRepository.GetCliente_fornecedor(idClienteFornecedor: idCliente);

                if (objCliente == null)
                    return null;

                objCliente.cliente_fornecedor_fiscal = this.cliente_fornecedor_fiscalRepository.GetCliente_fornecedor_fiscal(
                    idClienteFornecedor: idCliente);

                objCliente.lCliente_fornecedor_arquivo = new ObservableCollectionBaseCadastros<HLP.Entries.Model.Models.Comercial.Cliente_fornecedor_arquivoModel>
                (list: this.cliente_fornecedor_arquivoRepository.GetAllCliente_fornecedor_arquivo(
                idClienteFornecedor: idCliente));

                objCliente.lCliente_fornecedor_contato = new ObservableCollectionBaseCadastros<HLP.Entries.Model.Models.Comercial.Cliente_fornecedor_contatoModel>
                (list: this.cliente_fornecedor_contatoRepository.GetAllCliente_fornecedor_contato(
                idClienteFornecedor: idCliente));

                objCliente.lCliente_fornecedor_Endereco = new ObservableCollectionBaseCadastros<HLP.Entries.Model.Models.Comercial.Cliente_fornecedor_EnderecoModel>
                (list: this.cliente_fornecedor_enderecoRepository.GetAllCliente_Fornecedor_Endereco(
                idClienteFornecedor: idCliente));

                objCliente.lCliente_Fornecedor_Observacao = new ObservableCollectionBaseCadastros<HLP.Entries.Model.Models.Comercial.Cliente_Fornecedor_ObservacaoModel>
                (list: this.cliente_fornecedor_observacaoRepository.GetAllCliente_Fornecedor_Observacao(
                idClienteFornecedor: idCliente));

                objCliente.lCliente_fornecedor_produto = new ObservableCollectionBaseCadastros<HLP.Entries.Model.Models.Comercial.Cliente_fornecedor_produtoModel>
                (list: this.cliente_fornecedor_produtoRepository.GetAllCliente_fornecedor_produto(
                idClienteFornecedor: idCliente));

                objCliente.lCliente_fornecedor_representante = new ObservableCollectionBaseCadastros<HLP.Entries.Model.Models.Comercial.Cliente_fornecedor_representanteModel>
                (list: this.cliente_fornecedor_representanteRepository.GetAllCliente_fornecedor_representante(
                idClienteFornecedor: idCliente));

                return objCliente;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public int saveCliente(HLP.Entries.Model.Models.Comercial.Cliente_fornecedorModel objCliente)
        {

            try
            {
                this.cliente_fornecedorRepository.BeginTransaction();
                this.cliente_fornecedorRepository.Save(objCliente_fornecedor: objCliente);
                this.cliente_fornecedor_fiscalRepository.Save(objCliente_fornecedor_fiscal:
                    objCliente.cliente_fornecedor_fiscal);


                foreach (HLP.Entries.Model.Models.Comercial.Cliente_fornecedor_arquivoModel item in objCliente.lCliente_fornecedor_arquivo)
                {
                    switch (item.status)
                    {
                        case statusModel.criado:
                        case statusModel.alterado:
                            {
                                item.idClienteFornecedor = (int)objCliente.idClienteFornecedor;
                                this.cliente_fornecedor_arquivoRepository.Save(objCliente_fornecedor_arquivo:
                                    item);
                            }
                            break;
                        case statusModel.excluido:
                            {
                                this.cliente_fornecedor_arquivoRepository.Delete(
                                    idClienteFornecedorArquivo: (int)item.idClienteFornecedorArquivo);
                            }
                            break;
                    }
                }


                foreach (HLP.Entries.Model.Models.Comercial.Cliente_fornecedor_contatoModel item in objCliente.lCliente_fornecedor_contato)
                {
                    switch (item.status)
                    {
                        case statusModel.criado:
                        case statusModel.alterado:
                            {
                                item.idClienteFornecedor = (int)objCliente.idClienteFornecedor;
                                this.cliente_fornecedor_contatoRepository.Save(
                                    objCliente_fornecedor_contato: item);
                            }
                            break;
                        case statusModel.excluido:
                            {
                                this.cliente_fornecedor_contatoRepository.DeletePorClienteFornecedor(
                                    idClienteFornecedor: (int)item.idClienteFornecedorContato);
                            }
                            break;
                    }
                }


                foreach (HLP.Entries.Model.Models.Comercial.Cliente_fornecedor_EnderecoModel item in objCliente.lCliente_fornecedor_Endereco)
                {
                    switch (item.status)
                    {
                        case statusModel.criado:
                        case statusModel.alterado:
                            {
                                item.idClienteFornecedor = (int)objCliente.idClienteFornecedor;
                                this.cliente_fornecedor_enderecoRepository.Save(
                                    objCliente_Fornecedor_Endereco: item);
                            }
                            break;
                        case statusModel.excluido:
                            {
                                this.cliente_fornecedor_enderecoRepository.DeletePorClienteFornecedor(
                                    idClienteFornecedor: (int)item.idEndereco);
                            }
                            break;
                    }
                }


                foreach (HLP.Entries.Model.Models.Comercial.Cliente_Fornecedor_ObservacaoModel item in objCliente.lCliente_Fornecedor_Observacao)
                {
                    switch (item.status)
                    {
                        case statusModel.criado:
                        case statusModel.alterado:
                            {
                                item.idClienteFornecedor = (int)objCliente.idClienteFornecedor;
                                this.cliente_fornecedor_observacaoRepository.Save(
                                    objCliente_Fornecedor_Observacao: item);
                            }
                            break;
                        case statusModel.excluido:
                            {
                                this.cliente_fornecedor_observacaoRepository.Delete(
                                    idClienteFornecedorObservacao: (int)item.idClienteFornecedorObservacao);
                            }
                            break;
                    }
                }


                foreach (HLP.Entries.Model.Models.Comercial.Cliente_fornecedor_produtoModel item in objCliente.lCliente_fornecedor_produto)
                {
                    switch (item.status)
                    {
                        case statusModel.criado:
                        case statusModel.alterado:
                            {
                                item.idClienteFornecedor = (int)objCliente.idClienteFornecedor;
                                this.cliente_fornecedor_produtoRepository.Save(
                                    objCliente_fornecedor_produto: item);
                            }
                            break;
                        case statusModel.excluido:
                            {
                                this.cliente_fornecedor_produtoRepository.Delete(idClienteFornecedorProduto:
                                    (int)item.idClienteFornecedorProduto);
                            }
                            break;
                    }
                }


                foreach (HLP.Entries.Model.Models.Comercial.Cliente_fornecedor_representanteModel item in objCliente.lCliente_fornecedor_representante)
                {
                    switch (item.status)
                    {
                        case statusModel.criado:
                        case statusModel.alterado:
                            {
                                item.idClienteFornecedor = (int)objCliente.idClienteFornecedor;
                                this.cliente_fornecedor_representanteRepository.Save(
                                    objCliente_fornecedor_representante: item);
                            }
                            break;
                        case statusModel.excluido:
                            {
                                item.idClienteFornecedor = (int)objCliente.idClienteFornecedor;
                                this.cliente_fornecedor_representanteRepository.Delete(
                                    idClienteFornecedorRepresentante: (int)item.idClienteFornecedorRepresentante);
                            }
                            break;
                    }
                }
                this.cliente_fornecedorRepository.CommitTransaction();
                return (int)objCliente.idClienteFornecedor;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                this.cliente_fornecedorRepository.RollackTransaction();
                throw new FaultException(reason: ex.Message);
            }
        }

        public bool deleteCliente(int idCliente)
        {

            try
            {
                this.cliente_fornecedor_arquivoRepository.DeletePorClienteFornecedor(
                    idClienteFornecedor: idCliente);
                this.cliente_fornecedor_contatoRepository.DeletePorClienteFornecedor(
                    idClienteFornecedor: idCliente);
                this.cliente_fornecedor_enderecoRepository.DeletePorClienteFornecedor(
                    idClienteFornecedor: idCliente);
                this.cliente_fornecedor_observacaoRepository.DeletePorClienteFornecedor(
                    idClienteFornecedor: idCliente);
                this.cliente_fornecedor_produtoRepository.DeletePorClienteFornecedor(
                    idClienteFornecedor: idCliente);
                this.cliente_fornecedor_representanteRepository.DeletePorClienteFornecedor(
                    idClienteFornecedor: idCliente);
                this.cliente_fornecedor_fiscalRepository.Delete(idClienteFornecedor: idCliente);
                this.cliente_fornecedorRepository.Delete(idClienteFornecedor: idCliente);
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public int copyCliente(HLP.Entries.Model.Models.Comercial.Cliente_fornecedorModel objCliente)
        {
            try
            {
                this.cliente_fornecedorRepository.Copy(objCliente_fornecedor:
                    objCliente);

                objCliente.cliente_fornecedor_fiscal.idClienteFornecedor = (int)objCliente.idClienteFornecedor;
                this.cliente_fornecedor_fiscalRepository.Copy(
                    objCliente.cliente_fornecedor_fiscal);

                foreach (HLP.Entries.Model.Models.Comercial.Cliente_fornecedor_arquivoModel item in objCliente.lCliente_fornecedor_arquivo)
                {
                    item.idClienteFornecedor = (int)objCliente.idClienteFornecedor;
                    this.cliente_fornecedor_arquivoRepository.Copy(
                        objCliente_fornecedor_arquivo: item);
                }

                foreach (HLP.Entries.Model.Models.Comercial.Cliente_fornecedor_contatoModel item in objCliente.lCliente_fornecedor_contato)
                {
                    item.idClienteFornecedor = (int)objCliente.idClienteFornecedor;
                    this.cliente_fornecedor_contatoRepository.Copy(
                        objCliente_fornecedor_contato: item);
                }

                foreach (HLP.Entries.Model.Models.Comercial.Cliente_fornecedor_EnderecoModel item in objCliente.lCliente_fornecedor_Endereco)
                {
                    item.idClienteFornecedor = (int)objCliente.idClienteFornecedor;
                    this.cliente_fornecedor_enderecoRepository.Copy(
                        objCliente_Fornecedor_Endereco: item);
                }

                foreach (HLP.Entries.Model.Models.Comercial.Cliente_Fornecedor_ObservacaoModel item in objCliente.lCliente_Fornecedor_Observacao)
                {
                    item.idClienteFornecedor = (int)objCliente.idClienteFornecedor;
                    this.cliente_fornecedor_observacaoRepository.Copy(
                        objCliente_Fornecedor_Observacao: item);
                }

                foreach (HLP.Entries.Model.Models.Comercial.Cliente_fornecedor_produtoModel item in objCliente.lCliente_fornecedor_produto)
                {
                    item.idClienteFornecedor = (int)objCliente.idClienteFornecedor;
                    this.cliente_fornecedor_produtoRepository.Copy(
                        objCliente_fornecedor_produto: item);
                }

                foreach (HLP.Entries.Model.Models.Comercial.Cliente_fornecedor_representanteModel item in objCliente.lCliente_fornecedor_representante)
                {
                    item.idClienteFornecedor = (int)objCliente.idClienteFornecedor;
                    this.cliente_fornecedor_representanteRepository.Copy(
                        objCliente_fornecedor_representante: item);
                }

                return (int)objCliente.idClienteFornecedor;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }
    }
}
