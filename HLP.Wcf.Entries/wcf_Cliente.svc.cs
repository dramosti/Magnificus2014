using HLP.Base.ClassesBases;
using HLP.Base.EnumsBases;
using HLP.Components.Model.Models;
using HLP.Components.Model.Repository.Interfaces;
using HLP.Base.Static;
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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_Cliente" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_Cliente.svc or wcf_Cliente.svc.cs at the Solution Explorer and start debugging.
    public class wcf_Cliente : Iwcf_Cliente
    {
        [Inject]
        public ICliente_fornecedorRepository cliente_fornecedorRepository { get; set; }

        [Inject]
        public ICliente_fornecedor_arquivoRepository cliente_fornecedor_arquivoRepository { get; set; }

        [Inject]
        public IContatoRepository cliente_fornecedor_contatoRepository { get; set; }

        [Inject]
        public IHlpEnderecoRepository cliente_fornecedor_enderecoRepository { get; set; }

        [Inject]
        public ICliente_Fornecedor_ObservacaoRepository cliente_fornecedor_observacaoRepository { get; set; }

        [Inject]
        public ICliente_fornecedor_produtoRepository cliente_fornecedor_produtoRepository { get; set; }

        [Inject]
        public ICliente_fornecedor_representanteRepository cliente_fornecedor_representanteRepository { get; set; }

        [Inject]
        public ICliente_fornecedor_fiscalRepository cliente_fornecedor_fiscalRepository { get; set; }

        public wcf_Cliente()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public HLP.Entries.Model.Models.Comercial.Cliente_fornecedorModel GetObject(int id)
        {
            try
            {
                HLP.Entries.Model.Models.Comercial.Cliente_fornecedorModel objCliente =
                    this.cliente_fornecedorRepository.GetCliente_fornecedor(idClienteFornecedor: id);

                if (objCliente == null)
                    return null;

                objCliente.cliente_fornecedor_fiscal = this.cliente_fornecedor_fiscalRepository.GetCliente_fornecedor_fiscal(
                    idClienteFornecedor: id);

                objCliente.lCliente_fornecedor_arquivo = new ObservableCollectionBaseCadastros<HLP.Entries.Model.Models.Comercial.Cliente_fornecedor_arquivoModel>
                (list: this.cliente_fornecedor_arquivoRepository.GetAllCliente_fornecedor_arquivo(
                idClienteFornecedor: id));

                objCliente.lCliente_fornecedor_contato = new ObservableCollectionBaseCadastros<ContatoModel>
                (list: this.cliente_fornecedor_contatoRepository.GetContato_ByForeignKey(
                id: id, xForeignKey: "idContatoClienteFornecedor"));

                objCliente.lCliente_fornecedor_Endereco = new ObservableCollectionBaseCadastros<EnderecoModel>
                (list: this.cliente_fornecedor_enderecoRepository.GetAllObjetos(
                idPK: id, sPK: "idClienteFornecedor"));

                objCliente.lCliente_Fornecedor_Observacao = new ObservableCollectionBaseCadastros<HLP.Entries.Model.Models.Comercial.Cliente_Fornecedor_ObservacaoModel>
                (list: this.cliente_fornecedor_observacaoRepository.GetAllCliente_Fornecedor_Observacao(
                idClienteFornecedor: id));

                objCliente.lCliente_fornecedor_produto = new ObservableCollectionBaseCadastros<HLP.Entries.Model.Models.Comercial.Cliente_fornecedor_produtoModel>
                (list: this.cliente_fornecedor_produtoRepository.GetAllCliente_fornecedor_produto(
                idClienteFornecedor: id));

                objCliente.lCliente_fornecedor_representante = new ObservableCollectionBaseCadastros<HLP.Entries.Model.Models.Comercial.Cliente_fornecedor_representanteModel>
                (list: this.cliente_fornecedor_representanteRepository.GetAllCliente_fornecedor_representante(
                idClienteFornecedor: id));

                return objCliente;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message + Environment.NewLine + ex.StackTrace);
                throw new FaultException(reason: ex.Message);
            }

        }

        public HLP.Entries.Model.Models.Comercial.Cliente_fornecedorModel Save(HLP.Entries.Model.Models.Comercial.Cliente_fornecedorModel obj)
        {
            try
            {
                this.cliente_fornecedorRepository.BeginTransaction();
                this.cliente_fornecedorRepository.Save(objCliente_fornecedor: obj);

                obj.cliente_fornecedor_fiscal.idClienteFornecedor = (int)obj.idClienteFornecedor;

                this.cliente_fornecedor_fiscalRepository.Save(objCliente_fornecedor_fiscal:
                    obj.cliente_fornecedor_fiscal);


                foreach (HLP.Entries.Model.Models.Comercial.Cliente_fornecedor_arquivoModel item in obj.lCliente_fornecedor_arquivo)
                {
                    switch (item.status)
                    {
                        case statusModel.criado:
                        case statusModel.alterado:
                            {
                                item.idClienteFornecedor = (int)obj.idClienteFornecedor;
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

                foreach (ContatoModel item in obj.lCliente_fornecedor_contato)
                {
                    switch (item.status)
                    {
                        case statusModel.criado:
                        case statusModel.alterado:
                            {

                                item.idContatoClienteFornecedor = (int)obj.idClienteFornecedor;
                                this.cliente_fornecedor_contatoRepository.Save(
                                    objContato: item);
                            }
                            break;
                        case statusModel.excluido:
                            {
                                this.cliente_fornecedor_contatoRepository.Delete(idContato:
                                    item.idContato ?? 0);
                            }
                            break;
                    }
                }


                foreach (EnderecoModel item in obj.lCliente_fornecedor_Endereco)
                {
                    switch (item.status)
                    {
                        case statusModel.criado:
                        case statusModel.alterado:
                            {
                                item.idClienteFornecedor = (int)obj.idClienteFornecedor;
                                this.cliente_fornecedor_enderecoRepository.Save(
                                    item);
                            }
                            break;
                        case statusModel.excluido:
                            {
                                this.cliente_fornecedor_enderecoRepository.Delete(objEnderecoModel: item);
                            }
                            break;
                    }
                }


                foreach (HLP.Entries.Model.Models.Comercial.Cliente_Fornecedor_ObservacaoModel item in obj.lCliente_Fornecedor_Observacao)
                {
                    switch (item.status)
                    {
                        case statusModel.criado:
                        case statusModel.alterado:
                            {
                                item.idClienteFornecedor = (int)obj.idClienteFornecedor;
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


                foreach (HLP.Entries.Model.Models.Comercial.Cliente_fornecedor_produtoModel item in obj.lCliente_fornecedor_produto)
                {
                    switch (item.status)
                    {
                        case statusModel.criado:
                        case statusModel.alterado:
                            {
                                item.idClienteFornecedor = (int)obj.idClienteFornecedor;
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


                foreach (HLP.Entries.Model.Models.Comercial.Cliente_fornecedor_representanteModel item in obj.lCliente_fornecedor_representante)
                {
                    switch (item.status)
                    {
                        case statusModel.criado:
                        case statusModel.alterado:
                            {
                                item.idClienteFornecedor = (int)obj.idClienteFornecedor;
                                this.cliente_fornecedor_representanteRepository.Save(
                                    objCliente_fornecedor_representante: item);
                            }
                            break;
                        case statusModel.excluido:
                            {
                                item.idClienteFornecedor = (int)obj.idClienteFornecedor;
                                this.cliente_fornecedor_representanteRepository.Delete(
                                    idClienteFornecedorRepresentante: (int)item.idClienteFornecedorRepresentante);
                            }
                            break;
                    }
                }
                this.cliente_fornecedorRepository.CommitTransaction();
                return obj;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                this.cliente_fornecedorRepository.RollackTransaction();
                throw new FaultException(reason: ex.Message);
            }
        }

        public bool Delete(int id)
        {
            try
            {
                this.cliente_fornecedorRepository.BeginTransaction();
                this.cliente_fornecedor_arquivoRepository.DeletePorClienteFornecedor(
                    idClienteFornecedor: id);
                this.cliente_fornecedor_contatoRepository.DeleteContato_ByForeignKey(id: id, xForeignKey: "idCliente");
                this.cliente_fornecedor_enderecoRepository.Delete(idFK: id,
                    sNameFK: "idClienteFornecedor");
                this.cliente_fornecedor_observacaoRepository.DeletePorClienteFornecedor(
                    idClienteFornecedor: id);
                this.cliente_fornecedor_produtoRepository.DeletePorClienteFornecedor(
                    idClienteFornecedor: id);
                this.cliente_fornecedor_representanteRepository.DeletePorClienteFornecedor(
                    idClienteFornecedor: id);
                this.cliente_fornecedor_fiscalRepository.Delete(idClienteFornecedor: id);
                this.cliente_fornecedorRepository.Delete(idClienteFornecedor: id);
                this.cliente_fornecedorRepository.CommitTransaction();
                return true;
            }
            catch (Exception ex)
            {
                this.cliente_fornecedorRepository.RollackTransaction();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public HLP.Entries.Model.Models.Comercial.Cliente_fornecedorModel Copy(HLP.Entries.Model.Models.Comercial.Cliente_fornecedorModel obj)
        {
            try
            {
                this.cliente_fornecedorRepository.BeginTransaction();

                this.cliente_fornecedorRepository.Copy(objCliente_fornecedor:
                    obj);

                obj.cliente_fornecedor_fiscal.idClienteFornecedor = (int)obj.idClienteFornecedor;
                this.cliente_fornecedor_fiscalRepository.Copy(
                    obj.cliente_fornecedor_fiscal);

                foreach (HLP.Entries.Model.Models.Comercial.Cliente_fornecedor_arquivoModel item in obj.lCliente_fornecedor_arquivo)
                {
                    item.idClienteFornecedor = (int)obj.idClienteFornecedor;
                    this.cliente_fornecedor_arquivoRepository.Copy(
                        objCliente_fornecedor_arquivo: item);
                }

                foreach (ContatoModel item in obj.lCliente_fornecedor_contato)
                {
                    item.idContatoClienteFornecedor = (int)obj.idClienteFornecedor;
                    this.cliente_fornecedor_contatoRepository.Copy(
                        obj: item);
                }

                foreach (EnderecoModel item in obj.lCliente_fornecedor_Endereco)
                {
                    item.idClienteFornecedor = (int)obj.idClienteFornecedor;
                    this.cliente_fornecedor_enderecoRepository.Copy(
                        objEnderecoModel: item);
                }

                foreach (HLP.Entries.Model.Models.Comercial.Cliente_Fornecedor_ObservacaoModel item in obj.lCliente_Fornecedor_Observacao)
                {
                    item.idClienteFornecedor = (int)obj.idClienteFornecedor;
                    this.cliente_fornecedor_observacaoRepository.Copy(
                        objCliente_Fornecedor_Observacao: item);
                }

                foreach (HLP.Entries.Model.Models.Comercial.Cliente_fornecedor_produtoModel item in obj.lCliente_fornecedor_produto)
                {
                    item.idClienteFornecedor = (int)obj.idClienteFornecedor;
                    this.cliente_fornecedor_produtoRepository.Copy(
                        objCliente_fornecedor_produto: item);
                }

                foreach (HLP.Entries.Model.Models.Comercial.Cliente_fornecedor_representanteModel item in obj.lCliente_fornecedor_representante)
                {
                    item.idClienteFornecedor = (int)obj.idClienteFornecedor;
                    this.cliente_fornecedor_representanteRepository.Copy(
                        objCliente_fornecedor_representante: item);
                }
                this.cliente_fornecedorRepository.CommitTransaction();
                return obj;
            }
            catch (Exception ex)
            {
                this.cliente_fornecedorRepository.RollackTransaction();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }
    }
}
