using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Infrastructure;
using HLP.Comum.Model.Components;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ninject;

namespace HLP.Comum.Model.Repository.Interfaces.Components
{
    public interface IHlpPesquisaPadraoRepository
    {
        ObservableCollection<PesquisaPadraoModel> GetTableInformation(string sViewName);
    }
}
