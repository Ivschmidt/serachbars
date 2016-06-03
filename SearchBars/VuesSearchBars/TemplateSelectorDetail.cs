using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace VuesSearchBars
{
    public class TemplateSelectorDetail : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if(item == null)
            {
                return DTVille;
            }
            return DTDetail;
        }

        public DataTemplate DTVille { get; set; }

        public DataTemplate DTDetail { get; set; }
    }
}
