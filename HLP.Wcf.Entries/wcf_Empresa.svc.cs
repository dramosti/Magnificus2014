using HLP.Base.ClassesBases;
using HLP.Base.EnumsBases;
using HLP.Components.Model.Models;
using HLP.Components.Model.Repository.Interfaces;
using HLP.Base.Static;
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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_Empresa" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_Empresa.svc or wcf_Empresa.svc.cs at the Solution Explorer and start debugging.

    public class wcf_Empresa : Iwcf_Empresa
    {
        [Inject]
        public IEmpresaRepository empresaRepository { get; set; }

        [Inject]
        public IHlpEnderecoRepository hlpEnderecoRepository { get; set; }

        public wcf_Empresa()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public HLP.Entries.Model.Models.Gerais.EmpresaModel GetObject(int id)
        {
            try
            {
                HLP.Entries.Model.Models.Gerais.EmpresaModel objEmpresa = empresaRepository.GetEmpresa(idEmpresa: id);
                if (objEmpresa != null)
                {

                    var listaEndereco = this.hlpEnderecoRepository.GetAllObjetos(idPK:
                   id, sPK: "idEmpresa");
                    if (listaEndereco.Count > 0)
                        objEmpresa.lEmpresa_endereco = new ObservableCollectionBaseCadastros<EnderecoModel>(list:
                            listaEndereco);
                }

                return objEmpresa;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw ex;
            }
        }

        public HLP.Entries.Model.Models.Gerais.EmpresaModel SaveObject(HLP.Entries.Model.Models.Gerais.EmpresaModel obj)
        {
            empresaRepository.BeginTransaction();
            empresaRepository.Save(objEmpresa: obj);

            foreach (EnderecoModel item in obj.lEmpresa_endereco)
            {
                switch (item.status)
                {
                    case statusModel.criado:
                    case statusModel.alterado:
                        {
                            item.idEmpresa = (int)obj.idEmpresa;
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
          
            empresaRepository.CommitTransaction();
            return obj;
        }

        public bool DeleteObject(int id)
        {
            try
            {
                empresaRepository.BeginTransaction();
                this.hlpEnderecoRepository.Delete(id, "idEmpresa");
                empresaRepository.Delete(idEmpresa: id);
                empresaRepository.CommitTransaction();
                return true;
            }
            catch (Exception ex)
            {
                empresaRepository.RollackTransaction();
                Log.AddLog(xLog: ex.Message);
                return false;
            }
        }

        public HLP.Entries.Model.Models.Gerais.EmpresaModel CopyObject(HLP.Entries.Model.Models.Gerais.EmpresaModel obj)
        {
            try
            {
                empresaRepository.BeginTransaction();
                empresaRepository.Copy(objModel: obj);
                foreach (EnderecoModel item in obj.lEmpresa_endereco)
                {
                    item.idEmpresa = (int)obj.idEmpresa;
                    this.hlpEnderecoRepository.Copy(item);
                }

                empresaRepository.CommitTransaction();
                return obj;
            }
            catch (Exception ex)
            {
                empresaRepository.RollackTransaction();
                Log.AddLog(xLog: ex.Message);
                throw ex;
            }
        }
    }

}
