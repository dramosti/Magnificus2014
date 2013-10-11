using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.Comum.Infrastructure.Static
{
    public static class UserData
    {
        /// <summary>
        /// Usuário que esta logado no sistema.
        /// </summary>
        public static int idUser;
        /// <summary>
        /// Usuário padrão da HLP
        /// </summary>
        public static int idUserHLP = 0;
        /// <summary>
        /// Usuário configurado para ser DEFAULT para a configuração de telas do sistema.
        /// </summary>
        public static int idUserDEFAULT = 0;

        public static int idGrupoUsuario;
        public static string xNome;
        private static bool _bLogado = false;
        public static bool bLogado
        {
            get { return UserData._bLogado; }
            set { UserData._bLogado = value; }
        }
        public static string xPathBasicConfig
        {
            get
            {
                return Pastas.Path_SettingsUser + "\\UserBasicConfig" + ".xml";
            }
        }
    }
}
