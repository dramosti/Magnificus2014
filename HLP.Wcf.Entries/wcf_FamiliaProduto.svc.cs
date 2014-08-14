using HLP.Base.ClassesBases;
using HLP.Base.EnumsBases;
using HLP.Components.Model.Models;
using HLP.Comum.Resources.Util;
using HLP.Dependencies;
using HLP.Entries.Model.Models.Gerais;
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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_FamiliaProduto" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_FamiliaProduto.svc or wcf_FamiliaProduto.svc.cs at the Solution Explorer and start debugging.
    public class wcf_FamiliaProduto : Iwcf_FamiliaProduto
    {
        [Inject]
        public IFamilia_ProdutoRepository iFamilia_ProdutoRepository { get; set; }
        [Inject]
        public IFamilia_Produto_ClassesRepository iFamilia_Produto_ClassesRepository { get; set; }

        public wcf_FamiliaProduto()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public HLP.Entries.Model.Models.Gerais.Familia_produtoModel GetObject(int idFamiliaProduto)
        {

            try
            {
                HLP.Entries.Model.Models.Gerais.Familia_produtoModel objFamiliaProd = iFamilia_ProdutoRepository.GetFamilia_produto(idFamiliaProduto);
                if (objFamiliaProd != null)
                {
                    objFamiliaProd.lFamilia_Produto_ClassesModel = new ObservableCollectionBaseCadastros<HLP.Entries.Model.Models.Gerais.Familia_Produto_ClassesModel>(iFamilia_Produto_ClassesRepository.GetAllFamilia_Produto_Classes(idFamiliaProduto));
                }
                return objFamiliaProd;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }


        }

        public HLP.Entries.Model.Models.Gerais.Familia_produtoModel Save(HLP.Entries.Model.Models.Gerais.Familia_produtoModel familia_produto)
        {
            try
            {
                iFamilia_ProdutoRepository.BeginTransaction();

                iFamilia_ProdutoRepository.Save(familia_produto);

                foreach (var item in familia_produto.lFamilia_Produto_ClassesModel)
                {
                    switch (item.status)
                    {
                        case statusModel.criado:
                        case statusModel.alterado:
                            {
                                item.idFamiliaProduto = (int)familia_produto.idFamiliaProduto;
                                iFamilia_Produto_ClassesRepository.Save(item);
                            }
                            break;
                        case statusModel.excluido:
                            {
                                iFamilia_Produto_ClassesRepository.Delete((int)item.idFamilia_Produto_Classes);
                            }
                            break;
                    }
                }
                iFamilia_ProdutoRepository.CommitTransaction();
                return familia_produto;
            }
            catch (Exception ex)
            {
                iFamilia_ProdutoRepository.RollackTransaction();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public bool Delete(int idFamiliaProduto)
        {
            try
            {
                iFamilia_ProdutoRepository.BeginTransaction();
                iFamilia_Produto_ClassesRepository.DeleteFamiliasPorFamilia(idFamiliaProduto);
                iFamilia_ProdutoRepository.Delete(idFamiliaProduto);
                iFamilia_ProdutoRepository.CommitTransaction();
                return true;
            }
            catch (Exception ex)
            {
                iFamilia_ProdutoRepository.RollackTransaction();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public HLP.Entries.Model.Models.Gerais.Familia_produtoModel Copy(HLP.Entries.Model.Models.Gerais.Familia_produtoModel familia_produto)
        {
            try
            {
                iFamilia_ProdutoRepository.BeginTransaction();
                familia_produto.idFamiliaProduto = iFamilia_ProdutoRepository.Copy(familia_produto);

                foreach (var item in familia_produto.lFamilia_Produto_ClassesModel)
                {
                    item.idFamiliaProduto = (int)familia_produto.idFamiliaProduto;
                    iFamilia_Produto_ClassesRepository.Copy(item);
                }
                iFamilia_ProdutoRepository.CommitTransaction();
                return familia_produto;
            }
            catch (Exception ex)
            {
                iFamilia_ProdutoRepository.RollackTransaction();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public List<HLP.Entries.Model.Models.Gerais.Familia_produtoModel> GetAll()
        {
            return this.iFamilia_ProdutoRepository.GetAll();
        }

        public List<modelToTreeView> GetHierarquia(string xMask, string xCodAlt)
        {
            List<modelToTreeView> lHieraquia = new List<modelToTreeView>();

            List<char> specialChars = new List<char>
            {
                '.', ',', '(', ')', '-', '_', '{', '}', '[', ']', '\\', '/'
            };

            int lengthMask = xMask.Count(i => !specialChars.Contains(item: i));

            string xMaskedValue = HLP.Base.Static.Util.ReturnValueMasked(xMask: xMask, _value: xCodAlt);

            List<Familia_produtoModel> lFamiliaProduto = this.iFamilia_ProdutoRepository.GetFamiliaProdutoSinteticos(
                        xValue: xMaskedValue.Split(separator: specialChars.ToArray())[0], xLength: lengthMask.ToString());

            Familia_produtoModel curFamiliaProduto;

            modelToTreeView baseNode = null;
            modelToTreeView parentNode = new modelToTreeView();

            while (true)
            {
                if (lFamiliaProduto.Count == 0)
                    break;
                else
                {
                    curFamiliaProduto = lFamiliaProduto.FirstOrDefault();

                    xMaskedValue = HLP.Base.Static.Util.ReturnValueMasked(xMask: xMask, _value: curFamiliaProduto.xFamiliaProduto);
                    string currentSubGroupCurFamiliaProduto = string.Empty;
                    string previewedValue = string.Empty;
                    Familia_produtoModel f = null;

                    foreach (string subGroupCurFamiliaProduto in xMaskedValue.Split(separator: specialChars.ToArray()))
                    {
                        previewedValue = (currentSubGroupCurFamiliaProduto + subGroupCurFamiliaProduto).PadRight(totalWidth: lengthMask
                                    , paddingChar: '0');

                        this.GetNode(nd: baseNode,
                            xValue: HLP.Base.Static.Util.ReturnValueMasked(
                                    xMask: xMask, _value: currentSubGroupCurFamiliaProduto.PadRight(totalWidth: lengthMask
                                    , paddingChar: '0')),
                            ndReturned: out parentNode);

                        if (parentNode != null)
                        {
                            if (parentNode.xIdAlternativo !=
                                HLP.Base.Static.Util.ReturnValueMasked(
                                    xMask: xMask, _value: previewedValue))
                                if (parentNode.lFilhos.Count(i => i.xIdAlternativo == HLP.Base.Static.Util.ReturnValueMasked(
                                    xMask: xMask, _value: previewedValue)) == 0)
                                {
                                    f = this.iFamilia_ProdutoRepository.GetFamiliaProdutoByxFamilia(xValue:
                                        previewedValue);

                                    parentNode.lFilhos.Add(item:
                                        new modelToTreeView
                                        {
                                            xIdAlternativo = HLP.Base.Static.Util.ReturnValueMasked(
                                            xMask: xMask, _value: previewedValue),
                                            xDisplay = f.xDescricao
                                        });
                                }
                        }
                        else
                        {
                            f = this.iFamilia_ProdutoRepository.GetFamiliaProdutoByxFamilia(xValue:
                                        previewedValue);

                            if (baseNode == null && f != null)
                                baseNode = new modelToTreeView
                                {
                                    xIdAlternativo = HLP.Base.Static.Util.ReturnValueMasked(
                                            xMask: xMask, _value: previewedValue),
                                    xDisplay = f.xDescricao
                                };
                        }

                        currentSubGroupCurFamiliaProduto += subGroupCurFamiliaProduto;
                    }
                    lFamiliaProduto.Remove(item: curFamiliaProduto);
                }
            }

            lHieraquia.Add(item: baseNode);
            return lHieraquia;
        }

        private void GetNode(modelToTreeView nd, string xValue, out modelToTreeView ndReturned)
        {
            ndReturned = null;
            if (nd == null)
            {
                return;
            }

            if (nd.xIdAlternativo == xValue)
            {
                ndReturned = nd;
                return;
            }

            modelToTreeView ndAux = nd.lFilhos.FirstOrDefault(i => i.xIdAlternativo == xValue);

            if (ndAux != null)
            {
                ndReturned = ndAux;
                return;
            }
            else
            {
                foreach (modelToTreeView n in nd.lFilhos)
                {
                    this.GetNode(nd: n, xValue: xValue, ndReturned: out ndReturned);
                }
            }
        }
    }
}
