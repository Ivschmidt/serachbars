﻿using MetierSearchBars;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
                DdND.Text = "jj";
                DdNM.Text = "mm";
                DdNY.Text = "aaaa";
                var chemin = string.Format("{0}\\VuesSearchBars\\Images\\photoprofil.jpg", Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName);
                PhotoDeProfil.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(chemin);
            }
            else
            {
                NomPage.Text = "Modification :";
                ButtonPage.Content = "Modifier";
                sexeText.Visibility = Visibility.Hidden;
                sexeButtons.Visibility = Visibility.Hidden;
                pseudo.IsReadOnly = true;
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
                    OnProfilUpdated(new ProfilUpdatedEventArgs());
                }
                Close();
            }
        }

        public event EventHandler<ProfilUpdatedEventArgs> ProfilUpdated;
        protected virtual void OnProfilUpdated(ProfilUpdatedEventArgs args)
        {
            if(ProfilUpdated != null)
            {
                ProfilUpdated(this, args);
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
            if (!string.IsNullOrEmpty(pseudo.Text) && pseudo.Text != null)
            {

                OpenFileDialog file = new OpenFileDialog();
                file.ShowDialog();


                var chemin = file.FileName;

                PhotoDeProfil.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(chemin);

                DirectoryInfo dirInfo = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent;
                var directory = string.Format("{0}\\VuesSearchBars\\Images\\ImagesProfils\\", dirInfo.FullName);
                var fileDest = string.Format("{0}{1}.jpg", directory, pseudo.Text);
                System.IO.File.Copy(chemin, fileDest);

            }
            else
            {
                MessageBox.Show("Veuillez mettre un pseudo valide svp", "Pseudo invalide", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Validation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Button_Click_Subscribe(sender, e);
            }
        }

        public void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_GotFocus;
        }
    }
}
