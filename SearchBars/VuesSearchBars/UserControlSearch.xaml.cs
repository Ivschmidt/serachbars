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
using MetierSearchBars;
using DataSearchBars;

namespace VuesSearchBars
{
    /// <summary>
    /// Logique d'interaction pour UserControlSearch.xaml
    /// </summary>
    public partial class UserControlSearch : UserControl
    {
        //peut etre recuperer la list de villes plutot que la manager en entier
        public UserControlSearch()
        {
            InitializeComponent();
            Manager = manager;
        }

        public Manager manager {
            get
            {
                return (Application.Current as App).Manager;
            }
        }

        public Manager Manager
        {
            get { return (Manager)GetValue(ManagerProperty); }
            set { SetValue(ManagerProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Manager.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ManagerProperty =
            DependencyProperty.Register("Manager", typeof(Manager), typeof(UserControlSearch), new PropertyMetadata(null));

        public event EventHandler<RechercheLanceeEventArgs> RechercheLancee;

        protected virtual void OnRechercheLancee(RechercheLanceeEventArgs args)
        {
            if(RechercheLancee != null)
            {
                RechercheLancee(this, args);
            }
        }

        private void Button_Click_Rechercher(object sender, RoutedEventArgs e)
        {
            List<TypeBoisson> listBoissonsPref = new List<TypeBoisson>();

            if (BoissonPref1.SelectedItem != null)
            {
                listBoissonsPref.Add((TypeBoisson) BoissonPref1.SelectedItem);
            }
            if(BoissonPref2.SelectedItem != null)
            {
                listBoissonsPref.Add((TypeBoisson)BoissonPref2.SelectedItem);
            }
            OnRechercheLancee(new RechercheLanceeEventArgs(comboBox_Ville.SelectedItem as IVille, (bool) RadioButton_oui.IsChecked, noteMin.Value, listBoissonsPref));
        }

       
    }
}
