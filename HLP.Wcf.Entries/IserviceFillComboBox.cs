﻿using HLP.Components.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IserviceFillComboBox" in both code and config file together.
    [ServiceContract]
    public interface IserviceFillComboBox
    {
        [OperationContract]
        IEnumerable<modelToComboBox> GetAllValuesToComboBox(string sNameView, string sParameter);
    }
}
