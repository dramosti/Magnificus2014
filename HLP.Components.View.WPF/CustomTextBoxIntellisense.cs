using HLP.Components.ViewModel.ViewModels;
using HLP.Resources.View.WPF.Styles.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    ///     <MyNamespace:CustomTextBoxIntellisense/>
    ///
    /// </summary>
    public class CustomTextBoxIntellisense : TextBox
    {

        private CustomTextBoxIntellisenseViewModel _customViewModel;

        public CustomTextBoxIntellisenseViewModel customViewModel
        {
            get { return _customViewModel; }
            set { _customViewModel = value; }
        }

        Popup popUp;

        public CustomTextBoxIntellisense()
        {
            bool designTime = System.ComponentModel.DesignerProperties.GetIsInDesignMode(
    new DependencyObject());
            if (!designTime)
            {
                popUp = new Popup();
                popUp.PlacementTarget = this;
                popUp.Placement = PlacementMode.Bottom;

                popUp.MaxHeight = 200;
                this.customViewModel = new CustomTextBoxIntellisenseViewModel(popUp: popUp);

                this.GotFocus += CustomTextBoxIntellisense_GotFocus;
                this.KeyUp += CustomTextBoxIntellisense_KeyUp;

                AutoSelectTextBoxAttachedProperty.SetAutoSelect(obj: this, value: true);

                DataGrid dgv = new DataGrid();
                dgv.Style = new System.Windows.Style();
                dgv.IsReadOnly = true;
                dgv.KeyUp += dgv_KeyUp;
                dgv.MouseDoubleClick += dgv_MouseDoubleClick;
                dgv.SelectionUnit = DataGridSelectionUnit.FullRow;
                popUp.Child = dgv;
                dgv.HeadersVisibility = DataGridHeadersVisibility.Column;                
            }
        }

        void CustomTextBoxIntellisense_GotFocus(object sender, RoutedEventArgs e)
        {
            if (this.customViewModel.cvs == null)
                this.customViewModel.GetResult();

            (popUp.Child as DataGrid)
                .ItemsSource = this.customViewModel.cvs;
        }

        void dgv_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.GetSelectedItem();
        }

        void GetSelectedItem()
        {
            if (this.customViewModel != null)
                if (this.customViewModel.indexIdProperty >= 0)
                {
                    if (((this.popUp.Child as DataGrid).SelectedItem != null))
                    {
                        object vValue = ((this.popUp.Child as DataGrid).SelectedItem as DataRowView).Row.ItemArray[this.customViewModel.indexIdProperty];
                        int vIntValidated = 0;

                        if (vValue != null)
                            int.TryParse(s: vValue.ToString(), result: out vIntValidated);

                        this.selectedId = vIntValidated;

                        this.Text = string.Empty;
                        foreach (object item in ((this.popUp.Child as DataGrid).SelectedItem as DataRowView).Row.ItemArray)
                        {
                            if (item != null)
                                this.Text += this.Text == "" ? item.ToString() : " - " + item.ToString();
                        }
                    }
                }
        }

        void dgv_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Focus();
            }
            else if (e.Key == Key.Enter)
            {
                this.GetSelectedItem();
            }
        }

        void CustomTextBoxIntellisense_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                DataGridRow r = (this.popUp.Child as DataGrid).ItemContainerGenerator.ContainerFromIndex(index: 0) as DataGridRow;

                if (r != null)
                    r.MoveFocus(request: new TraversalRequest(focusNavigationDirection: FocusNavigationDirection.Next));

                (this.popUp.Child as DataGrid).SelectedIndex = this.customViewModel.cvs.Count > 0 ? 0 : -1;
            }
            else if (e.Key == Key.Escape)
            {
                this.popUp.IsOpen = false;
            }
        }

        public string xNameView
        {
            get { return this.customViewModel.xNameView; }
            set
            {
                bool designTime = System.ComponentModel.DesignerProperties.GetIsInDesignMode(
    new DependencyObject());
                if (!designTime)
                {
                    this.customViewModel.xNameView = value;
                }
            }
        }

        #region Dependencies Properties

        public int selectedId
        {
            get { return (int)GetValue(selectedIdProperty); }
            set { SetValue(selectedIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for selectedId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty selectedIdProperty =
            DependencyProperty.Register("selectedId", typeof(int), typeof(CustomTextBoxIntellisense), new PropertyMetadata(
                defaultValue: 0, propertyChangedCallback: new PropertyChangedCallback(SelectedIdChanged)));

        public static void SelectedIdChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            if (d != null)
            {
                (d as CustomTextBoxIntellisense).customViewModel.GetResult();

                ((d as CustomTextBoxIntellisense).customViewModel.cvs as BindingListCollectionView)
                    .CustomFilter = String.Format(format: "Id = {0}", arg0: args.NewValue);

                (d as CustomTextBoxIntellisense).customViewModel.cvs.MoveCurrentToFirst();


                (d as CustomTextBoxIntellisense).Text = String.Empty;

                if ((d as CustomTextBoxIntellisense).customViewModel.cvs.CurrentItem != null)
                {
                    foreach (object item in ((d as CustomTextBoxIntellisense).customViewModel.cvs.CurrentItem as DataRowView).Row.ItemArray)
                    {
                        if (item != null)
                            (d as CustomTextBoxIntellisense).Text += (d as CustomTextBoxIntellisense).Text == "" ?
                                item.ToString() : " - " + item.ToString();
                    }
                }
            }
        }

        #endregion
    }
}
