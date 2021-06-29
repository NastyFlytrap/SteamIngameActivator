using System;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;
using System.Windows;

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
        //add loading of the .cfg!
        private void Buttonopentxt(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog 
            {
                DefaultExt = ".txt",
                Filter = "Text Files (*.txt)|*.txt"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                string applocation = openFileDialog.FileName;
                idlocation.Text = applocation;
                txtopener.Text = File.ReadAllText(openFileDialog.FileName);
                openFileDialog.Filter = "Text files (*.txt)|*.txt"; //Thanks https://wpf-tutorial.com/dialogs/the-openfiledialog/ !
            }
            
           
        }

        private void Buttonsavetxt(object sender, RoutedEventArgs e)
        {

            File.WriteAllText(idlocation.Text, txtEditor.Text);
            Subwindow subWindow = new Subwindow(); //Create new window
            subWindow.Show();
        }

        private void Buttonfindexe(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog 
            OpenFileDialog exe = new OpenFileDialog
            {
                // Set filter for file extension and default file extension 
                DefaultExt = ".exe",
                Filter = "EXE Files (*.exe)|*.exe"
            };


            // Display OpenFileDialog by calling ShowDialog method 
            bool? result = exe.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = exe.FileName;
                Exelocation.Text = filename;
            }
        }

       

        private void Launchactivator(object sender, RoutedEventArgs e)
        {
            string[] paths = {Environment.CurrentDirectory, "Settings.cfg" };
            string fullpath = Path.Combine(paths);
            if (!File.Exists(fullpath))
            {
                TextWriter tw = new StreamWriter(fullpath);
                tw.WriteLine(txtopener.Text);
                tw.WriteLine(Exelocation.Text);
                tw.Close();
            }
            else if (File.Exists(fullpath))
            {
                TextWriter tw = new StreamWriter(fullpath);
                tw.WriteLine(txtopener.Text);
                tw.WriteLine(Exelocation.Text);
                tw.Close();
            }
            //take old appid and exe location, take their values from the textboxes, convert to string, when final button is pressed make it save a .cfg in the same folder as itself
            String gamelocation = Exelocation.Text;            
            Process.Start(gamelocation);
            this.Close(); //close window
        }
    }
}
