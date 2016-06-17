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
using MetierSearchBars;
using DataSearchBars;
using SearchBars;

namespace VuesSearchBars
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = Manager;
            loadUCSearch();
        }

        public Manager Manager {
            get
            {
                return (Application.Current as App).Manager;
            }
        }
        private void loadUCSearch()
        {
            GridMainControl.Children.Clear();
            UserControlSearch UCSearch = new UserControlSearch();
            UCSearch.RechercheLancee += OnRechercheLancee;
            GridMainControl.Children.Add(UCSearch);
        }


        private void Button_Click_Deco(object sender, RoutedEventArgs e)
        {
            Manager.seDeconnecter();
            ConnectionWindow connect = new ConnectionWindow();
            connect.Show();
            this.Close();
        }

        public void OnRechercheLancee(object sender, RechercheLanceeEventArgs args)
        {
            Manager.rechercherBars(args.Ville, args.Restauration, args.BoissonsPref, args.NoteMin);
            GridMainControl.Children.Clear();
            GridMainControl.Children.Add(new UserControlMaster(Manager.BarRecherches, args.Ville));
        }

        private void Button_Click_Rechercher(object sender, RoutedEventArgs e)
        {
            loadUCSearch();
        }

        private void Button_Click_Compte(object sender, RoutedEventArgs e)
        {
            loadUCProfil();
        }

        public void loadUCProfil()
        {
            GridMainControl.Children.Clear();
            UserControlProfil UCProfil = new UserControlProfil(Manager.CurrentUser);
            UCProfil.ProfilUpdated += OnProfilUpdated;
            GridMainControl.Children.Add(UCProfil);
        }

        public void OnProfilUpdated(object sender, ProfilUpdatedEventArgs args)
        {
            loadUCProfil();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Manager.seDeconnecter();
        }

        private void ColumnDefinition_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                Button_Click_Rechercher(sender,e);
            }
            if (e.Key == Key.F2)
            {
                Button_Click_Compte(sender, e);
            }
            if (e.Key == Key.F3)
            {
                Button_Click_Deco(sender, e);
            }
            
        }
    }
}
