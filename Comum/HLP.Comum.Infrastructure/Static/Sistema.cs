using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Threading;

namespace HLP.Comum.Infrastructure.Static
{
    public class Sistema
    {
        public static ContatoStatic contatoStatico = new ContatoStatic();
        public static TipoSender stSender = TipoSender.Sistema;
        public struct ContatoStatic
        {
            public string nmTable { get; set; }
            public string fkTableReferencia { get; set; }
            public int idFkReferencia { get; set; }
            public int idFkContato { get; set; }
        }
        public static List<System.Configuration.KeyValueConfigurationElement> lSettings { get; set; }

        public static TipoConexao bOnline { get; set; }

        public static Window GetOpenWindow(string xName)
        {

            Window wd = null;
            if (Application.Current != null)
            {
                Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, (Action)(() =>
                {
                    foreach (Window item in Application.Current.Windows)
                    {
                        if (item.Name == xName)
                            wd = item;
                    }
                }));
            }
            return wd;

        }
    }

    public enum TipoConexao
    {
        OnlineRede,
        OnlineInternet,
        Offline
    }

    public enum TipoSender
    {
        WCF,
        Sistema
    }
}
