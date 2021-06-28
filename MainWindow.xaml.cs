using System;
using System.IO;
using Microsoft.Win32;
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

namespace SteamIngameActivator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Buttonopentxt(object sender, RoutedEventArgs e)
        {
                        OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                
                txtopener.Text = File.ReadAllText(openFileDialog.FileName);
            }
            
            openFileDialog.Filter = "Text files (*.txt)|*.txt"; //Thanks https://wpf-tutorial.com/dialogs/the-openfiledialog/ !
        }

        private void Buttonsavetxt(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, txtEditor.Text);
            }
        }

        private void Buttonfindexe(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog 
            OpenFileDialog dlg = new OpenFileDialog
            {
                // Set filter for file extension and default file extension 
                DefaultExt = ".exe",
                Filter = "EXE Files (*.exe)|*.exe"
            };


            // Display OpenFileDialog by calling ShowDialog method 
            bool? result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                Exelocation.Text = filename;
            }
        }

    }
}
