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
        }

                
        private void Button_Click_Deco(object sender, RoutedEventArgs e)
        {
            manager.seDeconnecter();
            ConnectionWindow connect = new ConnectionWindow();
            connect.Show();
            this.Close();
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    UserControlSearchResult unUserControl = new UserControlSearchResult();

        //}
    }
}
