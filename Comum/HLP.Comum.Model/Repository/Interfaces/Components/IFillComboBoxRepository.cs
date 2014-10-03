using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Comum.Model.Repository.Interfaces.Components
{
    public interface IFillComboBoxRepository
    {
        IEnumerable<HLP.Comum.Model.Models.modelToComboBox> GetAllCidadeToComboBox(string sNameView, string parameter);
    }
}
