using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Comum.Resources.Util
{
    public static class Log
    {
        private static string _xPath;

        public static string xPath
        {
            get { return _xPath+@"\log.txt"; }
            set
            {

                _xPath = value;
                if (!Directory.Exists(path: _xPath))
                {
                    Directory.CreateDirectory(path: _xPath);
                }
            }
        }

        public static void AddLog(string xLog)
        {
            using (StreamWriter sw = File.AppendText(path: _xPath))
            {
                sw.WriteLine(value: DateTime.Now.ToString() + " - " + xLog);
            }
        }
    }
}
