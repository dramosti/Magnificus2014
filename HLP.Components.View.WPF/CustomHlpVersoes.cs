using HLP.Base.ClassesBases;
using System;
using System.Collections;
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
    ///     <MyNamespace:CustomHlpVersoes/>
    ///
    /// </summary>
    public class CustomHlpVersoes : StackPanel
    {
        static CustomHlpVersoes()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomHlpVersoes), new FrameworkPropertyMetadata(typeof(CustomHlpVersoes)));
        }

        public CustomHlpVersoes()
        {
            this.ItemsSourceVersao = new ObservableCollection<int>();
            this.Orientation = System.Windows.Controls.Orientation.Horizontal;
        }


        public void btnClick(object sender, RoutedEventArgs e)
        {
            int vId = 0;

            if ((sender as Button).Content != null)
                int.TryParse(s: (sender as Button).Content.ToString(), result: out vId);



            this.DataContext.GetType().GetProperty(name:
                "currentModel").SetValue(obj: this.DataContext, value: null);

            this.DataContext.GetType().GetProperty(name:
                "currentID").SetValue(obj: this.DataContext, value: vId);

            MyObservableCollection<int> lIds = new MyObservableCollection<int>();

            lIds.Add(item: vId);

            this.DataContext.GetType().GetProperty(name:
                "currentID").SetValue(obj: this.DataContext, value: vId);

            this.DataContext.GetType().GetProperty(name:
                "navigatePesquisa").SetValue(obj: this.DataContext, value: lIds);

            System.ComponentModel.BackgroundWorker bw = this.DataContext.GetType().GetProperty(name:
                "bWorkerPesquisa").GetValue(obj: this.DataContext) as System.ComponentModel.BackgroundWorker;

            if (bw != null)
                bw.RunWorkerAsync();
        }

        // Using a DependencyProperty as the backing store for lIdsHierarquia.  This enables animation, styling, binding, etc...
        public IEnumerable ItemsSourceVersao
        {
            get { return (IEnumerable)GetValue(ItemsSourceVersaoProperty); }
            set { SetValue(ItemsSourceVersaoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemsSourceContatos.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsSourceVersaoProperty =
            DependencyProperty.Register("ItemsSourceVersao", typeof(IEnumerable), typeof(CustomHlpVersoes), new PropertyMetadata(
                defaultValue: null, propertyChangedCallback: new PropertyChangedCallback(lIdsVersaoChanged)));

        private static void lIdsVersaoChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != null)
            {
                ResourceDictionary resource = new ResourceDictionary
                {
                    Source = new Uri("/HLP.Resources.View.WPF;component/Styles/Components/UserControlStyles.xaml", UriKind.RelativeOrAbsolute)
                };
                (d as StackPanel).Children.Clear();
                Button btn;
                foreach (var id in e.NewValue as IEnumerable)
                {
                    btn = new Button();
                    btn.Content = id;
                    btn.Style = resource[key: "GlassButton"] as Style;
                    btn.Height = btn.Width = 50;
                    btn.Click += new RoutedEventHandler((d as CustomHlpVersoes).btnClick);
                    (d as StackPanel).Children.Add(element: btn);
                }
            }
        }

    }
}
