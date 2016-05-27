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
            userControlSearch.RechercheLancee += OnRechercheLancee;
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
            GridMainControl.Children.Clear();
            GridMainControl.Children.Add(new UserControlSearchResult());
        }

        //lors du bouton sur clic rechercher reutilise le userControl defini en XAML mais (bug affichage : ville pas selectionnée par defaut, 
        //surement a cause du fait qu'on n'instancie pas a nouveau le UC 
        //facon peut etre plus propre :
        //ne pas geré les instances de userControls mais en creer un nouveau a chaque fois 
        //inclus de construire le premier UC (Search) dans le MainWIndow
        //mais attention dans ce cas il faut s'abonner a RechercheLAncee apres chaque instanciation donc dans MainWindow
        //et dans methode qui suit 
        //
        //pour data binding avec le reste surement passe le manager en param des UC 
        //
        //private void Button_Click_Rechercher(object sender, RoutedEventArgs e)
        //{
        //    GridMainControl.Children.Clear();
        //    UserControlSearch UCSearch = new UserControlSearch();
        //    UCSearch.RechercheLancee += OnRechercheLancee;
        //    GridMainControl.Children.Add();
        //}
    }
}
