using HLP.Base.ClassesBases;
using HLP.Base.EnumsBases;
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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_Empresa" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_Empresa.svc or wcf_Empresa.svc.cs at the Solution Explorer and start debugging.

    public class wcf_Empresa : Iwcf_Empresa
    {
        [Inject]
        public IEmpresaRepository empresaRepository { get; set; }

        [Inject]
        public IEmpresa_EnderecoRepository empresa_EnderecoRepository { get; set; }

        public wcf_Empresa()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public EmpresaModel GetObject(int id)
        {
            try
            {
                HLP.Entries.Model.Models.Gerais.EmpresaModel objEmpresa = empresaRepository.GetEmpresa(idEmpresa: id);
                if (objEmpresa != null)
                {
                    var list = empresa_EnderecoRepository.GetAllEmpresa_Endereco(idEmpresa: id);

                    if (list != null)
                        objEmpresa.lEmpresa_endereco = new ObservableCollectionBaseCadastros<HLP.Entries.Model.Models.Gerais.Empresa_EnderecoModel>(list: list);
                }

                return objEmpresa;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw ex;
            }
        }

        public EmpresaModel SaveObject(EmpresaModel obj)
        {
            empresaRepository.BeginTransaction();
            empresaRepository.Save(objEmpresa: obj);

            foreach (HLP.Entries.Model.Models.Gerais.Empresa_EnderecoModel item in obj.lEmpresa_endereco)
            {
                switch (item.status)
                {
                    case statusModel.criado:
                    case statusModel.alterado:
                        {
                            item.idEmpresa = (int)obj.idEmpresa;
                            empresa_EnderecoRepository.Save(objEmpresa_Endereco: item);
                        }
                        break;
                    case statusModel.excluido:
                        {
                            empresa_EnderecoRepository.Delete(idEmpresaEndereco: (int)item.idEmpresaEndereco);
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
                empresa_EnderecoRepository.DeleteEnderecoPorIdEmpresa(idEmpresa: id);
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

        public EmpresaModel CopyObject(EmpresaModel obj)
        {
            try
            {
                empresaRepository.BeginTransaction();
                empresaRepository.Copy(objModel: obj);
                foreach (HLP.Entries.Model.Models.Gerais.Empresa_EnderecoModel item in obj.lEmpresa_endereco)
                {
                    item.idEmpresa = (int)obj.idEmpresa;
                    empresa_EnderecoRepository.Copy(objEmpresa_Endereco: item);
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
