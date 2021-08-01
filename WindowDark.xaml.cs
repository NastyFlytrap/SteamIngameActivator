using System.Windows;

namespace SteamIngameActivator
{
    /// <summary>
    /// Interaction logic for Subwindow.xaml
    /// </summary>
    public partial class WindowDark : Window
    {
        public WindowDark()
        {
            InitializeComponent();
        }
        private void Closewindow(object sender, RoutedEventArgs e)
        {
            this.Close(); //close window
        }
    }
}
