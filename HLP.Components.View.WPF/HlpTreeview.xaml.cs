using HLP.Base.EnumsBases;
using HLP.Components.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for HlpTreeView.xaml
    /// </summary>
    public partial class HlpTreeView : UserControl
    {
        public HlpTreeView()
        {
            InitializeComponent();
            

            bool designTime = System.ComponentModel.DesignerProperties.GetIsInDesignMode(
    new DependencyObject());

            if (!designTime)
            {
                this.customDataContext = new HlpTreeviewViewModel();
            }
        }

        public string selectedValue
        {
            get { return (string)GetValue(selectedValueProperty); }
            set { SetValue(selectedValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for selectedValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty selectedValueProperty =
            DependencyProperty.Register("selectedValue", typeof(string), typeof(HlpTreeView),
            new PropertyMetadata(defaultValue: string.Empty, propertyChangedCallback: new PropertyChangedCallback(SelectedValueChanged)));

        public static void SelectedValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            bool designTime = System.ComponentModel.DesignerProperties.GetIsInDesignMode(
    new DependencyObject());
            if (!designTime)
            {
                if (args.NewValue != null)
                    (d as HlpTreeView).customDataContext.selectedValue = args.NewValue.ToString();
            }
        }

        private HlpTreeviewViewModel _customDataContext;

        public HlpTreeviewViewModel customDataContext
        {
            get { return _customDataContext; }
            set { _customDataContext = value; }
        }

        public stAcoesHierarquia loadTreeView
        {
            get { return (stAcoesHierarquia)GetValue(loadTreeViewProperty); }
            set { SetValue(loadTreeViewProperty, value); }
        }

        // Using a DependencyProperty as the backing store for loadTreeView.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty loadTreeViewProperty =
            DependencyProperty.Register("loadTreeView", typeof(stAcoesHierarquia), typeof(HlpTreeView), new PropertyMetadata(
                defaultValue: stAcoesHierarquia.nothing,
                propertyChangedCallback: new PropertyChangedCallback(loadChanged)));

        public static void loadChanged(DependencyObject d, DependencyPropertyChangedEventArgs a)
        {
            switch ((stAcoesHierarquia)a.NewValue)
            {
                case stAcoesHierarquia.load:
                    {
                        (d as HlpTreeView).customDataContext.GetHierarquia();
                    }
                    break;
                case stAcoesHierarquia.clear:
                    {
                        (d as HlpTreeView).customDataContext.ClearHierarquia();
                    }
                    break;
                case stAcoesHierarquia.nothing:
                    break;
                default:
                    break;
            }
        }
    }
}
