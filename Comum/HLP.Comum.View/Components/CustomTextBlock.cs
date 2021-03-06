﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HLP.Comum.View.Components
{
    public class CustomTextBlock : TextBlock
    {
        public CustomTextBlock()
        {
            ResourceDictionary resource = new ResourceDictionary
            {
                Source = new Uri("/HLP.Comum.Resources;component/Styles/Components/ComponentsStyles.xaml", UriKind.RelativeOrAbsolute)
            };

            this.Style = resource["TextBlocktyleComponents"] as Style;
        }
    }
}
