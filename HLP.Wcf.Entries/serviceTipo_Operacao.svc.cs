using HLP.Comum.Resources.RecursosBases;
using HLP.Comum.Resources.Util;
using HLP.Dependencies;
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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "serviceTipo_Operacao" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select serviceTipo_Operacao.svc or serviceTipo_Operacao.svc.cs at the Solution Explorer and start debugging.
    public class serviceTipo_Operacao : IserviceTipo_Operacao
    {
        [Inject]
        public ITipo_operacaoRepository tipo_operacaoRepository { get; set; }

        [Inject]
        public IOperacao_reducao_baseRepository operacao_Reducao_BaseRepository { get; set; }

        public serviceTipo_Operacao()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public HLP.Entries.Model.Models.Fiscal.Tipo_operacaoModel Save(HLP.Entries.Model.Models.Fiscal.Tipo_operacaoModel Objeto)
        {

            try
            {
                this.tipo_operacaoRepository.Begin();
                this.tipo_operacaoRepository.Save(operacao: Objeto);


                foreach (HLP.Entries.Model.Models.Fiscal.Operacao_reducao_baseModel item in Objeto.lOperacaoReducaoBase)
                {
                    switch (item.status)
                    {
                        case statusModel.criado:
                        case statusModel.alterado:
                            {
                                item.idTipoOperacao = (int)Objeto.idTipoOperacao;
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
                return Objeto;
            }
            catch (Exception ex)
            {
                this.tipo_operacaoRepository.RollBack();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public HLP.Entries.Model.Models.Fiscal.Tipo_operacaoModel GetObjeto(int idObjeto)
        {

            try
            {
                HLP.Entries.Model.Models.Fiscal.Tipo_operacaoModel objeto = this.tipo_operacaoRepository.GetOperacao(idTipoOperacao: idObjeto);

                if (objeto != null)
                {
                    objeto.lOperacaoReducaoBase = new Comum.Model.Models.ObservableCollectionBaseCadastros<HLP.Entries.Model.Models.Fiscal.Operacao_reducao_baseModel>(
                        list: this.operacao_Reducao_BaseRepository.GetAll(idTipoOperacao: idObjeto));
                }
                return objeto;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public bool Delete(HLP.Entries.Model.Models.Fiscal.Tipo_operacaoModel Objeto)
        {

            try
            {
                List<int?> lIds = new List<int?>();

                foreach (HLP.Entries.Model.Models.Fiscal.Operacao_reducao_baseModel item in Objeto.lOperacaoReducaoBase)
                {
                    lIds.Add(item.idOperacaoReducaoBase);
                }

                this.tipo_operacaoRepository.Begin();
                this.operacao_Reducao_BaseRepository.Delete(idTipoOperacao: (int)Objeto.idTipoOperacao,
                    lidOperacaoReducaoBase: lIds);
                this.tipo_operacaoRepository.Delete(idTipoOperacao: (int)Objeto.idTipoOperacao);
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

        public int Copy(HLP.Entries.Model.Models.Fiscal.Tipo_operacaoModel Objeto)
        {

            try
            {
                this.tipo_operacaoRepository.Begin();
                int id = this.tipo_operacaoRepository.Copy(idTipoOperacao: (int)Objeto.idTipoOperacao);
                foreach (HLP.Entries.Model.Models.Fiscal.Operacao_reducao_baseModel it in Objeto.lOperacaoReducaoBase)
                {
                    it.idOperacaoReducaoBase = null;
                    it.idTipoOperacao = id;
                    this.operacao_Reducao_BaseRepository.Copy(operacaoReducaoBase: it);
                }

                this.tipo_operacaoRepository.Commit();

                return id;
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
