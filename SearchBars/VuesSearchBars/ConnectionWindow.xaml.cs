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
    /// Logique d'interaction pour ConnectionWindow.xaml
    /// </summary>
    public partial class ConnectionWindow : Window
    {
        private Manager manager;
        public ConnectionWindow()
        {
            manager = new Manager(new StubData());
            InitializeComponent();
        }

        private void Button_Click_Connexion(object sender, RoutedEventArgs e)
        {
            if (manager.seConnecter(pseudo.Text, mdp.Password))
            {
                MainWindow mainWindow = new MainWindow(manager);
                mainWindow.Show();
                this.Close();
            }
            else
            { 
                MessageBox.Show("Mot de passe ou pseudo incorrects", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Button_Click_Subscribe(object sender, RoutedEventArgs e)
        {
            SubscribeWindow subWind = new SubscribeWindow(manager,1);
            subWind.Show();
        }

        private void Connection_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Button_Click_Connexion(sender, e);
            }
        }

    }
}
