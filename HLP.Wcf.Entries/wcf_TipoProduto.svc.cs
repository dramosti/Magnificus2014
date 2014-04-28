using HLP.Base.Static;
using HLP.Dependencies;
using HLP.Entries.Model.Comercial;
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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_TipoProduto" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_TipoProduto.svc or wcf_TipoProduto.svc.cs at the Solution Explorer and start debugging.

    public class wcf_TipoProduto : Iwcf_TipoProduto
    {
        [Inject]
        public ITipo_produtoRepository tipo_ProdutoRepository { get; set; }

        public wcf_TipoProduto()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public Tipo_produtoModel GetObject(int id)
        {
            try
            {
                //IMPLEMENTAR GET
                return this.tipo_ProdutoRepository.GetTipo(idTipoProduto: id);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public int SaveObject(Tipo_produtoModel obj)
        {
            try
            {
                //IMPLEMENTAR SAVE
                tipo_ProdutoRepository.Save(tipo: obj);
                return obj.idTipoProduto ?? 0;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public bool DeleteObject(int id)
        {
            try
            {
                //IMPLEMENTAR DELETE
                tipo_ProdutoRepository.Delete(idTipoProduto: id);
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public Tipo_produtoModel CopyObject(int id)
        {
            try
            {
                //IMPLEMENTAR COPY
                return this.GetObject(id:
                    this.tipo_ProdutoRepository.Copy(idTipoProduto: id));
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }
    }

}
