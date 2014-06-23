using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Models.RecursosHumanos
{
    public class EspelhoPontoPrintModel
    {
        public EspelhoPontoPrintModel()
        {
            lHeaderFuncionario = new List<HeaderEspelhoPontoPrintModel>();
        }
        public int idEmpresa { get; set; }
        public string xEmpresa { get; set; }
        public string xEndereco { get; set; }
        public string xMesAno { get; set; }
        public string xCnpj { get; set; }
        public List<HeaderEspelhoPontoPrintModel> lHeaderFuncionario;
    }

    public class HeaderEspelhoPontoPrintModel
    {
        public HeaderEspelhoPontoPrintModel()
        {
            itemsPonto = new List<ItemsPontoModel>();
        }
        public int idEmpresa { get; set; }
        public int idFuncionario { get; set; }
        public string xNomeFuncionario { get; set; }
        public string xCpf { get; set; }
        public string xCodigoAlternativo { get; set; }
        public int? idCalendario { get; set; }

        public string xHoraSeqQuinta { get; set; }
        public string xHoraSexta { get; set; }
        public string xIntervalos { get; set; }

        public string dtMes { get; set; }
        public int iTotalDiasTrabalhados { get; set; }
        public string xHorasTrabalhadas { get; set; }
        public string xHorasAtrabalhar { get; set; }
        public string xSaldoMes { get; set; }
        public string xBancoHoras { get; set; }

        public List<ItemsPontoModel> itemsPonto { get; set; }
    }

    public class ItemsPontoModel
    {
        public int idFuncionario { get; set; }
        public string data { get; set; }
        public string hRegistrado { get; set; }
        public string hTrabalhada { get; set; }
        public string xOcorrencia { get; set; }
    }
}
