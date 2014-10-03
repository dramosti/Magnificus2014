using HLP.Base.ClassesBases;
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

namespace HLP.Comum.View.Components
{
    /// <summary>
    /// Interaction logic for HlpButtonHierarquia.xaml
    /// </summary>
    public partial class HlpButtonHierarquia : UserControl
    {
        public ICommand btnPesquisaComm { get; set; }

        public HlpButtonHierarquia()
        {
            InitializeComponent();
            this.btnPesquisaComm = new RelayCommand(execute: execut => this.ExecPesquisa());
        }

        private void ExecPesquisa()
        {
            ICommand comm = this.DataContext.GetType().GetProperty(name: "commandPesquisar").GetValue(obj: this.DataContext) as ICommand;

            comm.Execute(parameter: Convert.ToInt32(value: this.xTextId));
        }

        public string xTextId
        {
            get { return (string)GetValue(xTextIdProperty); }
            set
            {
                this.txtId.Text = value;
                SetValue(xTextIdProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for xTextId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty xTextIdProperty =
            DependencyProperty.Register("xTextId", typeof(string), typeof(HlpButtonNavigation), new PropertyMetadata(String.Empty));

        public string xTextOpcional
        {
            get { return (string)GetValue(xTextOpcionalProperty); }
            set
            {
                this.txtOpcional.Text = value;
                SetValue(xTextOpcionalProperty, value);
            }
        }

        public bool ExibeTextOpcional
        {
            set
            {
                this.txtOpcional.Visibility = value ? Visibility.Visible : System.Windows.Visibility.Collapsed;
            }
        }

        // Using a DependencyProperty as the backing store for xTextOpcional.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty xTextOpcionalProperty =
            DependencyProperty.Register("xTextOpcional", typeof(string), typeof(HlpButtonNavigation), new PropertyMetadata(String.Empty));
    }
}
