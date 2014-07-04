using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Base.Static
{
    public class FileStatic
    {
        public static bool FileExists(string xPath)
        {
            return File.Exists(path: xPath);
        }

        public static void ExecuteFile(string xPath)
        {
            if (FileStatic.FileExists(xPath: xPath))
            {
                System.Diagnostics.Process.Start(xPath);
            }
        }

    }
}
