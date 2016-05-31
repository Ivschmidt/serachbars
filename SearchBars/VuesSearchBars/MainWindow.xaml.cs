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
        private Manager manager;
        public MainWindow(Manager manager)
        {
            InitializeComponent();
            this.manager = manager;
            DataContext = manager;
            loadUCSearch();
        }

        private void loadUCSearch()
        {
            GridMainControl.Children.Clear();
            UserControlSearch UCSearch = new UserControlSearch(manager);
            UCSearch.RechercheLancee += OnRechercheLancee;
            GridMainControl.Children.Add(UCSearch);
        }


        private void Button_Click_Deco(object sender, RoutedEventArgs e)
        {
            manager.seDeconnecter();
            ConnectionWindow connect = new ConnectionWindow();
            connect.Show();
            this.Close();
        }

        public void OnRechercheLancee(object sender, RechercheLanceeEventArgs args)
        {
            manager.rechercherBars(args.Ville, args.Restauration, args.BoissonsPref, args.NoteMin);
            GridMainControl.Children.Clear();
            GridMainControl.Children.Add(new UserControlMaster(manager.BarRecherches, args.Ville));
            //GridMainControl.Children.Add(new UserControlSearchResult(manager.BarRecherches, args.Ville)); //appelle le UC avec ville et map de la ville
        }

        private void Button_Click_Rechercher(object sender, RoutedEventArgs e)
        {
            loadUCSearch();
        }

        private void Button_Click_Compte(object sender, RoutedEventArgs e)
        {
            GridMainControl.Children.Clear();
            int age = manager.CalculAge(manager.CurrentUser.DdN);
            UserControlProfil UCProfil = new UserControlProfil(manager.CurrentUser, age);
            UCProfil.ModificationDisplaying += this.OnModificationDisplaying;
            GridMainControl.Children.Add(UCProfil);
        }

        public void OnModificationDisplaying(object sender, ModificationDisplayingEventArgs args)
        {
            SubscribeWindow subWind = new SubscribeWindow(manager, 2);
            subWind.Show();
        }
        
    }
}
