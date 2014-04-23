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

namespace HLP.Components.View.WPF
{
    public class WindowsBase : System.Windows.Window
    {
        public WindowsBase()
        {
            IEnumerable<TabControl> lTab = Util.FindVisualChildren<TabControl>(depObj: this);
        }

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

                        //listControls.AddRange(collection: FindVisualChildren<TextBox>(depObj: a));
                        //listControls.AddRange(collection: FindVisualChildren<HlpPesquisa>(depObj: a));
                        //listControls.AddRange(collection: FindVisualChildren<CheckBox>(depObj: a));
                        //listControls.AddRange(collection: FindVisualChildren<ComboBox>(depObj: a));
                        //listControls.AddRange(collection: FindVisualChildren<DataGrid>(depObj: a));

                        //foreach (UIElement uiCtrl in listControls)
                        //{
                        //    object tg = uiCtrl.GetType().GetProperty(name: "Tag").GetValue(obj: uiCtrl);

                        //    if (tg != null)
                        //    {
                        //        if (Convert.ToInt32(value: tg) == (int)1001)
                        //        {
                        //            ctrl = uiCtrl;
                        //        }
                        //    }
                        //}
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
