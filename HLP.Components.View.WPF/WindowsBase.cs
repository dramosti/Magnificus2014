using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using HLP.Base.Static;
using System.Reflection;
using HLP.Base.EnumsBases;
using System.Threading;

namespace HLP.Components.View.WPF
{
    public class WindowsBase : System.Windows.Window
    {
        BackgroundWorker bwSetFocusFirstCtrl;
        public WindowsBase()
        {
            IEnumerable<TabControl> lTab = Util.FindVisualChildren<TabControl>(depObj: this);
            bwSetFocusFirstCtrl = new BackgroundWorker();
            bwSetFocusFirstCtrl.DoWork += bwSetFocusFirstCtrl_DoWork;
            bwSetFocusFirstCtrl.RunWorkerCompleted += bwSetFocusFirstCtrl_RunWorkerCompleted;
        }

        #region Focus

        void bwSetFocusFirstCtrl_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null && e.Error == null)
            {
                Application.Current.Dispatcher.BeginInvoke((Action)(() =>
                {
                    if (e.Result.GetType().Name == "CustomPesquisa")
                    {
                    }
                    else
                    {
                        ((FrameworkElement)e.Result).Focus();
                    }
                }));
            }            
        }

        void bwSetFocusFirstCtrl_DoWork(object sender, DoWorkEventArgs e)
        {
            FrameworkElement currentControl = null;
            TabControl currentTabControl = null;
            bool bFocado = false;

            currentControl = (FrameworkElement)e.Argument;
            Application.Current.Dispatcher.BeginInvoke((Action)(() =>
            {
                while (true)
                {
                    currentControl = (FrameworkElement)currentControl.Parent;

                    if (currentControl.GetType() == typeof(TabControl))
                    {
                        currentTabControl = (TabControl)currentControl;

                        ((TabControl)currentControl).SelectedItem =
                            ((TabControl)currentControl).Items[index: 0];
                        ((TabItem)((TabControl)currentControl).SelectedItem).Focus();
                    }

                    if (currentControl.Parent == null)
                    {
                        break;
                    }
                    else if (currentControl.Parent.GetType().BaseType.GetType() == typeof(Window))
                    {
                        break;
                    }
                }

                IEnumerable<Expander> lExpanders = null;
                List<UIElement> lComponents = new List<UIElement>();
                lExpanders = Util.FindVisualChildren<Expander>
                (depObj: ((currentTabControl).SelectedItem as TabItem).Content as AdornerDecorator);

                foreach (Expander exp in lExpanders)
                {
                    lComponents.AddRange(
                        collection: Util.FindVisualChildren<UIElement>(depObj: exp.Content as Panel));
                }

                foreach (var item in lComponents.Where(i => i.GetType().BaseType != typeof(TextBlock)))
                {
                    PropertyInfo pi = item.GetType().GetProperty(name: "stCompPosicao");
                    if (pi != null)
                    {
                        if (((statusComponentePosicao)pi.GetValue(obj: item)) == statusComponentePosicao.first)
                        {
                            e.Result = item;
                        }
                    }
                }
                bFocado = true;
            }));

            while (!bFocado)
            {
                Thread.Sleep(millisecondsTimeout: 300);
            }            
        }

        #endregion

        public void SetEventsTabControl(TabControl tabControl)
        {
            tabControl.KeyDown += TabControl_KeyDownGeneric;
            foreach (TabItem item in tabControl.Items)
            {
                object o = item.Content;
                if (o != null)
                {
                    AdornerDecorator a = o as AdornerDecorator;
                    foreach (TabControl t in Util.FindVisualChildren<TabControl>(depObj: a, type: typeof(HlpEndereco)))
                    {
                        SetEventsTabControl(tabControl: t);
                    }
                }
            }
        }

        public void TabControl_KeyDownGeneric(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Tab)
            {
                UIElement ctrl = null;
                TabControl t = sender as TabControl;
                TabItem selectedTabItem = t.SelectedItem as TabItem;
                object o = selectedTabItem.Content;

                if (o != null)
                {
                    if (o.GetType() == typeof(AdornerDecorator))
                    {
                        AdornerDecorator a = o as AdornerDecorator;

                        List<FrameworkElement> listControls = new List<FrameworkElement>();

                        listControls.AddRange(collection: Util.FindVisualChildren<FrameworkElement>(depObj:
                            a, type: typeof(HlpEndereco)).Where
                            (i => i.GetType() == typeof(CustomTextBox)
                            || i.GetType() == typeof(CustomCheckBox)
                            || i.GetType() == typeof(CustomComboBox)
                            || i.GetType() == typeof(HlpPesquisa)));

                        ctrl = listControls.LastOrDefault();
                    }
                }

                if (ctrl != null)
                {
                    bool focused = false;

                    if (ctrl.GetType() == typeof(HlpPesquisa))
                    {
                        if (((ctrl as HlpPesquisa).FindName(name: "txtID") as TextBox).IsFocused)
                            focused = true;
                    }
                    else if (ctrl.GetType() == typeof(DataGrid))
                    {
                        focused = true;
                    }
                    else
                    {
                        focused = ctrl.IsFocused;
                    }

                    if (focused)
                    {
                        if (t.SelectedIndex < (t.Items.Count - 1))
                        {
                            TabItem tabItemTemp = t.Items[t.SelectedIndex + 1] as TabItem;

                            tabItemTemp.Focus();

                            AdornerDecorator a = o as AdornerDecorator;

                            List<UIElement> listControls = new List<UIElement>();

                            listControls.AddRange(collection: Util.FindVisualChildren<TextBox>(depObj: a, type: typeof(HlpEndereco)));
                            listControls.AddRange(collection: Util.FindVisualChildren<HlpPesquisa>(depObj: a, type: typeof(HlpEndereco)));
                            listControls.AddRange(collection: Util.FindVisualChildren<CheckBox>(depObj: a, type: typeof(HlpEndereco)));
                            listControls.AddRange(collection: Util.FindVisualChildren<ComboBox>(depObj: a, type: typeof(HlpEndereco)));

                            foreach (UIElement item in listControls.OrderBy(i => i.GetType().GetProperty(name: "TabIndex").GetValue(obj: i)))
                            {
                                if (item.IsEnabled)
                                {
                                    if (item.GetType() == typeof(HlpPesquisa))
                                    {
                                        ((item as HlpPesquisa).FindName("txtID") as TextBox).Focus();
                                    }
                                    else
                                        item.Focus();
                                    break;
                                }
                            }
                        }
                        else
                        {
                            this.bwSetFocusFirstCtrl.RunWorkerAsync(
                                argument: ctrl);
                        }
                    }
                }
            }
        }

        public string NameView
        {
            get { return (string)GetValue(NameViewProperty); }
            set { SetValue(NameViewProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NameView.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NameViewProperty =
            DependencyProperty.Register("NameView", typeof(string), typeof(WindowsBase), new PropertyMetadata(string.Empty));

    }
}
