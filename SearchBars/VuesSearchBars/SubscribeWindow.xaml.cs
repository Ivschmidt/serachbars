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
using VuesSearchBars;

namespace SearchBars
{
    /// <summary>
    /// Logique d'interaction pour SubscribeWindow.xaml
    /// </summary>
    public partial class SubscribeWindow : Window
    {
        public SubscribeWindow(int mode)
        {

            InitializeComponent();
            Mode = mode;
            DataContext = Manager.CurrentUser;
            if (Mode == 1)
            {
                NomPage.Text = "Inscription :";
                ButtonPage.Content = "S'inscrire";
            }
            else
            {
                NomPage.Text = "Modification :";
                ButtonPage.Content = "Modifier";
                sexeText.Visibility = Visibility.Hidden;
                sexeButtons.Visibility = Visibility.Hidden;
                bordure.Visibility = Visibility.Hidden;
            }
        }

        public Manager Manager
        {
            get
            {
                return (Application.Current as App).Manager;
            }
        }

        public int Mode { get; set; }

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
                    TypeBoisson? boisson = (TypeBoisson?)bpref.SelectedItem;

                    DateTime ddd;
                    try
                    {
                        ddd = new DateTime(int.Parse(DdNY.Text), int.Parse(DdNM.Text), int.Parse(DdND.Text));
                    } catch 
                    {
                        throw new Exception("La date de naissance n'est pas correcte");
                    }
                    if ((bool)SexeF.IsChecked)
                        sexe = Sexe.Femme;
                    else
                        sexe = Sexe.Homme;

                    if(Mode == 1)
                    {
                        Manager.sInscrire(pseudo.Text, mdp1.Password, nom.Text, prenom.Text, sexe, ddd, numTel.Text, ville.Text, boisson, PhotoDeProfil.Source.ToString());
                    }
                    else
                    {
                        Manager.modifierUser(pseudo.Text, mdp1.Password, prenom.Text, nom.Text, ddd, numTel.Text, ville.Text, boisson, PhotoDeProfil.Source.ToString());
                    }
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
                if(Mode == 1)
                {
                    MessageBox.Show("Bienvenue parmis nous :)", "Welcome", MessageBoxButton.OK);
                }
                else
                {
                    //recharger le UCProfil pour aperçu des modifs en direct
                }
                Close();
            }
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            Close();
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
