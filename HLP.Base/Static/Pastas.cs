using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;

namespace HLP.Base.Static
{
    public static class Pastas
    {
        public static string Path_SettingsUser
        {
            get
            {
                return Util.ValidaCaminho(Pastas.CaminhoPadraoRegWindows + "\\USER_" + UserData.idUser + "\\");
            }
        }

        public static string Path_Report(string xNameReport)
        {
            string xPath = Util.ValidaCaminho(System.AppDomain.CurrentDomain.BaseDirectory + "\\Reports\\");
            xPath += xNameReport;
            if (File.Exists("xPath"))
                return xPath;
            else
                return "";
        }

        public static string Path_Logs
        {
            get
            {
                return Util.ValidaCaminho(Application.Current.StartupUri.AbsolutePath + "\\LOGS\\");
            }
        }

        public static string Path_Settings_From_Sys
        {
            get
            {
                return Util.ValidaCaminho(Pastas.CaminhoPadraoRegWindows + "\\SYS_FORM\\");
            }
        }

        public static string CaminhoPadraoRegWindows
        {
            get
            {
                return Registry.CurrentConfig.OpenSubKey("magnificus").GetValue("caminhoPadrao").ToString();
            }
        }

        public static string Path_BasesConfiguradas
        {
            get { return @"\\hlpsrv\G\CSharp\Desenvolvimento\Projetos\Magnificus\BaseConfig\bases.xml"; }
        }


        public static string Path_TempReport
        {
            get
            {
                try
                {
                    return Util.ValidaCaminho(System.AppDomain.CurrentDomain.BaseDirectory + "\\TempReport\\" + Environment.MachineName + "\\");
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            //set { Pastas._CCe = value; }
        }
    }
}
