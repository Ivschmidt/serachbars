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

namespace SearchBars
{
    /// <summary>
    /// Logique d'interaction pour SubscribeWindow.xaml
    /// </summary>
    public partial class SubscribeWindow : Window
    {
        private Manager manager;

        public SubscribeWindow(Manager manager)
        {
            InitializeComponent();
            this.manager = manager;
        }

        private void Button_Click_Subscribe(object sender, RoutedEventArgs e)
        {
            //manager.sInscrire();
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
