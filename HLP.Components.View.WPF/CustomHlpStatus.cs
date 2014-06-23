using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    ///     <MyNamespace:CustomHlpStatus/>
    ///
    /// </summary>
    public class CustomHlpStatus : StackPanel
    {
        static CustomHlpStatus()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomHlpStatus), new FrameworkPropertyMetadata(typeof(CustomHlpStatus)));
        }

        public CustomHlpStatus()
        {
            bool designTime = System.ComponentModel.DesignerProperties.GetIsInDesignMode(
    new DependencyObject());

            if (!designTime)
            {
                this.Orientation = System.Windows.Controls.Orientation.Horizontal;
                this.lStatus = new ObservableCollection<string>();
                this.lStatusInterrompidos = new ObservableCollection<int>();

                this.lStatus.CollectionChanged += lStatus_CollectionChanged;
            }
        }

        void lStatus_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            CheckBox cb = null;

            foreach (string item in e.NewItems)
            {
                cb = new CheckBox();
                cb.Content = item;
                cb.IsEnabled = false;
                cb.Width = 60;

                ResourceDictionary resource = new ResourceDictionary
                {
                    Source = new Uri("/HLP.Resources.View.WPF;component/Styles/Components/UserControlStyles.xaml", UriKind.RelativeOrAbsolute)
                };

                foreach (CheckBox cbInStk in this.Children)
                {
                    cbInStk.Style = resource["CheckBoxStatus_SEM_ANIMACAO"] as Style;
                }

                this.Children.Add(
                    element: cb);

                cb.Style = cb.Style = resource["CheckBoxStatusSimples"] as Style;
            }
        }

        private ObservableCollection<int> _lStatusInterrompidos;

        public ObservableCollection<int> lStatusInterrompidos
        {
            get { return _lStatusInterrompidos; }
            set { _lStatusInterrompidos = value; }
        }


        private ObservableCollection<string> _lStatus;

        public ObservableCollection<string> lStatus
        {
            get { return _lStatus; }
            set
            {
                _lStatus = value;
            }
        }

        public byte selectedStatus
        {
            get { return (byte)GetValue(selectedStatusProperty); }
            set { SetValue(selectedStatusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for selectedStatus.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty selectedStatusProperty =
            DependencyProperty.Register("selectedStatus", typeof(byte), typeof(CustomHlpStatus), new PropertyMetadata(defaultValue: byte.MaxValue,
                propertyChangedCallback: new PropertyChangedCallback(SelectedStatusChanged)));

        private static void SelectedStatusChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            bool designTime = System.ComponentModel.DesignerProperties.GetIsInDesignMode(
    new DependencyObject());

            if (!designTime)
            {
                if (e.NewValue != null)
                {

                    if ((d as StackPanel).Children != null)
                    {
                        ResourceDictionary resource = new ResourceDictionary
                        {
                            Source = new Uri("/HLP.Resources.View.WPF;component/Styles/Components/UserControlStyles.xaml", UriKind.RelativeOrAbsolute)
                        };
                        int count = 0;
                        int iSelectedStatus = 0;

                        int.TryParse(s: e.NewValue.ToString(), result: out iSelectedStatus);

                        foreach (CheckBox cb in (d as StackPanel).Children)
                        {
                            if (count > iSelectedStatus)
                            {
                                cb.IsChecked = false;
                            }
                            else
                            {
                                cb.IsChecked = true;
                            }

                            if ((count + 1) == (d as StackPanel).Children.Count)
                            {
                                cb.Style = resource["CheckBoxStatusSimples"] as Style;
                                cb.Content = (d as CustomHlpStatus).lStatus.LastOrDefault();
                            }
                            else if (count == iSelectedStatus)
                            {
                                cb.Style = resource["CheckBoxStatus_COM_ANIMACAO"] as Style;
                            }
                            else
                            {
                                cb.Style = resource["CheckBoxStatus_SEM_ANIMACAO"] as Style;
                            }
                            count++;
                        }

                        foreach (int stInterrompidos in (d as CustomHlpStatus).lStatusInterrompidos)
                        {
                            if (iSelectedStatus == stInterrompidos)
                            {

                                CheckBox cb = (d as CustomHlpStatus).Children[index: ((d as CustomHlpStatus).Children.Count - 1)] as CheckBox;

                                cb.Style = resource["CheckBox_CANCELADO"] as Style;
                                cb.Content = "Perdido";
                            }
                        }
                    }

                }
            }
        }

    }
}
