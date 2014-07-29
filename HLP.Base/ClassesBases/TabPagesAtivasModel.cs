using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using HLP.Base.Static;
using HLP.Base.EnumsBases;
using System.Threading;
using System.Windows.Documents;

namespace HLP.Base.ClassesBases
{
    public class TabPagesAtivasModel : modelBase
    {
        public TabPagesAtivasModel()
        {            
        }

        #region Properties
        private Window Windows;
        public Window _windows
        {
            get { return Windows; }
            set
            {
                Windows = value;
                try
                {
                    this.NameView = value.GetPropertyValue("NameView").ToString();
                    this.lComponents = new List<UIElement>();
                    IEnumerable<Expander> lExpanders = null;

                    //IEnumerable<TabControl> lTabControls = Util.FindVisualChildren<TabControl>(
                    //    depObj: value.Content as Panel);

                    //if (lTabControls.Count() > 0)
                    //{
                    //    this.GetListComponents(t: lTabControls.FirstOrDefault());
                    //}
                    //else
                    //{
                    //    lExpanders = Util.FindVisualChildren<Expander>
                    //        (depObj: value.Content as Panel);

                    //    foreach (Expander exp in lExpanders)
                    //    {
                    //        this.lComponents.AddRange(
                    //            collection: Util.FindVisualChildren<UIElement>(depObj: exp.Content as Panel));
                    //    }
                    //}

                    lExpanders = Util.FindVisualChildren<Expander>
                            (depObj: value.Content as Panel);

                    foreach (Expander exp in lExpanders)
                    {
                        this.lComponents.AddRange(
                            collection: Util.FindVisualChildren<UIElement>(depObj: exp.Content as Panel));
                    }

                    foreach (var item in lComponents.Where(i => i.GetType().BaseType != typeof(TextBlock)))
                    {
                        PropertyInfo pi = item.GetType().GetProperty(name: "stCompPosicao");
                        if (pi != null)
                        {
                            if (((statusComponentePosicao)pi.GetValue(obj: item)) == statusComponentePosicao.last)
                            {
                                if (item.GetType().Name == "CustomPesquisa" || 
                                    item.GetType().Name == "CustomTextBox")
                                {
                                    MethodInfo mi = item.GetType().GetMethod(name: "SetEventFocusToTxtId");

                                    object[] args = new object[] { (RoutedEventHandler)this.item_LostFocus };

                                    mi.Invoke(obj: item, parameters: args);
                                }
                                else if(item.GetType().Name != "CustomComboBox")
                                {
                                    item.LostFocus += item_LostFocus; break;
                                }
                            }
                        }
                    }

                }
                catch (Exception ex) { throw ex; }

                #region Controle de Navegação das TabItens
                lTabItemWindow = GetLogicalChildCollection<TabItem>(value.Content).ToList();
                foreach (var item in lTabItemWindow)
                {
                    try
                    {
                        List<Control> lcontrolWindow = GetLogicalChildCollection<Control>(item).Where(c => c.GetType().BaseType.Name == "BaseControl").ToList();
                        if (lcontrolWindow.Count > 0)
                        {
                            bool bValida = (bool)lcontrolWindow.LastOrDefault().GetPropertyValue("SetNext");
                            if (bValida)
                            {
                                //lcontrolWindow.LastOrDefault().LostFocus -= TabPagesAtivasModel_LostFocus;
                                //lcontrolWindow.LastOrDefault().LostFocus += TabPagesAtivasModel_LostFocus;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                #endregion
            }
        }

        void GetListComponents(TabControl t)
        {
            IEnumerable<Expander> lExpanders = null;
            foreach (TabItem ti in t.Items)
            {
                lExpanders = Util.FindVisualChildren<Expander>
                            (depObj: ti.Content as AdornerDecorator);

                foreach (Expander exp in lExpanders)
                {
                    this.lComponents.AddRange(
                        collection: Util.FindVisualChildren<UIElement>(depObj: exp.Content as Panel));
                }

                IEnumerable<TabControl> lTabControls = Util.FindVisualChildren<TabControl>(
                        depObj: ti.Content as AdornerDecorator);

                if (lTabControls.Count() > 0)
                {
                    this.GetListComponents(t: lTabControls.FirstOrDefault());
                }
            }
        }

        void item_LostFocus(object sender, RoutedEventArgs e)
        {
            foreach (var item in lComponents.Where(i => i.GetType().BaseType != typeof(TextBlock)))
            {
                PropertyInfo pi = item.GetType().GetProperty(name: "stCompPosicao");

                if (pi != null)
                {
                    if (((statusComponentePosicao)pi.GetValue(obj: item)) == statusComponentePosicao.first)
                    {
                        this.ComponentSetFocus(comp: item);
                        break;
                    }
                }
            }
        }

        void ComponentSetFocus(UIElement comp)
        {
            Application.Current.Dispatcher.BeginInvoke((Action)(() =>
                {
                    Thread.Sleep(millisecondsTimeout: 100);
                    comp.Focus();
                }));
        }

        private List<UIElement> _lComponents;

        public List<UIElement> lComponents
        {
            get { return _lComponents; }
            set
            {
                _lComponents = value;
                base.NotifyPropertyChanged(propertyName: "lComponents");
            }
        }

        public List<TabItem> lTabItemWindow { get; set; }
        private string _NameView = string.Empty;
        public string NameView
        {
            get { return _NameView; }
            set { _NameView = value; }
        }
        public string _header
        {
            get { return this.Windows.Title; }
        }

        private StackPanel _Botoes;

        public StackPanel Botoes
        {
            get { return _Botoes; }
            set
            {
                _Botoes = value;
                base.NotifyPropertyChanged(propertyName: "Botoes");
            }
        }

        public UIElement _content
        {
            get
            {
                UIElement e = _windows.Content as UIElement;
                (e as Panel).DataContext = this.Windows.DataContext;

                if (this.Windows.DataContext != null)
                    foreach (PropertyInfo item in this.Windows.DataContext.GetType().GetProperties())
                    {
                        if (item.PropertyType == typeof(StackPanel))
                        {
                            Type t = this.Windows.DataContext.GetType();
                            object parametro = Activator.CreateInstance(t);
                            parametro = this.Windows.DataContext;

                            this.Botoes = item.GetValue(obj: parametro) as StackPanel;
                        }
                    }

                return e;
            }
        }
        public object _currentDataContext
        {
            get
            {
                return this.Windows.DataContext;
            }
        }

        
        #endregion

        #region Events
        void TabPagesAtivasModel_LostFocus(object sender, RoutedEventArgs e)
        {
            SetNextTabItem(sender as FrameworkElement);
        }
        #endregion

        #region Methods
        public static List<T> GetLogicalChildCollection<T>(object parent) where T : DependencyObject
        {
            List<T> logicalCollection = new List<T>();
            GetLogicalChildCollection(parent as DependencyObject, logicalCollection);
            return logicalCollection;
        }
        private static void GetLogicalChildCollection<T>(DependencyObject parent, List<T> logicalCollection) where T : DependencyObject
        {
            IEnumerable children = LogicalTreeHelper.GetChildren(parent);
            foreach (object child in children)
            {
                if (child is DependencyObject)
                {
                    DependencyObject depChild = child as DependencyObject;
                    if (child is T)
                    {
                        logicalCollection.Add(child as T);
                    }
                    GetLogicalChildCollection(depChild, logicalCollection);
                }
            }
        }
        public void SetNextTabItem(FrameworkElement ctr)
        {
            TabItem tb;
            GetTabItemByControl(ctr, out tb);
            if (tb != null)
            {
                if ((tb.Parent as TabControl).SelectedIndex < ((tb.Parent as TabControl).Items.Count - 1))
                {

                    (tb.Parent as TabControl).SelectedIndex++;
                }
                else
                {
                    SetNextTabItem(tb.Parent as FrameworkElement);
                }
            }
            else
            {
                (lTabItemWindow.FirstOrDefault().Parent as TabControl).SelectedItem = lTabItemWindow.FirstOrDefault();
            }
        }
        public static void GetTabItemByControl(FrameworkElement ctr, out TabItem tab)
        {
            if (ctr != null)
            {
                if (ctr.Parent != null)
                {
                    if (ctr.Parent.GetType() == typeof(TabItem))
                    {
                        tab = ctr.Parent as TabItem;
                    }
                    else
                    {
                        GetTabItemByControl(ctr.Parent as FrameworkElement, out tab);
                    }
                }
                else
                    tab = null;
            }
            else
                tab = null;

        }
        #endregion

    }

}
