using HLP.Base.ClassesBases;
using HLP.Base.Static;
using HLP.Components.Model.Models;
using HLP.Components.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HLP.Components.ViewModel.ViewModels
{
    public class FindAllViewModel : modelBase
    {
        public ICommand AddWindowCommand { get; set; }
        public ICommand CloseWindowCommand { get; set; }

        FindAllCommand objCommand;

        public FindAllViewModel()
        {
            objCommand = new FindAllCommand(this);
        }

        private ObservableCollection<FindAllModel> _lResult;
        public ObservableCollection<FindAllModel> lResult
        {
            get { return _lResult; }
            set
            {
                _lResult = value;
                base.NotifyPropertyChanged("lResult");
            }
        }

        void FindFormularios(string input)
        {
            try
            {
                foreach (var modules in Modulo.lobjectModulo)
                {
                    var result = modules.lFormularios.Where(c => c.xName.ToLower().Contains(input.ToLower()));

                    FindAllModel objFindAllModel;
                    foreach (var item in result)
                    {
                        objFindAllModel = new FindAllModel();
                        objFindAllModel.xNome = item.xId;
                        objFindAllModel.xHeader = item.xName.Replace("_", " ");
                        lResult.Add(objFindAllModel);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        void OpenWindow(object objSelected)
        {
            Window win = Util.GetParentWindow(objSelected as ListBox);
            win.Visibility = Visibility.Collapsed;
            FindAllModel obj = ((objSelected as ListBox).SelectedItem as FindAllModel);
            this.AddWindowCommand.Execute(parameter: obj.xNome);
            this.CloseWindowCommand.Execute(parameter: win);
        }

        #region Events
        public void m_txtTest_OnSearch(object sender, RoutedEventArgs e)
        {            
            UIControls.SearchEventArgs searchArgs = e as UIControls.SearchEventArgs;
            if (searchArgs.Sections.Count() == 0)
                searchArgs.Sections.Add("All");

            lResult = new ObservableCollection<FindAllModel>();

            foreach (var section in searchArgs.Sections)
            {
                switch (section)
                {
                    case "Formulários":
                        {
                            FindFormularios(searchArgs.Keyword);
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
                            FindFormularios(searchArgs.Keyword);
                        }
                        break;
                }
            }
        }
        public void lstResult_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            OpenWindow(sender);
        }
        public void lstResult_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
                OpenWindow(sender);
        }
        public void lstResult_GotFocus(object sender, RoutedEventArgs e)
        {
            if ((sender as ListBox).Items.Count > 0)
            {
                (sender as ListBox).SelectedIndex = 0;
            }
        }
        #endregion


    }

}
