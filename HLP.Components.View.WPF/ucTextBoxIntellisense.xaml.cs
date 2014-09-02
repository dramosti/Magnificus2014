using HLP.Base.ClassesBases;
using HLP.Components.ViewModel.ViewModels;
using HLP.Resources.View.WPF.Styles.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
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
    /// Interaction logic for ucTextBoxIntellisense.xaml
    /// </summary>
    public partial class ucTextBoxIntellisense : UserControl
    {
        public ucTextBoxIntellisense()
        {
            InitializeComponent();
            bool designTime = System.ComponentModel.DesignerProperties.GetIsInDesignMode(
    new DependencyObject());
            this.parentIsDataGrid = false;
            if (!designTime)
            {
                this.customViewModel = new CustomTextBoxIntellisenseViewModel(popUp: this.popUp);
                this.popUp.IsOpen = false;
                this.popUp.StaysOpen = false;

                AutoSelectTextBoxAttachedProperty.SetAutoSelect(obj: this.txt, value: true);
                this.txt.KeyDown += txt_KeyDown;
                this.txt.KeyUp += txt_KeyUp;
                this.popUp.Opened += popUp_Opened;
                (this.popUp.Child as DataGrid).KeyUp += this.dgv_KeyUp;
                (this.popUp.Child as DataGrid).PreviewKeyDown += ucDataGrid_PreviewKeyDown;
                (this.popUp.Child as DataGrid).MouseDoubleClick += ucTextBoxIntellisense_MouseDoubleClick;
                this.LostFocus += ucTextBoxIntellisense_LostFocus;

                foreach (MenuItem item in this.txt.ContextMenu.Items)
                {
                    if (item.Name == "insertItem")
                    {
                        item.Command = this.customViewModel.insertCommand;
                        item.CommandParameter = this;
                    }
                    else if (item.Name == "goItem")
                    {
                        item.Command = this.customViewModel.goToRecordCommand;
                        item.CommandParameter = this;
                    }
                }
            }
        }

        void ucTextBoxIntellisense_LostFocus(object sender, RoutedEventArgs e)
        {
            if (this.actionOnLostFocus != null)
            {
                Type t = this.actionOnLostFocus.GetType();

                if (t == typeof(RelayCommand))
                {
                    if (((RelayCommand)this.actionOnLostFocus).CanExecute(parameter: null))
                        ((RelayCommand)this.actionOnLostFocus).Execute(parameter: null);
                }
                else if (t == typeof(Action<object>))
                {
                    ((Action<object>)this.actionOnLostFocus).Invoke(obj: this.actionParameter);
                }
                else
                {
                    ((Action)this.actionOnLostFocus).Invoke();
                }
            }
        }

        void popUp_Opened(object sender, EventArgs e)
        {
            if (this.customViewModel != null)
                this.customViewModel.GetResult();
        }

        private CustomTextBoxIntellisenseViewModel _customViewModel;

        public CustomTextBoxIntellisenseViewModel customViewModel
        {
            get { return _customViewModel; }
            set { _customViewModel = value; }
        }

        private object _actionOnLostFocus;

        public object actionOnLostFocus
        {
            get { return _actionOnLostFocus; }
            set { _actionOnLostFocus = value; }
        }

        private object _actionParameter;

        public object actionParameter
        {
            get { return _actionParameter; }
            set { _actionParameter = value; }
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

        private bool _parentIsDataGrid;

        public bool parentIsDataGrid
        {
            get { return _parentIsDataGrid; }
            set { _parentIsDataGrid = value; }
        }

        #region Dependencies Properties

        public int selectedId
        {
            get { return (int)GetValue(selectedIdProperty); }
            set
            {
                SetValue(selectedIdProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for selectedId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty selectedIdProperty =
            DependencyProperty.Register("selectedId", typeof(int), typeof(ucTextBoxIntellisense), new PropertyMetadata(
                defaultValue: 0, propertyChangedCallback: new PropertyChangedCallback(SelectedIdChanged)));

        public static void SelectedIdChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            if (d != null && args.NewValue != null)
            {
                if ((d as ucTextBoxIntellisense).refMethod != null)
                    (d as ucTextBoxIntellisense).model = (d as ucTextBoxIntellisense).refMethod.Invoke(arg: (int)args.NewValue);

                (d as ucTextBoxIntellisense).txt.Text = String.Empty;

                if (((d as ucTextBoxIntellisense).customViewModel.cvs != null))
                {
                    ((d as ucTextBoxIntellisense).customViewModel.cvs as BindingListCollectionView)
                        .CustomFilter = String.Format(format: "Id = {0}", arg0: args.NewValue);

                    (d as ucTextBoxIntellisense).customViewModel.cvs.MoveCurrentToFirst();

                    if ((d as ucTextBoxIntellisense).customViewModel.cvs.CurrentItem != null)
                    {
                        string xText = String.Empty;

                        foreach (object item in ((d as ucTextBoxIntellisense).customViewModel.cvs.CurrentItem as DataRowView).Row.ItemArray)
                        {
                            if (item != null)
                                xText += xText == "" ?
                                    item.ToString() : " - " + item.ToString();
                        }

                        (d as ucTextBoxIntellisense).txt.Text = xText;
                    }
                }
            }
        }

        public object model
        {
            get { return (object)GetValue(modelProperty); }
            set { SetValue(modelProperty, value); }
        }

        public Func<int, object> refMethod
        {
            get { return (Func<int, object>)GetValue(refMethodProperty); }
            set { SetValue(refMethodProperty, value); }
        }

        // Using a DependencyProperty as the backing store for refMethod.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty refMethodProperty =
            DependencyProperty.Register("refMethod", typeof(Func<int, object>), typeof(ucTextBoxIntellisense), new PropertyMetadata(null));



        // Using a DependencyProperty as the backing store for model.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty modelProperty =
            DependencyProperty.Register("model", typeof(object), typeof(ucTextBoxIntellisense),
            new PropertyMetadata(defaultValue: null));

        public bool ucEnabled
        {
            get { return (bool)GetValue(ucEnabledProperty); }
            set { SetValue(ucEnabledProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ucEnabled.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ucEnabledProperty =
            DependencyProperty.Register("ucEnabled", typeof(bool), typeof(ucTextBoxIntellisense), new PropertyMetadata(true));

        #endregion

        #region Events
        private void SelectItem()
        {
            if (this.customViewModel.selectedItem != null)
            {
                int intValidated = 0;
                object vValue = this.customViewModel.selectedItem.Row.ItemArray[this.customViewModel.indexIdProperty];

                if (vValue != null)
                    if (int.TryParse(s: vValue.ToString(),
                        result: out intValidated))
                    {
                        this.selectedId = 0;
                        this.selectedId = intValidated;
                    }
            }
        }

        void dgv_KeyUp(object sender, KeyEventArgs e)
        {
        }

        void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.popUp.IsOpen = false;
            }
            else if (e.Key == Key.Tab)
                this.SelectItem();
            else if (e.Key == Key.F5 && this.ucEnabled)
                this.customViewModel.searchCommand.Execute(parameter: this);

            if (this.parentIsDataGrid)
                if (e.Key == Key.Up || e.Key == Key.Left || e.Key == Key.Right)
                    this.SelectItem();
        }

        void ucTextBoxIntellisense_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.SelectItem();
        }

        void ucDataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.txt.Focus();
            }
            else if (e.Key == Key.Enter)
            {
                this.SelectItem();
                this.txt.Focus();
            }
        }

        void txt_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                this.popUp.IsOpen = true;

                DataGridRow r = (this.popUp.Child as DataGrid).ItemContainerGenerator.ContainerFromIndex(index: 0) as DataGridRow;

                if (r != null)
                    r.MoveFocus(request: new TraversalRequest(focusNavigationDirection: FocusNavigationDirection.Next));

                (this.popUp.Child as DataGrid).SelectedIndex = this.customViewModel.cvs.Count > 0 ? 0 : -1;

            }
            else if (this.parentIsDataGrid)
            {
                if (e.Key == Key.Right || e.Key == Key.Left || e.Key == Key.Up)
                    this.SelectItem();
            }

        }
        #endregion
    }
}
