using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.Comum.Infrastructure
{
    /// <summary>
    /// Classe base que controla os STATUS dos registros da GRID:
    /// (SemMudanca, Incluido, Alterado e Excluido)
    /// </summary>
    public class BaseModelFilhos
    {
        private int _ID = 0;
        public int GetID()
        {
            return _ID;
        }
        /// <summary>
        /// Método para setar Id. É usado no componente GRID para verificações.
        /// </summary>
        /// <param name="iID">Id da classe model que está herdando este método</param>
        protected void SetID(int? iID) 
        {
            if (iID == null)
            {
                _ID = 0;
            }
            else
            {
                _ID = Convert.ToInt32(iID);
            }
        }

        public enum statusRegistroFilho { SemMudanca, Incluido, Alterado, Excluido };

        private statusRegistroFilho _status = statusRegistroFilho.SemMudanca;
        public statusRegistroFilho GetStatusRegistro()
        {
            return _status;
        }
        public void SetStatusRegistro(statusRegistroFilho status)
        {
            _status = status;
        }
    }


}
