using HLP.Base.Static;
using HLP.Components.Model.Models;
using HLP.Entries.Model.Models.Gerais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.ViewModel.Services.Gerais
{
    public class FuncionarioService
    {
        HLP.Wcf.Entries.wcf_Funcionario servicoRede;
        wcf_Funcionario.Iwcf_FuncionarioClient servicoInternet;

        public FuncionarioService()
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    break;
                case StConnection.OnlineWeb:
                    break;
                case StConnection.Offline:
                    break;
                default:
                    break;
            }
        }

        public FuncionarioModel Save(FuncionarioModel objModel)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.servicoRede.saveFuncionario(objFuncionario: objModel);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.servicoInternet.saveFuncionario(objFuncionario: objModel);
                    }
            }
            return null;
        }

        public bool Delete(FuncionarioModel objModel)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.servicoRede.deleteFuncionario(idFuncionario: objModel.idFuncionario ?? 0);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.servicoInternet.deleteFuncionario(idFuncionario: objModel.idFuncionario ?? 0);
                    }
            }
            return false;
        }

        public FuncionarioModel Copy(FuncionarioModel objModel)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.servicoRede.copyFuncionario(objFuncionario: objModel);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.servicoInternet.copyFuncionario(objFuncionario: objModel);
                    }
            }
            return null;
        }

        public FuncionarioModel GetObjeto(int id)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.servicoRede.getFuncionario(idFuncionario: id);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.servicoInternet.getFuncionario(idFuncionario: id);
                    }
            }
            return null;
        }

        public modelToTreeView GetHierarquia(int idFuncionario)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.servicoRede.GetHierarquiaFuncionario(idFuncionario: idFuncionario);
                    }
                case StConnection.OnlineWeb:
                    {
                        //return this.servicoInternet.GetHierarquiaFuncionario(idFuncionario: idFuncionario);
                        return new modelToTreeView();
                    }
            }
            return null;
        }

        //private void ConvertModelWcfToModel(HLP.Entries.ViewModel.wcf_Funcionario.modelToTreeView mWcf, modelToTreeView m)
        //{
        //    m.id = mWcf.id;
        //    m.xDisplay = mWcf.xDisplay;

        //    foreach (var item in mWcf.lFilhos)
        //    {
        //        m.lFilhos.Add(item:
        //            new modelToTreeView
        //            {
        //                id = item.id,
        //                xDisplay = item.xDisplay
        //            });

        //        if (item.lFilhos.Count > 0)
        //            this.ConvertModelWcfToModel(mWcf: mWcf, m: m);
        //    }
        //}
    }
}
