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
using DataSearchBars;
using MetierSearchBars;
using System.Collections.ObjectModel;

namespace VuesSearchBars
{
    /// <summary>
    /// Logique d'interaction pour UserControlResultBar.xaml
    /// </summary>
    public partial class UserControlResultBar : UserControl
    {
        public UserControlResultBar()
        {
           InitializeComponent();
        }

        public string Nom
        {
            get { return (string)GetValue(NomProperty); }
            set { SetValue(NomProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Nom.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NomProperty =
            DependencyProperty.Register("Nom", typeof(string), typeof(UserControlResultBar), new PropertyMetadata("aucun nom", (sender, e) =>
            {
            }));

        public string Numero
        {
            get { return (string)GetValue(NumeroProperty); }
            set { SetValue(NumeroProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Numero.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NumeroProperty =
            DependencyProperty.Register("Numero", typeof(string), typeof(UserControlResultBar), new PropertyMetadata("aucun numéro"));

        public string Adresse
        {
            get { return (string)GetValue(AdresseProperty); }
            set { SetValue(AdresseProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Adresse.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AdresseProperty =
            DependencyProperty.Register("Adresse", typeof(string), typeof(UserControlResultBar), new PropertyMetadata("aucune ville"));

        public string NoteMoyenne
        {
            get { return (string)GetValue(NoteMoyenneProperty); }
            set { SetValue(NoteMoyenneProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NoteMoyenne.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NoteMoyenneProperty =
            DependencyProperty.Register("NoteMoyenne", typeof(string), typeof(UserControlResultBar), new PropertyMetadata("n.c"));

        public IEnumerable<IBoisson> ListBoissons
        {
            get { return (IEnumerable<IBoisson>)GetValue(ListBoissonsProperty); }
            set { SetValue(ListBoissonsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ListBoissons.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ListBoissonsProperty =
            DependencyProperty.Register("ListBoissons", typeof(IEnumerable<IBoisson>), typeof(UserControlResultBar), new PropertyMetadata(null));

        public ReadOnlyDictionary<IUser, Avis> Commentaires
        {
            get { return (ReadOnlyDictionary<IUser, Avis>)GetValue(CommentairesProperty); }
            set { SetValue(CommentairesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Commentaires.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommentairesProperty =
            DependencyProperty.Register("Commentaires", typeof(ReadOnlyDictionary<IUser, Avis>), typeof(UserControlResultBar), new PropertyMetadata(null, (sender, e) => 
            {
            }));


        private void Button_Click_PosteAvis(object sender, RoutedEventArgs e)
        {
            RateWindow rateWindow = new RateWindow();
            rateWindow.Show();
        }


        public CoordonneesGPS CoordGPS
        {
            get { return (CoordonneesGPS)GetValue(CoordGPSProperty); }
            set { SetValue(CoordGPSProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CoordGPS.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CoordGPSProperty =
            DependencyProperty.Register("CoordGPS", typeof(CoordonneesGPS), typeof(UserControlResultBar), new PropertyMetadata(null));




    }
}
