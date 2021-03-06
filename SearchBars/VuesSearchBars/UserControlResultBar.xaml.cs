﻿using System;
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
using System.IO;
using Microsoft.Maps.MapControl.WPF;

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

        public IBar CurrentBar
        {
            get { return (IBar)GetValue(CurrentBarProperty); }
            set { SetValue(CurrentBarProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentBar.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentBarProperty =
            DependencyProperty.Register("CurrentBar", typeof(IBar), typeof(UserControlResultBar), new PropertyMetadata(null));
        
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

        public double NoteMoyenne
        {
            get { return (double)GetValue(NoteMoyenneProperty); }
            set { SetValue(NoteMoyenneProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NoteMoyenne.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NoteMoyenneProperty =
            DependencyProperty.Register("NoteMoyenne", typeof(double), typeof(UserControlResultBar), new PropertyMetadata(0.0));



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

        public CoordonneesGPS GPSBar
        {
            get { return (CoordonneesGPS)GetValue(GPSBarProperty); }
            set { SetValue(GPSBarProperty, value); }
        }

        // Using a DependencyProperty as the backing store for GPSBar.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GPSBarProperty =
            DependencyProperty.Register("GPSBar", typeof(CoordonneesGPS), typeof(UserControlResultBar), new PropertyMetadata(new CoordonneesGPS(), (sender, e) => 
            {
                CoordonneesGPS gpsCoord = (CoordonneesGPS)e.NewValue;
                (sender as UserControlResultBar).mapVille.Center = new Location(gpsCoord.Latitude, gpsCoord.Longitude);
            }));


        private void Button_Click_PosteAvis(object sender, RoutedEventArgs e)
        {
            RateWindow rateWindow = new RateWindow(CurrentBar);
            rateWindow.Show();
        }

        public string Photo
        {
            get { return (string)GetValue(PhotoProperty); }
            set { SetValue(PhotoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Photo.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PhotoProperty =
            DependencyProperty.Register("Photo", typeof(string), typeof(UserControlResultBar), new PropertyMetadata(""));

        

        //public ReadOnlyCollection<string> LPhoto
        //{
        //    get { return (ReadOnlyCollection<string>)GetValue(LPhotoProperty); }
        //    set { SetValue(LPhotoProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for LPhoto.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty LPhotoProperty =
        //    DependencyProperty.Register("LPhoto", typeof(ReadOnlyCollection<string>), typeof(UserControlResultBar), new PropertyMetadata(null,(sender, e)=>{}));

        

        //private void Button_Click_Precedent(object sender, RoutedEventArgs e)
        //{

        //}

        //private void Button_Click_Suivant(object sender, RoutedEventArgs e)
        //{

        //}

    }
}
