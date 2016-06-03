﻿using System;
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
        }

        private void Button_Click_Valider(object sender, RoutedEventArgs e)
        {
            OnModification(new ModificationEventArgs(password.Password));
        }

        private void Button_Click_Annuler(object sender, RoutedEventArgs e)
        {

        }

        public event EventHandler<ModificationEventArgs> Modification;

        protected virtual void OnModification(ModificationEventArgs args)
        {
            if (Modification != null)
            {
                Modification(this, args);
            }
        }
    }
}
