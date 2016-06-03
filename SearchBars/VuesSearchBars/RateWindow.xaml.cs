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
        public RateWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_Poster(object sender, RoutedEventArgs e)
        {
            Avis avis;
            if (string.IsNullOrEmpty(textBox.Text))
                avis = new Avis((int) note.Value);
            else
                avis = new Avis((int) note.Value, textBox.Text);
        }

        private void Button_Click_Annuler(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
