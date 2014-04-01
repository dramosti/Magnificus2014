using HLP.Components.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Components.Model.Repository.Interfaces
{
    public interface IFillComboBoxRepository
    {
        List<modelToComboBox> GetAllCidadeToComboBox(string sNameView, string parameter);
    }
}
