using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using HLP.Comum.Model.Models;
using HLP.Comum.Modules;

namespace HLP.Comum.ViewModel.ViewModels
{
    public class FindAllViewModel : modelBase
    {

        public FindAllViewModel(Control ctrFind)
        {

            
        }

        private FindAllModel _lResult;
        public FindAllModel lResult
        {
            get { return _lResult; }
            set { _lResult = value; base.NotifyPropertyChanged("lResult"); }
        }
        

        public void m_txtTest_OnSearch(object sender, RoutedEventArgs e)
        {
            UIControls.SearchEventArgs searchArgs = e as UIControls.SearchEventArgs;
            if (searchArgs.Sections.Count() == 0)
                searchArgs.Sections.Add("All");

            List<string> lResult = new List<string>();

            foreach (var section in searchArgs.Sections)
            {
                switch (section)
                {
                    case "Formulários":
                        {
                            FindFormularios(lResult, searchArgs.Keyword);
                        }
                        break;
                    case "Dashboards":
                        {

                        }
                        break;
                    case "Relatórios":
                        {

                        }
                        break;
                    default:
                        {
                            FindFormularios(lResult, searchArgs.Keyword);
                        }
                        break;
                }
            }
        }

        void FindFormularios(List<string> lresult, string input)
        {
            try
            {
                foreach (var modules in Modulo.lobjectModulo)
                {
                    var result = modules.lFormularios.Where(c => c.xName.ToLower().Contains(input.ToLower()));
                    lresult.AddRange(result.Select(c => c.xName).ToList());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
