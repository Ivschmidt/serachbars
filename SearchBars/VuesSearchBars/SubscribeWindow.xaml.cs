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
using System.Windows.Shapes;

namespace SearchBars
{
    /// <summary>
    /// Logique d'interaction pour SubscribeWindow.xaml
    /// </summary>
    public partial class SubscribeWindow : Window
    {
        private Manager manager;
        private Sexe sexe;

        public SubscribeWindow(Manager manager)
        {
            InitializeComponent();
            this.manager = manager;
        }

        private void Button_Click_Subscribe(object sender, RoutedEventArgs e)
        {
            string message = "";

            if (!mdp1.Password.Equals(mdp2.Password))
            {
                message = "Le mot de passe n'est pas identique dans les deux emplacements";
            }

            if (string.IsNullOrEmpty(message))
            {
                try
                { 
                    TypeBoisson boisson = TypeBoisson.Vin;
                    DateTime ddd = new DateTime(2016, 01, 01);
                    manager.sInscrire(pseudo.Text, mdp1.Password, nom.Text, prenom.Text, sexe, ddd, numTel.Text, ville.Text, boisson);
                }
                catch (Exception i)
                {
                    message += i.Message;
                }
            }
            if (string.IsNullOrEmpty(message))
            {
                MessageBox.Show(message, "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void msexe_checked(object sender, RoutedEventArgs e)
        {
            var radio = sender as RadioButton;
            if (radio.Tag.ToString().Equals("F"))
            {
                sexe = Sexe.Femme;
            }else
            {
                sexe = Sexe.Homme;
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
