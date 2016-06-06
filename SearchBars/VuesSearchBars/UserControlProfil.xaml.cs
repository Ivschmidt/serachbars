using MetierSearchBars;
using SearchBars;
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
    /// Logique d'interaction pour UserControlProfil.xaml
    /// </summary>
    public partial class UserControlProfil : UserControl
    {
        public UserControlProfil(IUser user)
        {
            InitializeComponent();
            CurrentUser = user;
            Age = Manager.CalculAge(user.DdN);

            if (string.IsNullOrEmpty(CurrentUser.Ville))
                Ville = "aucune ville";
            else
                Ville = CurrentUser.Ville;

            if (string.IsNullOrEmpty(CurrentUser.NumTel))
                Numero = "pas de numéro";
            else
                Numero = CurrentUser.NumTel;

            if (CurrentUser.BoissonPref == null)
                BoissonP = "pas de boisson";
            else
                BoissonP = CurrentUser.BoissonPref.ToString();
        }

        public Manager Manager
        {
            get
            {
                return (Application.Current as App).Manager;
            }
        }
        public IUser CurrentUser
        {
            get { return (IUser)GetValue(CurrentUserProperty); }
            set { SetValue(CurrentUserProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentUser.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentUserProperty =
            DependencyProperty.Register("CurrentUser", typeof(IUser), typeof(UserControlProfil), new PropertyMetadata(null));



        public int Age
        {
            get { return (int)GetValue(AgeProperty); }
            set { SetValue(AgeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Age.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AgeProperty =
            DependencyProperty.Register("Age", typeof(int), typeof(UserControlProfil), new PropertyMetadata(0));



        public string Ville
        {
            get { return (string)GetValue(VilleProperty); }
            set { SetValue(VilleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Ville.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty VilleProperty =
            DependencyProperty.Register("Ville", typeof(string), typeof(UserControlProfil), new PropertyMetadata("Aucune ville"));




        public string Numero
        {
            get { return (string)GetValue(NumeroProperty); }
            set { SetValue(NumeroProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Numero.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NumeroProperty =
            DependencyProperty.Register("Numero", typeof(string), typeof(UserControlProfil), new PropertyMetadata("Pas de numéro"));





        public string BoissonP
        {
            get { return (string)GetValue(BoissonPProperty); }
            set { SetValue(BoissonPProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BoissonP.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BoissonPProperty =
            DependencyProperty.Register("BoissonP", typeof(string), typeof(UserControlProfil), new PropertyMetadata(null));

        private void Button_Click_Modification(object sender, RoutedEventArgs e)
        {
            PasswordVerif passVerif = new PasswordVerif();
            passVerif.Show();
        }

    }
}
