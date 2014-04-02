using HLP.Base.Static;
using HLP.Components.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Components.Services
{
    public class FillComboBoxService
    {
        Wcf.Entries.wcf_FillComboBox serviceNetwork;
        wcf_FillComboBox.Iwcf_FillComboBoxClient serviceWeb;

        public FillComboBoxService()
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        serviceNetwork = new Wcf.Entries.wcf_FillComboBox();
                    }
                    break;
                case StConnection.OnlineWeb:
                    {
                        serviceWeb = new wcf_FillComboBox.Iwcf_FillComboBoxClient();
                    }
                    break;
                case StConnection.Offline:
                    break;
                default:
                    break;
            }
        }

        public List<modelToComboBox> GetAllValuesToComboBox(string sNameView, string sParameter)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.serviceNetwork.GetAllValuesToComboBox(
                            sNameView: sNameView, sParameter: sParameter);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.serviceWeb.GetAllValuesToComboBox(
                            sNameView: sNameView, sParameter: sParameter);
                    }
                case StConnection.Offline:
                default:
                    {
                        return null;
                    }
            }
        }
    }
}
