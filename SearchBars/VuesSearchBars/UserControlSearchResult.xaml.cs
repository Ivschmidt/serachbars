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
        public UserControlSearchResult()
        {
            InitializeComponent();
            
        }

        Manager manager = new Manager(new StubData());

        

        static UserControlSearchResult()
        {
            UserControlSearchResult.villeProperty = DependencyProperty.Register("NomVille",typeof(string), typeof(UserControlSearchResult),
                new PropertyMetadata("listeVille"));
        }

        public static readonly DependencyProperty villeProperty;

        public IVille ville
        {
            get
            {
                return GetValue(UserControlSearchResult.villeProperty) as IVille;
            }
            set
            {

            }
        }
    }
}
