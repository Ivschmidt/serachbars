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
using System.Windows.Shapes;

namespace VuesSearchBars
{
    /// <summary>
    /// Logique d'interaction pour PasswordVerif.xaml
    /// </summary>
    public partial class PasswordVerif : Window
    {
        public PasswordVerif()
        {
            InitializeComponent();
            password.Focus();
        }

        public Manager Manager {
            get
            {
                return (Application.Current as App).Manager;
            }
        }

        private void Button_Click_Valider(object sender, RoutedEventArgs e)
        {
            if (Manager.verifierMotDePasse(password.Password))
            {
                SubscribeWindow subWindow = new SubscribeWindow(2);
                subWindow.Show();
            }
            else
            {
                MessageBox.Show("Mot de passe incorrect", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            Close();
        }

        private void Button_Click_Annuler(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Enter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Button_Click_Valider(sender, e);
            }
        }

    }
}
