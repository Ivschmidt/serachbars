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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataSearchBars;
using MetierSearchBars;

namespace VuesSearchBars
{
    /// <summary>
    /// Logique d'interaction pour UserControlResultBar.xaml
    /// </summary>
    public partial class UserControlResultBar : UserControl
    {
        private Manager Manager
        {
            get;
            set;
        }


        public UserControlResultBar()
        {
           InitializeComponent();

            //Manager = new Manager(new Stubb());

            DataContext = Manager;
        }
    }
}
