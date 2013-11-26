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
                objEmpresa.lEmpresa_endereco = new ObservableCollectionBaseCadastros<HLP.Entries.Model.Models.Gerais.Empresa_EnderecoModel>(list: empresa_EnderecoRepository.GetAllEmpresa_Endereco(idEmpresa: idEmpresa));

                return objEmpresa;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw ex;
            }
        }

        public int saveEmpresa(HLP.Entries.Model.Models.Gerais.EmpresaModel objEmpresa)
        {
            try
            {
                //objEmpresa = empresaRepository.GetEmpresa(1);
                //objEmpresa.lEmpresa_endereco = new ObservableCollectionBaseCadastros<HLP.Entries.Model.Models.Gerais.Empresa_EnderecoModel>(
                //    empresa_EnderecoRepository.GetAllEmpresa_Endereco(1));

                //objEmpresa.lEmpresa_endereco.Add(
                //    new HLP.Entries.Model.Models.Gerais.Empresa_EnderecoModel
                //    {
                //        idEmpresa = 1,
                //        idCidade = 1,
                //        Cep = "13304394",
                //        nro = "247",
                //        status = statusModel.criado,
                //        stPrincipal = 1,
                //        StTipoEnd = 1,
                //        xBairro = "Pq. América",
                //        xCpl = "A",
                //        xCxPostal = "1",
                //        xLgr = "Rua João Pereira de Góes"
                //    });

                empresaRepository.Save(objEmpresa: objEmpresa);

                foreach (HLP.Entries.Model.Models.Gerais.Empresa_EnderecoModel item in objEmpresa.lEmpresa_endereco)
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
                                empresa_EnderecoRepository.Delete(idEmpresaEndereco: (int)item.idEmpresaEndereco);
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
                empresa_EnderecoRepository.DeleteEnderecoPorIdEmpresa(idEmpresa: idEmpresa);
                empresaRepository.Delete(idEmpresa: idEmpresa);
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                return false;
            }
        }

        public int copyEmpresa(HLP.Entries.Model.Models.Gerais.EmpresaModel objEmpresa)
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

        public int Save(HLP.Entries.Model.Models.Gerais.EmpresaModel objEmpresa)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int idEmpresa)
        {
            throw new NotImplementedException();
        }
    }
}
