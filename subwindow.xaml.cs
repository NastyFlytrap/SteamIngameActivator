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

namespace SteamIngameActivator
{
    /// <summary>
    /// Interaction logic for subwindow.xaml
    /// </summary>
    public partial class subwindow : Window
    {
        public subwindow()
        {
            InitializeComponent();
        }
        private void Closewindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
