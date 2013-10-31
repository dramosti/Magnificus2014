using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace HLP.Comum.View.Components
{
    public class BaseControl : System.Windows.Controls.UserControl, INotifyPropertyChanged
    {
        public BaseControl()
        {


        }

        #region Base de Dados
        [Category("HLP.Base")]
        public string Table
        {
            get { return (string)GetValue(TableProperty); }
            set { SetValue(TableProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Table.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TableProperty =
            DependencyProperty.Register("Table", typeof(string), typeof(BaseControl), new PropertyMetadata(string.Empty));


        [Category("HLP.Base")]
        public string Field
        {
            get { return (string)GetValue(FieldProperty); }
            set { SetValue(FieldProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Field.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FieldProperty =
            DependencyProperty.Register("Field", typeof(string), typeof(BaseControl), new PropertyMetadata(string.Empty));
        #endregion
        [Category("HLP.Base")]
        public string Help
        {
            get { return (string)GetValue(HelpProperty); }
            set { SetValue(HelpProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Help.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HelpProperty =
            DependencyProperty.Register("Help", typeof(string), typeof(BaseControl), new PropertyMetadata(string.Empty));
        [Category("HLP.Base")]
        public string Caption
        {
            get { return (string)GetValue(CaptionProperty); }
            set { SetValue(CaptionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Caption.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CaptionProperty =
            DependencyProperty.Register("Caption", typeof(string), typeof(BaseControl), new PropertyMetadata("Label"));
        [Category("HLP.Base")]
        public double WidthLabel
        {
            get { return (double)GetValue(WidthLabelProperty); }
            set { SetValue(WidthLabelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for WidthLabel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WidthLabelProperty =
            DependencyProperty.Register("WidthLabel", typeof(double), typeof(BaseControl), new PropertyMetadata(Convert.ToDouble(50)));



        #region NotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}