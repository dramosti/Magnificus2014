using HLP.Comum.Resources.Util;
using HLP.Dependencies;
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
using HLP.Comum.Model.Models;

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

        public HLP.Entries.Model.Models.Gerais.EmpresaModel getEmpresa(int idEmpresa)
        {
            try
            {
                HLP.Entries.Model.Models.Gerais.EmpresaModel objEmpresa = empresaRepository.GetEmpresa(idEmpresa: idEmpresa);
                if (objEmpresa != null)
                {
                    objEmpresa.lEmpresa_endereco = new ObservableCollectionBaseCadastros<HLP.Entries.Model.Models.Gerais.Empresa_EnderecoModel>(list: empresa_EnderecoRepository.GetAllEmpresa_Endereco(idEmpresa: idEmpresa));
                }

                return objEmpresa;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw ex;
            }
        }

        public HLP.Entries.Model.Models.Gerais.EmpresaModel Save(HLP.Entries.Model.Models.Gerais.EmpresaModel objEmpresa)
        {
            try
            {

                empresaRepository.BeginTransaction();
                empresaRepository.Save(objEmpresa: objEmpresa);

                foreach (HLP.Entries.Model.Models.Gerais.Empresa_EnderecoModel item in objEmpresa.lEmpresa_endereco)
                {
                    switch (item.status)
                    {
                        case statusModel.criado:
                        case statusModel.alterado:
                            {
                                item.idEmpresa = (int)objEmpresa.idEmpresa;
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
                return objEmpresa;
            }
            catch (Exception ex)
            {
                empresaRepository.RollackTransaction();
                Log.AddLog(xLog: ex.Message);
                throw ex;
            }
        }

        public bool Delete(int idEmpresa)
        {
            try
            {
                empresaRepository.BeginTransaction();
                empresa_EnderecoRepository.DeleteEnderecoPorIdEmpresa(idEmpresa: idEmpresa);
                empresaRepository.Delete(idEmpresa: idEmpresa);
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

        public HLP.Entries.Model.Models.Gerais.EmpresaModel copyEmpresa(HLP.Entries.Model.Models.Gerais.EmpresaModel objEmpresa)
        {
            try
            {
                empresaRepository.BeginTransaction();
                empresaRepository.Copy(objModel: objEmpresa);
                foreach (HLP.Entries.Model.Models.Gerais.Empresa_EnderecoModel item in objEmpresa.lEmpresa_endereco)
                {
                    item.idEmpresa = (int)objEmpresa.idEmpresa;
                    empresa_EnderecoRepository.Copy(objEmpresa_Endereco: item);
                }

                empresaRepository.CommitTransaction();
                return objEmpresa;
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
