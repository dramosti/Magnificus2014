using HLP.Base.ClassesBases;
using HLP.Components.ViewModel.ViewModels;
using HLP.Comum.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HLP.Components.View.WPF
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:HLP.Components.View.WPF"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:HLP.Components.View.WPF;assembly=HLP.Components.View.WPF"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:CustomDataGridIntellisenseColumn/>
    ///
    /// </summary>
    public class CustomDataGridIntellisenseColumn : DataGridBoundColumn
    {
        public CustomDataGridIntellisenseColumn()
        {
            bool designTime = System.ComponentModel.DesignerProperties.GetIsInDesignMode(
    new DependencyObject());

            if (!designTime)
            {
                this.customViewModel = new CustomTextBoxIntellisenseViewModel(popUp: null);
            }
        }

        private CustomTextBoxIntellisenseViewModel _customViewModel;

        public CustomTextBoxIntellisenseViewModel customViewModel
        {
            get { return _customViewModel; }
            set { _customViewModel = value; }
        }

        protected override object PrepareCellForEdit(FrameworkElement editingElement, RoutedEventArgs editingEventArgs)
        {
            base.PrepareCellForEdit(editingElement, editingEventArgs);

            FocusManager.SetFocusedElement(element: editingElement, value: (editingElement as ucTextBoxIntellisense).txt);

            return editingElement;
        }

        protected override bool CommitCellEdit(FrameworkElement editingElement)
        {
            if (editingElement.GetType() == typeof(ucTextBoxIntellisense))
                this.model = (editingElement as ucTextBoxIntellisense).model;
            return base.CommitCellEdit(editingElement);
        }

        protected override FrameworkElement GenerateEditingElement(DataGridCell cell, object dataItem)
        {
            ucTextBoxIntellisense txtIntellisense = new ucTextBoxIntellisense();
            txtIntellisense.parentIsDataGrid = true;

            Binding b = new Binding();
            b.Path = (this.Binding as Binding).Path;
            b.Mode = BindingMode.TwoWay;
            b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            b.NotifyOnValidationError = true;
            b.ValidatesOnDataErrors = true;
            txtIntellisense.SetBinding(dp: ucTextBoxIntellisense.selectedIdProperty, binding: b);

            Binding bModel = new System.Windows.Data.Binding();
            bModel.Path = new PropertyPath(path: this.xNamePropertyModel, pathParameters: new object[] { });

            if (!string.IsNullOrEmpty(value: bModel.Path.Path))
                txtIntellisense.SetBinding(dp: ucTextBoxIntellisense.modelProperty, binding: bModel);

            txtIntellisense.xNameView = this.xNameView;
            txtIntellisense.NameWindowCadastro = this.NameWindowCadastro;
            txtIntellisense.TableView = this.TableView;
            txtIntellisense.refMethod = this.refMethod;
            txtIntellisense.mainParameter = this.mainParameter;
            txtIntellisense.OptionalParameters = this.OptionalParameters;

            return txtIntellisense;
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
        }

        protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
        {
            TextBlock txt = new TextBlock();
            string xDisplay = string.Empty;

            if (dataItem != null)
                if (!dataItem.ToString().ToUpper().Contains(value: "NEWITEMPLACEHOLDER"))
                {
                    PropertyInfo piBinding = null;
                    string xPath = (this.Binding as Binding).Path.Path;

                    if ((this.Binding as Binding).Path.Path.Split(separator: '.').Count() > 0)
                    {
                        foreach (string path in (this.Binding as Binding).Path.Path.Split(separator: '.'))
                        {
                            if (path == (this.Binding as Binding).Path.Path.Split(separator: '.').Last())
                            {
                                xPath = path;
                                break;
                            }
                            piBinding = dataItem.GetType().GetProperty(name: path);
                            dataItem = piBinding.GetValue(obj: dataItem);
                        }

                    }

                    piBinding = null;
                    if (dataItem != null)
                        piBinding = dataItem.GetType().GetProperty(name: xPath);

                    if (piBinding != null)
                    {
                        int? id = piBinding.GetValue(obj: dataItem) as int?;
                        object obj = this.refMethod.Invoke(arg1: id ?? 0, arg2: true);
                        if (obj != null)
                        {
                            if (!string.IsNullOrEmpty(value: this.xNamePropertyModel))
                                dataItem.GetType().GetProperty(name: this.xNamePropertyModel).SetValue(obj: dataItem,
                                    value: obj);

                            PropertyInfo pi = null;

                            if (this.xFieldsToDisplay.Split(';').Count() > 0)
                            {
                                foreach (string field in this.xFieldsToDisplay.Split(';'))
                                {
                                    pi = obj.GetType().GetProperty(name: field);

                                    if (pi != null)
                                    {
                                        xDisplay += xDisplay != string.Empty ? " - " : string.Empty;

                                        xDisplay += pi.GetValue(obj: obj);
                                    }
                                }
                            }
                            else
                            {
                                pi = obj.GetType().GetProperties().FirstOrDefault(i => i.Name.StartsWith(value: "x"));

                                if (pi != null)
                                    xDisplay = pi.GetValue(obj: obj) as string;
                            }
                        }

                        if (dataItem.GetType().BaseType == typeof(modelBase)
                            || dataItem.GetType().BaseType == typeof(modelComum))
                        {
                            if ((dataItem as modelBase).lErrors.Count(i => i.xId == xPath) > 0)
                                txt.Background = Brushes.Red;
                            else
                                txt.Background = Brushes.Transparent;
                        }
                    }
                    txt.Text = xDisplay;
                }

            return txt;
        }

        #region Dependency Properties

        public object model
        {
            get { return (object)GetValue(modelProperty); }
            set { SetValue(modelProperty, value); }
        }

        public Func<int, bool, object> refMethod
        {
            get { return (Func<int, bool, object>)GetValue(refMethodProperty); }
            set { SetValue(refMethodProperty, value); }
        }


        [Category("HLP.Owner")]
        public string mainParameter
        {
            get { return (string)GetValue(mainParameterProperty); }
            set { SetValue(mainParameterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for mainParameter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty mainParameterProperty =
            DependencyProperty.Register("mainParameter", typeof(string), typeof(CustomDataGridIntellisenseColumn), new PropertyMetadata(defaultValue: null));

        private string _OptionalParameters;
        [Category("HLP.Owner")]
        public string OptionalParameters
        {
            get { return _OptionalParameters; }
            set
            {
                _OptionalParameters = value;

                if (value == null)
                    this.customViewModel.lParameters = null;
                else
                {
                    if (value.Count(i => i == ';') == 0)
                    {
                        this.customViewModel.lParameters = new string[] { value };
                    }
                    else
                        this.customViewModel.lParameters = value.Split(separator: ';').ToArray();
                }
            }
        }

        // Using a DependencyProperty as the backing store for refMethod.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty refMethodProperty =
            DependencyProperty.Register("refMethod", typeof(Func<int, bool, object>), typeof(CustomDataGridIntellisenseColumn), new PropertyMetadata(null));

        // Using a DependencyProperty as the backing store for model.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty modelProperty =
            DependencyProperty.Register("model", typeof(object), typeof(CustomDataGridIntellisenseColumn),
            new PropertyMetadata(defaultValue: null));

        #endregion

        #region Properties

        private string _xNamePropertyModel;
        [Category("HLP.Owner")]
        public string xNamePropertyModel
        {
            get { return _xNamePropertyModel; }
            set { _xNamePropertyModel = value; }
        }


        private string _xNameView;
        [Category("HLP.Owner")]
        public string xNameView
        {
            get { return this._xNameView; }
            set
            {
                this._xNameView = value;

                bool designTime = System.ComponentModel.DesignerProperties.GetIsInDesignMode(
    new DependencyObject());
                if (!designTime)
                {
                    this.customViewModel.xNameView = value;
                }
            }
        }

        private string _TableView;
        [Category("HLP.Owner")]
        public string TableView
        {
            get { return _TableView; }
            set { _TableView = value; }
        }

        private string _NameWindowCadastro;
        [Category("HLP.Owner")]
        public string NameWindowCadastro
        {
            get { return _NameWindowCadastro; }
            set { _NameWindowCadastro = value; }
        }

        private string _xFieldsToDisplay;
        [Category("HLP.Owner")]
        public string xFieldsToDisplay
        {
            get { return _xFieldsToDisplay; }
            set { _xFieldsToDisplay = value; }
        }

        #endregion
    }
}
