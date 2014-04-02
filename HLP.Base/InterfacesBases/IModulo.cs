using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Base.InterfacesBases
{
    public interface IModulo
    {
        string NomeModulo { get; }

        string ArquivoConfiguracao { get; }

        void InicializarModulo();

        void DescarregarModulo();

        //void ExibirForm(string nome, TipoExibeForm exibeForm);
    }

    public enum TipoExibeForm
    {
        /// <summary>
        /// Executa show no Form
        /// </summary>
        Normal = 0,
        /// <summary>
        /// Executa showModal no Form
        /// </summary>
        Modal = 1
    }
}
