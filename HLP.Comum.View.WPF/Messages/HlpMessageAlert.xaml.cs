using HLP.ComumView.ViewModel.Messages.ViewModels;
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
using System.Windows.Shapes;

namespace HLP.Comum.View.WPF.Messages
{
    /// <summary>
    /// Interaction logic for HlpMessageAlert.xaml
    /// </summary>
    public partial class HlpMessageAlert : Window
    {
        public HlpMessageAlert()
        {
            InitializeComponent();
        }

        public static void ShowMessage(string xAlertMessageToUser)
        {
            HlpMessageAlert _message = new HlpMessageAlert();
            _message.DataContext = new HlpMessageAlertViewModel(xAlertMessageToUser: xAlertMessageToUser);

            _message.ShowDialog();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
