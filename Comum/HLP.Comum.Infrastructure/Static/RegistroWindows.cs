using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Comum.Infrastructure.Static
{
    public static class RegistroWindows
    {
        /// <summary>
        /// Verificação se Registro existe no registro do windows
        /// </summary>
        /// <param name="rR">Registro pai que será buscado o registro passada como parâmetro 
        /// no parâmetro nomeado sRegistry</param>
        /// <param name="sRegistry">Registro que será verificado no registro pai passado como parâmetro
        ///  no parâmetro nomeado rR</param>
        /// <returns>Retorna true se registro existe e em caso contrário, false</returns>
        public static bool VerificaRegistro(RegistryKey rR, string sRegistry)
        {
            RegistryKey vReg = null;
            vReg = rR.OpenSubKey(sRegistry);
            return vReg != null;
        }

        /// <summary>
        /// Criação de Registro no Registro do Windows
        /// </summary>
        /// <param name="rR">Registro pai que será feita as operações. Ex: Registry.CurrentConfig</param>
        /// <param name="sSkn">Registro que será criado de acordo com o valor informado no parametro sSk</param>
        /// <param name="sSk">Parâmetro opcional de registro contido no parametro rR que será aberto para criação do Registro passado como
        ///  parâmetro no parâmetro nomeado rR. Caso não seja passado nenhum valor será aberto o próprio Registro pai
        ///  passado como parâmetro no parâmetro nomeado rR.</param>
        public static void CriaRegistro(RegistryKey rR, string sSkn, string sSk = null)
        {
            string user = Environment.UserDomainName + "\\" + Environment.UserName;
            RegistrySecurity rs = new RegistrySecurity();
            rs.AddAccessRule(new RegistryAccessRule(user,
            RegistryRights.FullControl,
            InheritanceFlags.None,
            PropagationFlags.None,
            AccessControlType.Allow));
            RegistryKey rk = sSk != null ? rR.OpenSubKey(sSk, true) : rR;

            try
            {
                rk.CreateSubKey(sSkn);
            }
            catch (System.UnauthorizedAccessException)
            {
                throw new Exception("Erro ao configurar sistema, execute como administrador!");
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Setar valor de uma chave no registro do windows
        /// </summary>
        /// <param name="rR">Registro pai que será feita as operações. Ex: Registry.CurrentConfig</param>
        /// <param name="sSk">Registro onde será atribuida a chave para inserção de valor</param>
        /// <param name="xNameKey">Nome da chave que será inserido valor</param>
        /// <param name="sValue">Valor que será inserido na chave passada como parâmetro no parâmetro nomeado xNameKey</param>
        public static void SetaValueRegistro(RegistryKey rR, string sSk, string xNameKey, string sValue)
        {
            string user = Environment.UserDomainName + "\\" + Environment.UserName;
            RegistrySecurity rs = new RegistrySecurity();
            rs.AddAccessRule(new RegistryAccessRule(user,
            RegistryRights.FullControl,
            InheritanceFlags.None,
            PropagationFlags.None,
            AccessControlType.Allow));

            try
            {
                RegistryKey rk = rR.OpenSubKey(sSk, true);
                rk.SetValue(xNameKey, sValue);
            }
            catch (Exception)
            {

            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rR">Registro pai que será feita as operações. Ex: Registry.CurrentConfig</param>
        /// <param name="sSk">Registro que contém chave que será buscado valor para retorno</param>
        /// <param name="xNameKey">Chave onde será buscado valor para retorno</param>
        /// <returns>Valor obtido da chave passada como parâmetro no parâmetro nomeado xNameKey que retornará como tipo object</returns>
        public static object GetValueRegistro(RegistryKey rR, string sSk, string xNameKey)
        {
            string user = Environment.UserDomainName + "\\" + Environment.UserName;
            RegistrySecurity rs = new RegistrySecurity();
            rs.AddAccessRule(new RegistryAccessRule(user,
            RegistryRights.FullControl,
            InheritanceFlags.None,
            PropagationFlags.None,
            AccessControlType.Allow));
            RegistryKey rk = null;
            object value = null;
            try
            {
                rR.OpenSubKey(sSk, true);
                rk.GetValue(xNameKey);
            }
            catch (Exception)
            {

                throw;
            }



            rk.Close();
            return value;
        }
    }
}
