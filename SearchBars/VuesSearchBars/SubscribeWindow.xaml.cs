using MetierSearchBars;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public SubscribeWindow(Manager manager, int mode)
        {

            InitializeComponent();

            DataContext = manager.CurrentUser;
            this.manager = manager;
            if (mode == 1)
            {
                NomPage.Text = "Inscription :";
                ButtonPage.Content = "s'incrire";
            }
            else
            {
                NomPage.Text = "Modification :";
                ButtonPage.Content = "modifier";
                
            }
            
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
                    Sexe sexe;
                    TypeBoisson boisson = (TypeBoisson)bpref.SelectedItem;
                    
                    DateTime ddd = new DateTime(int.Parse(DdNY.Text), int.Parse(DdNM.Text), int.Parse(DdND.Text));
                    if ((bool)SexeF.IsChecked)
                        sexe = Sexe.Femme;
                    else
                        sexe = Sexe.Homme;

                    manager.sInscrire(pseudo.Text, mdp1.Password, nom.Text, prenom.Text, sexe, ddd, numTel.Text, ville.Text, boisson,PhotoDeProfil.Source.ToString());
                }
                catch (Exception i)
                {
                    message += i.Message;
                }
            }
            if (!string.IsNullOrEmpty(message))
            {
                MessageBox.Show(message, "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                MessageBox.Show("Bienvenue parmis nous :)", "Welcome", MessageBoxButton.OK);
                this.Close();
            }
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }


        private void Button_Click_Parcourir(object sender, RoutedEventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.ShowDialog();


            var chemin = file.FileName;

            PhotoDeProfil.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(chemin);
        }

       
    }
}
