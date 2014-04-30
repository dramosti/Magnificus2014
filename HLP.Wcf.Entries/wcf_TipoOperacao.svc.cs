using HLP.Base.ClassesBases;
using HLP.Base.EnumsBases;
using HLP.Base.Static;
using HLP.Dependencies;
using HLP.Entries.Model.Models.Fiscal;
using HLP.Entries.Model.Repository.Interfaces.Fiscal;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_TipoOperacao" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_TipoOperacao.svc or wcf_TipoOperacao.svc.cs at the Solution Explorer and start debugging.

    public class wcf_TipoOperacao : Iwcf_TipoOperacao
    {
        [Inject]
        public ITipo_operacaoRepository tipo_operacaoRepository { get; set; }

        [Inject]
        public IOperacao_reducao_baseRepository operacao_Reducao_BaseRepository { get; set; }

        public wcf_TipoOperacao()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public Tipo_operacaoModel GetObject(int id)
        {
            try
            {
                HLP.Entries.Model.Models.Fiscal.Tipo_operacaoModel objeto = this.tipo_operacaoRepository.GetOperacao(idTipoOperacao: id);

                if (objeto != null)
                {
                    objeto.lOperacaoReducaoBase = new ObservableCollectionBaseCadastros<Operacao_reducao_baseModel>(
                        list: this.operacao_Reducao_BaseRepository.GetAll(idTipoOperacao: id));
                }
                return objeto;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public Tipo_operacaoModel SaveObject(Tipo_operacaoModel obj)
        {
            try
            {
                this.tipo_operacaoRepository.Begin();
                this.tipo_operacaoRepository.Save(operacao: obj);


                foreach (HLP.Entries.Model.Models.Fiscal.Operacao_reducao_baseModel item in obj.lOperacaoReducaoBase)
                {
                    switch (item.status)
                    {
                        case statusModel.criado:
                        case statusModel.alterado:
                            {
                                item.idTipoOperacao = (int)obj.idTipoOperacao;
                                this.operacao_Reducao_BaseRepository.Save(operacaoReducao: item);
                            }
                            break;
                        case statusModel.excluido:
                            {
                                this.operacao_Reducao_BaseRepository.Delete(idOperacaoReducaoBase: (int)item.idOperacaoReducaoBase);
                            }
                            break;
                    }
                }


                this.tipo_operacaoRepository.Commit();
                return obj;
            }
            catch (Exception ex)
            {
                this.tipo_operacaoRepository.RollBack();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public bool DeleteObject(Tipo_operacaoModel obj)
        {
            try
            {
                List<int?> lIds = new List<int?>();

                foreach (HLP.Entries.Model.Models.Fiscal.Operacao_reducao_baseModel item in obj.lOperacaoReducaoBase)
                {
                    lIds.Add(item.idOperacaoReducaoBase);
                }

                this.tipo_operacaoRepository.Begin();
                this.operacao_Reducao_BaseRepository.Delete(idTipoOperacao: (int)obj.idTipoOperacao,
                    lidOperacaoReducaoBase: lIds);
                this.tipo_operacaoRepository.Delete(idTipoOperacao: (int)obj.idTipoOperacao);
                this.tipo_operacaoRepository.Commit();
                return true;
            }
            catch (Exception ex)
            {
                this.tipo_operacaoRepository.RollBack();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public Tipo_operacaoModel CopyObject(Tipo_operacaoModel obj)
        {
            try
            {
                this.tipo_operacaoRepository.Begin();
                int id = this.tipo_operacaoRepository.Copy(idTipoOperacao: (int)obj.idTipoOperacao);
                foreach (HLP.Entries.Model.Models.Fiscal.Operacao_reducao_baseModel it in obj.lOperacaoReducaoBase)
                {
                    it.idOperacaoReducaoBase = null;
                    it.idTipoOperacao = id;
                    this.operacao_Reducao_BaseRepository.Copy(operacaoReducaoBase: it);
                }

                this.tipo_operacaoRepository.Commit();

                return obj;
            }
            catch (Exception ex)
            {
                this.tipo_operacaoRepository.RollBack();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }
    }

}
