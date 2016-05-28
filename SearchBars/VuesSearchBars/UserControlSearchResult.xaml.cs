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
    /// Logique d'interaction pour UserControlSearchResult.xaml
    /// </summary>
    public partial class UserControlSearchResult : UserControl
    {
        public UserControlSearchResult(IEnumerable<IBar> barRecherches, IVille ville)
        {
            InitializeComponent();
            ListBarRecherches = barRecherches;
            Ville= ville;
        }

        public IEnumerable<IBar> ListBarRecherches
        {
            get { return (IEnumerable<IBar>)GetValue(ListBarRecherchesProperty); }
            set { SetValue(ListBarRecherchesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ListBarRecherches.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ListBarRecherchesProperty =
            DependencyProperty.Register("ListBarRecherches", typeof(IEnumerable<IBar>), typeof(UserControlSearchResult), new PropertyMetadata(null));

        public IVille Ville
        {
            get { return (IVille)GetValue(VilleProperty); }
            set { SetValue(VilleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Ville.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty VilleProperty =
            DependencyProperty.Register("Ville", typeof(IVille), typeof(UserControlSearchResult), new PropertyMetadata(null));






    }
}
