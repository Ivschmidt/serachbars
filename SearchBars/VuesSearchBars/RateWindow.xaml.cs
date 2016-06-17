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

namespace VuesSearchBars
{
    /// <summary>
    /// Logique d'interaction pour RateWindow.xaml
    /// </summary>
    public partial class RateWindow : Window
    {
        public RateWindow(IBar bar)
        {
            Bar = bar;
            InitializeComponent();
        }

        private IBar Bar { get; set; }

        private void Button_Click_Poster(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox.Text))
                    Manager.laisserUnAvis(Bar, (int) note.Value);
                else
                    Manager.laisserUnAvis(Bar, (int) note.Value, textBox.Text);
            }catch 
            {
                MessageBox.Show("Vous avez déja laissé un avis pour ce bar", "Action interdite", MessageBoxButton.OK, MessageBoxImage.Stop);
            }

            Close();
        }

        private void Button_Click_Annuler(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public Manager Manager
        {
            get
            {
                return (Application.Current as App).Manager;
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                Button_Click_Poster(sender, e);
            }
        }
    }
}
