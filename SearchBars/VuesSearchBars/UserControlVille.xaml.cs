using MetierSearchBars;
using Microsoft.Maps.MapControl.WPF;
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

        public string NomVille
        {
            get { return (string)GetValue(NomVilleProperty); }
            set { SetValue(NomVilleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NomVille.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NomVilleProperty =
            DependencyProperty.Register("NomVille", typeof(string), typeof(UserControlVille), new PropertyMetadata("Aucune ville à afficher"));



        public CoordonneesGPS GPSVille
        {
            get { return (CoordonneesGPS)GetValue(GPSVilleProperty); }
            set { SetValue(GPSVilleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for GPSBar.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GPSVilleProperty =
            DependencyProperty.Register("GPSVille", typeof(CoordonneesGPS), typeof(UserControlVille), new PropertyMetadata(new CoordonneesGPS(), (sender, e) =>
            {
                CoordonneesGPS gpsCoord = (CoordonneesGPS)e.NewValue;
                (sender as UserControlVille).map1.Center = new Location(gpsCoord.Latitude, gpsCoord.Longitude);
            }));


        public IEnumerable<IBar> LBars
        {
            get { return (IEnumerable<IBar>)GetValue(LBarsProperty); }
            set { SetValue(LBarsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LBars.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LBarsProperty =
            DependencyProperty.Register("LBars", typeof(IEnumerable<IBar>), typeof(UserControlVille), new PropertyMetadata(null, (sender, e) => { }));
    }
}
