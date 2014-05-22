using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HLP.Components.ViewModel.Commands.WindowComponents;
using System.Reflection;
using System.Windows.Data;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using HLP.Base.EnumsBases;
using HLP.Base.Static;

namespace HLP.Components.ViewModel.ViewModels.WindowComponents
{
    public class QuickSearchViewModel : INotifyPropertyChanged
    {
        public ICommand searchCommad { get; set; }
        public ICommand ChangeToEqualCommand { get; set; }
        public ICommand ChangeToStartWithCommand { get; set; }
        public ICommand ChangeToContainsCommand { get; set; }

        QuickSearchCommands comm;

        public QuickSearchViewModel(object model, object sender)
        {
            PropertyInfo pi = sender.GetType().GetProperty(name: "Binding");
            if (pi != null)
            {
                object o = pi.GetValue(sender);

                if (o != null)
                {
                    Binding b = o as Binding;

                    PropertyPath p = b.GetType().GetProperty(name: "Path").GetValue(obj: b) as PropertyPath;

                    this.xNameBinding = p.Path;
                }
            }

            PropertyInfo piIdEmpresa = model.GetType().GetProperty(name: "idEmpresa");

            this.idEmpresa = piIdEmpresa == null ? 0 : CompanyData.idEmpresa;

            comm = new QuickSearchCommands(objViewModel: this);
            this.model = model;
        }

        private int _returnedId;

        public int returnedId
        {
            get { return _returnedId; }
            set { _returnedId = value; }
        }


        private object _model;

        public object model
        {
            get { return _model; }
            set { _model = value; }
        }

        private object _sender;

        public object sender
        {
            get { return _sender; }
            set { _sender = value; }
        }

        private string _xNameBinding;

        public string xNameBinding
        {
            get { return _xNameBinding; }
            set { _xNameBinding = value; }
        }

        private string _xValue;

        public string xValue
        {
            get { return _xValue; }
            set
            {
                _xValue = value;
                this.NotifyPropertyChanged(propertyName: "xValue");
            }
        }

        private stFilterQuickSearch _stFilterQs;

        public stFilterQuickSearch stFilterQs
        {
            get { return _stFilterQs; }
            set
            {
                _stFilterQs = value;
                this.NotifyPropertyChanged(propertyName: "stFilterQs");
            }
        }

        private int _idEmpresa;

        public int idEmpresa
        {
            get { return _idEmpresa; }
            set { _idEmpresa = value; }
        }


        #region NotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
