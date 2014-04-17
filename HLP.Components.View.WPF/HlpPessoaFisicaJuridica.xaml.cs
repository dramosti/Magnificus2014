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
    /// Interaction logic for HlpPessoaFisicaJuridica.xaml
    /// </summary>
    public partial class HlpPessoaFisicaJuridica : UserControl
    {
        public HlpPessoaFisicaJuridica()
        {
            InitializeComponent();
            this.cbPessoa.IsChecked = true;
        }
        private void CustomCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            this.lblRgIe.Text = "Rg";
            this.lblCpfCnpj.Text = "Cpf";
            HLP.Components.View.WPF.Converter.MaskConverter converter = new Converter.MaskConverter();
            this.lblIm.Visibility = System.Windows.Visibility.Hidden;
            this.txtIm.Visibility = System.Windows.Visibility.Hidden;

            Binding bRgIe = new Binding();
            bRgIe.ElementName = this.Name;
            bRgIe.Path = new PropertyPath(path: "DataContext.currentModel.xRgIe");
            bRgIe.Converter = converter;
            bRgIe.ConverterParameter = "rg";

            this.txtRgIe.SetBinding(dp: TextBox.TextProperty, binding: bRgIe);

            Binding bCpfCnpj = new Binding();
            bCpfCnpj.ElementName = this.Name;
            bCpfCnpj.Path = new PropertyPath(path: "DataContext.currentModel.xCpfCnpj");
            bCpfCnpj.Converter = converter;
            bCpfCnpj.ConverterParameter = "cpf";

            this.txtCpfCnpj.SetBinding(dp: TextBox.TextProperty, binding: bCpfCnpj);
        }

        private void CustomCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            this.lblRgIe.Text = "Ie";
            this.lblCpfCnpj.Text = "Cnpj";
            HLP.Components.View.WPF.Converter.MaskConverter converter = new Converter.MaskConverter();
            this.lblIm.Visibility = System.Windows.Visibility.Visible;
            this.txtIm.Visibility = System.Windows.Visibility.Visible;

            Binding bRgIe = new Binding();
            bRgIe.ElementName = this.Name;
            bRgIe.Path = new PropertyPath(path: "DataContext.currentModel.xRgIe");

            this.txtRgIe.SetBinding(dp: TextBox.TextProperty, binding: bRgIe);

            Binding bCpfCnpj = new Binding();
            bCpfCnpj.ElementName = this.Name;
            bCpfCnpj.Path = new PropertyPath(path: "DataContext.currentModel.xCpfCnpj");
            bCpfCnpj.Converter = converter;
            bCpfCnpj.ConverterParameter = "cnpj";

            this.txtCpfCnpj.SetBinding(dp: TextBox.TextProperty, binding: bCpfCnpj);
        }
    }
}
