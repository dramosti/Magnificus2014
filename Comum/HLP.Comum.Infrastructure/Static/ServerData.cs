using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
namespace HLP.Comum.Infrastructure.Static
{
    public class ServerData
    {

        public static string USER_ID { get; set; }
        public static string PASSWORD { get; set; }

        public static void Refresh()
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                string[] sconnectionString = config.ConnectionStrings.ConnectionStrings["dbPrincipal"].ConnectionString.Split(';');

                foreach (string item in sconnectionString)
                {
                    if (item.Contains("User"))
                    {
                        USER_ID = item.Replace("User Id=", "").Trim();
                    }
                    if (item.Contains("Password"))
                    {
                        PASSWORD = item.Replace("Password=", "").Trim();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
