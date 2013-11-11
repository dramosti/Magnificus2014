using HLP.Comum.Resources.Util;
using HLP.Dependencies;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.Model.Repository.Interfaces.Gerais;
using Ninject;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HLP.Comum.Resources.RecursosBases;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "serviceEmpresa" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select serviceEmpresa.svc or serviceEmpresa.svc.cs at the Solution Explorer and start debugging.
    public class serviceEmpresa : IserviceEmpresa
    {
        [Inject]
        public IEmpresaRepository empresaRepository { get; set; }

        [Inject]
        public IEmpresa_EnderecoRepository empresa_EnderecoRepository { get; set; }

        public serviceEmpresa()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public EmpresaModel getEmpresa(int idEmpresa)
        {
            try
            {
                EmpresaModel objEmpresa = empresaRepository.GetEmpresa(idEmpresa: idEmpresa);
                objEmpresa.lEmpresa_endereco = new ObservableCollection<Empresa_EnderecoModel>(list: empresa_EnderecoRepository.GetAllEmpresa_Endereco(idEmpresa: idEmpresa));

                return objEmpresa;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw ex;
            }
        }

        public int saveEmpresa(EmpresaModel objEmpresa)
        {
            try
            {
                empresaRepository.Save(objEmpresa: objEmpresa);

                foreach (Empresa_EnderecoModel item in objEmpresa.lEmpresa_endereco)
                {
                    switch (item.status)
                    {
                        case statusModel.criado:
                        case statusModel.alterado:
                            {
                                empresa_EnderecoRepository.Save(objEmpresa_Endereco: item);
                            }
                            break;
                        case statusModel.excluido:
                            {
                                empresa_EnderecoRepository.Delete(objEmpresa_Endereco: item);
                            }
                            break;
                    }
                }

                return (int)objEmpresa.idEmpresa;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw ex;
            }
        }

        public bool delEmpresa(int idEmpresa)
        {
            try
            {
                empresa_EnderecoRepository.Delete(idEmpresa: idEmpresa);
                empresaRepository.Delete(idEmpresa: idEmpresa);
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                return false;
            }
        }

        public int copyEmpresa(EmpresaModel objEmpresa)
        {
            try
            {
                return empresaRepository.Copy(objModel: objEmpresa);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw ex;
            }
        }
    }
}
