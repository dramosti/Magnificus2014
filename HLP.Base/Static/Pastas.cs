using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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

        public static string Path_Report_Especifico
        {
            get
            {
                return Util.ValidaCaminho(Pastas.CaminhoPadraoRegWindows + "\\RELATORIOS\\");
            }
        }
        public static string Path_Report
        {
            get
            {
                return Util.ValidaCaminho(Application.Current.StartupUri.AbsolutePath + "\\RELATORIOS\\");
            }
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

    }
}
