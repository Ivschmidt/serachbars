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
    /// Logique d'interaction pour UserControlVille.xaml
    /// </summary>
    public partial class UserControlVille : UserControl
    {
        public UserControlVille()
        {
            InitializeComponent();

            //if (pushPin.Location == null)
            //{
            //    pushPin.Location = new Microsoft.Maps.MapControl.WPF.Location();
            //}
            //if (Ville != null)
            //{
            //    pushPin.Location.Latitude = Ville.GPSVille.Latitude;

            //    pushPin.Location.Longitude = Ville.GPSVille.Longitude;
            //}
        }

        public IVille Ville
        {
            get { return (IVille)GetValue(VilleProperty); }
            set { SetValue(VilleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Ville.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty VilleProperty =
            DependencyProperty.Register("Ville", typeof(IVille), typeof(UserControlVille), new PropertyMetadata(null, (sender, e) =>
            {
            }));




        public IEnumerable<IBar> LBars
        {
            get { return (IEnumerable<IBar>)GetValue(LBarsProperty); }
            set { SetValue(LBarsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LBars.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LBarsProperty =
            DependencyProperty.Register("LBars", typeof(IEnumerable<IBar>), typeof(UserControlVille), new PropertyMetadata(null, (sender, e) => { }));




        //public double GPS
        //{
        //    get { return (double)GetValue(GPSProperty); }
        //    set { SetValue(GPSProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for GPS.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty GPSProperty =
        //    DependencyProperty.Register("GPS", typeof(double), typeof(UserControlVille), new PropertyMetadata(0));

        

    }
}
