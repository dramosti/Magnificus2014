using HLP.Base.ClassesBases;
using HLP.Base.EnumsBases;
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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_Acesso" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_Acesso.svc or wcf_Acesso.svc.cs at the Solution Explorer and start debugging.
    public class wcf_Acesso : Iwcf_Acesso
    {
        [Inject]
        public IAcessoRepository acessoRepository { get; set; }

        [Inject]
        public IFuncionarioRepository funcionarioRepository { get; set; }

        public wcf_Acesso()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public HLP.Entries.Model.Models.Gerais.FuncionarioModel Save(HLP.Entries.Model.Models.Gerais.FuncionarioModel objModel)
        {
            try
            {
                this.funcionarioRepository.BeginTransaction();
                objModel.xSenha = Criptografia.Encripta(strTexto: objModel.xSenha);
                this.funcionarioRepository.Save(objFuncionario: objModel);

                foreach (HLP.Entries.Model.Models.Gerais.Funcionario_AcessoModel item in objModel.lFuncionario_Acesso)
                {
                    switch (item.status)
                    {
                        case statusModel.criado:
                        case statusModel.alterado:
                            {
                                item.idFuncionario = (int)objModel.idFuncionario;
                                this.acessoRepository.Save(objAcesso: item);
                            }
                            break;
                        case statusModel.excluido:
                            {
                                this.acessoRepository.Delete(objAcesso: item);
                            }
                            break;
                    }
                }

                this.funcionarioRepository.CommitTransaction();
                objModel.xSenha = Criptografia.Decripta(strTexto: objModel.xSenha ?? "");
                return objModel;

            }
            catch (Exception ex)
            {
                this.funcionarioRepository.RollackTransaction();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public HLP.Entries.Model.Models.Gerais.FuncionarioModel GetObjeto(int idObjeto)
        {

            try
            {
                HLP.Entries.Model.Models.Gerais.FuncionarioModel objFuncionario =
                this.funcionarioRepository.GetFuncionario(idFuncionario: idObjeto);
                objFuncionario.xSenha = Criptografia.Decripta(strTexto: objFuncionario.xSenha ?? "");
                objFuncionario.lFuncionario_Acesso = new ObservableCollectionBaseCadastros<HLP.Entries.Model.Models.Gerais.Funcionario_AcessoModel>
                (this.acessoRepository.GetAllAcesso_Funcionario(idFuncionario: idObjeto));
                return objFuncionario;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public bool ValidaUsuario(string xLogin, string xSenha, int idFuncionario)
        {
            try
            {
                return this.acessoRepository.getCountLoginUsuario(xLogin: xLogin,
                    xSenha: Criptografia.Encripta(strTexto: xSenha),
                    idFuncionario: idFuncionario) == 0 ? true : false;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
