using HLP.Base.ClassesBases;
using HLP.Base.EnumsBases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace HLP.Comum.View.WPF
{
    /// <summary>
    /// Interaction logic for HlpPesquisaInsert.xaml
    /// </summary>
    public partial class HlpPesquisaInsert : Window
    {
        BackgroundWorker bwFocus;
        List<UIElement> lControls = null;
        ICommand commDataContext = null;

        public HlpPesquisaInsert()
        {
            InitializeComponent();

            this.btnSave.Command = new RelayCommand(
                execute: exec => this.btnSaveExecute(),
                canExecute: canExec => this.btnCanExecute());
        }

        void bwFocus_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null && e.Error == null)
            {
                Application.Current.Dispatcher.BeginInvoke((Action)(() =>
                {
                    ((Stack<UIElement>)e.Result).Pop().Focus();
                }));
            }
        }

        void bwFocus_DoWork(object sender, DoWorkEventArgs e)
        {
            Stack<UIElement> lTabControlsTabItem = e.Argument as Stack<UIElement>;

            bool bFocado = false;


            Application.Current.Dispatcher.BeginInvoke((Action)(() =>
            {
                while (lTabControlsTabItem.Count > 1)
                {
                    UIElement comp = lTabControlsTabItem.Pop();

                    if (comp.GetType() == typeof(TabItem))
                    {
                        ((comp as TabItem).Parent as TabControl).SelectedItem = comp;
                    }
                }
                bFocado = true;
            }));

            while (!bFocado)
            {
                e.Result = lTabControlsTabItem;
                Thread.Sleep(millisecondsTimeout: 300);
            }
        }

        private void LoadComponentsWindow()
        {
            object contentUI = this.ctrContent.Content;

            List<Expander> lExpanders = HLP.Base.Static.Util.GetLogicalChildCollection<Expander>(parent: contentUI);
            lControls = new List<UIElement>();

            foreach (Expander exp in lExpanders)
            {
                lControls.AddRange(collection:
                    HLP.Base.Static.Util.GetLogicalChildCollection<UIElement>(parent: exp));
            }

            commDataContext = this.ctrContent.DataContext.GetType().GetProperty(
                name: "commandSalvar").GetValue(obj: this.ctrContent.DataContext) as ICommand;
        }

        private void SearchTabControlsTabItemToFocus(Stack<UIElement> lTabControlsTabItem, FrameworkElement ctrl)
        {
            if (ctrl.Parent == null)
            {
                return;
            }

            if (ctrl.Parent.GetType() == typeof(TabItem))
            {
                lTabControlsTabItem.Push(item: ctrl.Parent as UIElement);
            }

            SearchTabControlsTabItemToFocus(lTabControlsTabItem: lTabControlsTabItem, ctrl: ctrl.Parent as FrameworkElement);
        }

        private int _idSalvo;

        public int idSalvo
        {
            get { return _idSalvo; }
            set { _idSalvo = value; }
        }

        private void wd_Loaded(object sender, RoutedEventArgs e)
        {
            bwFocus = new BackgroundWorker();
            bwFocus.DoWork += bwFocus_DoWork;
            bwFocus.RunWorkerCompleted += bwFocus_RunWorkerCompleted;

            if (lControls == null)
            {
                this.LoadComponentsWindow();
            }

            foreach (UIElement c in lControls)
            {
                PropertyInfo pi = c.GetType().GetProperty("stCompPosicao");

                if (pi != null)
                {

                    if ((HLP.Base.EnumsBases.statusComponentePosicao)pi.GetValue(obj: c) == statusComponentePosicao.first)
                    {
                        Stack<UIElement> lTabControlsTabItem = new Stack<UIElement>();

                        lTabControlsTabItem.Push(item: c);

                        this.SearchTabControlsTabItemToFocus(lTabControlsTabItem: lTabControlsTabItem,
                            ctrl: c as FrameworkElement);

                        bwFocus.RunWorkerAsync(argument: lTabControlsTabItem);
                    }
                }
            }
        }

        private void btnSaveExecute()
        {
            this.commDataContext.Execute(parameter: null);

            this.idSalvo = (int)this.ctrContent.DataContext.GetType()
                .GetProperty(name: "currentID").GetValue(obj: this.ctrContent.DataContext);

            this.DialogResult = true;

            this.Close();
        }

        private bool btnCanExecute()
        {
            if (this.commDataContext != null)
                return this.commDataContext.CanExecute(parameter: this.ctrContent.Content);

            return false;
        }
    }
}
