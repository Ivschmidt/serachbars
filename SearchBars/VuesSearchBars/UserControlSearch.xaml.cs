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
using MetierSearchBars;
using DataSearchBars;

namespace VuesSearchBars
{
    /// <summary>
    /// Logique d'interaction pour UserControlSearch.xaml
    /// </summary>
    public partial class UserControlSearch : UserControl
    {
        private Manager manager;

        public UserControlSearch(Manager manager)
        {
            InitializeComponent();

            this.manager = manager;
        }



        public String ListVille
        {
            get { return (String)GetValue(ListVilleProperty); }
            set { SetValue(ListVilleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ListVille.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ListVilleProperty =
            DependencyProperty.Register("ListVille", typeof(String), typeof(IVille), new PropertyMetadata(0));

        

    }
}
