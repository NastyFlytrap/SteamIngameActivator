﻿using System.Windows;

namespace SteamIngameActivator
{
    /// <summary>
    /// Interaction logic for Subwindow.xaml
    /// </summary>
    public partial class Subwindow : Window
    {
        public Subwindow()
        {
            InitializeComponent();
        }
        private void Closewindow(object sender, RoutedEventArgs e)
        {
            this.Close(); //close window
        }
    }
}
