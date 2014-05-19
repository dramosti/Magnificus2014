using HLP.Base.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace HLP.Base.ClassesBases
{
    public class MessageHlp
    {
        public MessageBoxResult OpenMessageWindow(StMessage stMessage, string xMessageToUser,
            string xErrorCode = "", string xMessageFramework = "")
        {
            string xType = "";
            object[] _params = null;
            switch (stMessage)
            {
                case StMessage.stYesNo:
                    {
                        xType = "HlpMessageYesNo";
                        _params = new object[] { xMessageToUser };
                    } break;
                case StMessage.stAlert:
                    {
                        xType = "HlpMessageAlert";
                        _params = new object[] { xMessageToUser };
                    } break;
                case StMessage.stError:
                    {
                        xType = "HlpMessageError";
                        _params = new object[] { xErrorCode, xMessageToUser, xMessageFramework };
                    } break;

                default:
                    break;
            }

            object _return = Sistema.ExecuteMethodByReflection(xNamespace: "HLP.Comum.View.WPF", xType: xType, xMethod: "ShowMessage",
                            parameters: _params);

            if (_return != null)
                return (MessageBoxResult)_return;

            return MessageBoxResult.None;
        }

        private bool _bSave = false;
        public bool bSave
        {
            get { return _bSave; }
            set { _bSave = value; }
        }

        public bool Save()
        {
            bool? bReturn = null;

            try
            {
                Application.Current.Dispatcher.BeginInvoke((Action)(()
                =>
                {
                    if (this.OpenMessageWindow(stMessage: StMessage.stYesNo, xMessageToUser: "Deseja salvar o registro?")
                == MessageBoxResult.Yes)
                    {
                        bReturn = true;
                    }
                    else
                        bReturn = false;

                    bSave = (bool)bReturn;
                }));
            }
            catch (Exception)
            {
                
                throw;
            }
            

            while (true)
            {
                if (bReturn != null)
                {
                    break;
                }
                Thread.Sleep(millisecondsTimeout: 300);
            }

            return bReturn ?? false;

        }


        public bool Excluir()
        {
            bool? bReturn = null;

            if (this.OpenMessageWindow(stMessage: StMessage.stYesNo, xMessageToUser: "Deseja excluir o registro?")
                == MessageBoxResult.Yes)
            {
                bReturn = true;
            }
            else
                bReturn = false;

            bSave = (bool)bReturn;

            return bReturn ?? false;
        }

        public void Excluido()
        {
            Application.Current.Dispatcher.BeginInvoke((Action)(()
                =>
            {
                this.OpenMessageWindow(stMessage: StMessage.stAlert, xMessageToUser: "Cadastro excluido com sucesso!");
            }));
        }

        public bool Cancelar()
        {
            bool? bReturn = null;

            if (this.OpenMessageWindow(stMessage: StMessage.stYesNo, xMessageToUser: "Deseja realmente cancelar a transação?")
                    == MessageBoxResult.Yes)
            {
                bReturn = true;
            }
            else
                bReturn = false;

            bSave = (bool)bReturn;

            return bReturn ?? false;
        }
    }

    public enum StMessage
    {
        stYesNo,
        stAlert,
        stError
    }
}
