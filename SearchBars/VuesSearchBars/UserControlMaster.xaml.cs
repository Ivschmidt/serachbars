using MetierSearchBars;
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

namespace VuesSearchBars
{
    /// <summary>
    /// Logique d'interaction pour UserControlMaster.xaml
    /// </summary>
    public partial class UserControlMaster : UserControl
    {
        public UserControlMaster(IEnumerable<IBar> listBarsRecherches, IVille ville)
        {
            ListBarsRecherches = listBarsRecherches;
            InitializeComponent();

            //load le UCVille
            GridMainDetail.Children.Clear();
            GridMainDetail.Children.Add(new UserControlVille(ville));
        }

        public IEnumerable<IBar> ListBarsRecherches
        {
            get { return (IEnumerable<IBar>)GetValue(ListBarsRecherchesProperty); }
            set { SetValue(ListBarsRecherchesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ListBarsRecherches.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ListBarsRecherchesProperty =
            DependencyProperty.Register("ListBarsRecherches", typeof(IEnumerable<IBar>), typeof(UserControlMaster), new PropertyMetadata(null));

        public UserControlResultBar UCResultBar
        {
            get { return (UserControlResultBar)GetValue(UCResultBarProperty); }
            set { SetValue(UCResultBarProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UCResultBar.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UCResultBarProperty =
            DependencyProperty.Register("UCResultBar", typeof(UserControlResultBar), typeof(UserControlMaster), new PropertyMetadata(null));


        //private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (UCResultBar == null)
        //    {
        //        UCResultBar = new UserControlResultBar(ListBarsRecherches);
        //        GridMainDetail.Children.Clear(); //leve une exception et je sais pas pk 
        //        GridMainDetail.Children.Add(UCResultBar);
        //    }
                
        //}
    }
}
