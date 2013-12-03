using HLP.Entries.Model.Models.Gerais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Interfaces.Gerais
{
    public interface IFuncionario_CertificacaoRepository
    {
        void Save(Funcionario_CertificacaoModel objFuncionario_Certificacao);
        void Delete(Funcionario_CertificacaoModel objFuncionario_Certificacao);
        void Delete(int idFuncionario);
        void Copy(Funcionario_CertificacaoModel objFuncionario_Certificacao);
        Funcionario_CertificacaoModel GetFuncionario_Certificacao(int idFuncionarioCertificacao);
        List<Funcionario_CertificacaoModel> GetAllFuncionario_Certificacao(int idFuncionario);
    }
}
