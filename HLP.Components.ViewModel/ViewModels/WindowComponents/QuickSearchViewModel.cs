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

        public QuickSearchViewModel(Type modelType, object sender)
        {

            BindingExpression bExp = (sender as TextBox).GetBindingExpression(dp: TextBox.TextProperty);

            this.modelType = modelType;


            if (bExp != null)
            {
                this.xNameBinding = bExp.ParentBinding.Path.Path.Replace(oldValue: "currentModel.", newValue: "");
                PropertyInfo piField = this.modelType.GetProperty(name: this.xNameBinding);

                this.fieldType = piField.PropertyType;
            }

            if (modelType.GetProperties().Count(i => i.Name == "idEmpresa") > 1)
            {
                this.idEmpresa = CompanyData.idEmpresa;
            }
            else
            {
                this.idEmpresa = 0;
            }

            comm = new QuickSearchCommands(objViewModel: this);
        }

        private int _returnedId;

        public int returnedId
        {
            get { return _returnedId; }
            set { _returnedId = value; }
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

        private Type _modelType;

        public Type modelType
        {
            get { return _modelType; }
            set { _modelType = value; }
        }

        private int _idEmpresa;

        public int idEmpresa
        {
            get { return _idEmpresa; }
            set { _idEmpresa = value; }
        }

        private Type _fieldType;

        public Type fieldType
        {
            get { return _fieldType; }
            set { _fieldType = value; }
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
