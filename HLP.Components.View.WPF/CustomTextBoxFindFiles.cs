using HLP.Base.EnumsBases;
using HLP.Base.Static;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    ///     <MyNamespace:CustomTextBoxFindFiles/>
    ///
    /// </summary>
    public class CustomTextBoxFindFiles : TextBox
    {
        static CustomTextBoxFindFiles()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomTextBoxFindFiles), new FrameworkPropertyMetadata(typeof(CustomTextBoxFindFiles)));
        }


        public CustomTextBoxFindFiles()
        {
            ResourceDictionary resource = new ResourceDictionary
            {
                Source = new Uri("/HLP.Resources.View.WPF;component/Styles/Components/UserControlStyles.xaml", UriKind.RelativeOrAbsolute)
            };

            this.Template = resource["txtFindFiles"] as ControlTemplate;
            this.ApplyTemplate();

            Button btn = this.Template.FindName(name: "btnCC", templatedParent: this) as Button;
            btn.Click += btn_Click;

            this.MouseDoubleClick += CustomTextBoxFindFiles_MouseDoubleClick;
        }

        void CustomTextBoxFindFiles_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            FileStatic.ExecuteFile(xPath: this.Text);
        }

        void btn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();

            if (fd.ShowDialog() == true)
            {
                if (File.Exists(path: fd.FileName))
                {
                    this.Text = fd.FileName;
                }
            }
        }

        private StVisibilityButtonQuickSearch _stVisibilityBtnQuickSearch;

        public StVisibilityButtonQuickSearch stVisibilityBtnQuickSearch
        {
            get { return _stVisibilityBtnQuickSearch; }
            set { _stVisibilityBtnQuickSearch = value; }
        }
    }
}
