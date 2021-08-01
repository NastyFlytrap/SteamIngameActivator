using System;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media;

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
        private void Window_Startup(object sender, RoutedEventArgs e)
        {
            
            string[] paths = { Environment.CurrentDirectory, "Settings.cfg" };
            string fullpath = Path.Combine(paths);
            if (File.Exists(fullpath))
            {                
                string[] lines = File.ReadAllLines(fullpath);
                txtopener.Text = lines[0];
                txtEditor.Text = lines[0];
                idlocation.Text = lines[1];
                Exelocation.Text = lines[2];
                if (Array.Exists(lines, element => element == "true"))
                {
                    bool lighttoggle = Convert.ToBoolean(lines[3]);
                    if (lighttoggle == true)
                    {
                        MainGrid.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                        txtopener.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                        txtEditor.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                        Opentxt.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
                        Savetxt.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
                        Exelocation.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                        Browseexe.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
                        idlocation.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                        Launch.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
                        Lighty.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));

                        txtopener.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                        txtEditor.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                        Opentxt.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                        Savetxt.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                        Exelocation.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                        Browseexe.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                        idlocation.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                        Launch.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                        Lighty.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                    }
                    else
                    {
                        MainGrid.Background = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                        txtopener.Background = new SolidColorBrush(Color.FromRgb(38, 38, 38));
                        txtEditor.Background = new SolidColorBrush(Color.FromRgb(38, 38, 38));
                        Opentxt.Background = new SolidColorBrush(Color.FromRgb(38, 38, 38));
                        Savetxt.Background = new SolidColorBrush(Color.FromRgb(38, 38, 38));
                        Exelocation.Background = new SolidColorBrush(Color.FromRgb(38, 38, 38));
                        Browseexe.Background = new SolidColorBrush(Color.FromRgb(38, 38, 38));
                        idlocation.Background = new SolidColorBrush(Color.FromRgb(38, 38, 38));
                        Launch.Background = new SolidColorBrush(Color.FromRgb(38, 38, 38));
                        Lighty.Background = new SolidColorBrush(Color.FromRgb(38, 38, 38));

                        txtopener.Foreground = new SolidColorBrush(Color.FromRgb(51, 204, 51));
                        txtEditor.Foreground = new SolidColorBrush(Color.FromRgb(51, 204, 51));
                        Opentxt.Foreground = new SolidColorBrush(Color.FromRgb(51, 204, 51));
                        Savetxt.Foreground = new SolidColorBrush(Color.FromRgb(51, 204, 51));
                        Exelocation.Foreground = new SolidColorBrush(Color.FromRgb(51, 204, 51));
                        Browseexe.Foreground = new SolidColorBrush(Color.FromRgb(51, 204, 51));
                        idlocation.Foreground = new SolidColorBrush(Color.FromRgb(51, 204, 51));
                        Launch.Foreground = new SolidColorBrush(Color.FromRgb(51, 204, 51));
                        Lighty.Foreground = new SolidColorBrush(Color.FromRgb(51, 204, 51));
                    }
                }
                
                
            }
            if (idlocation.Text.Length > 0)
            {
                Savetxt.IsEnabled = true;
            }
        }

        //private void testy(object sender, RoutedEventArgs e)
        //{
        //    string[] paths = { Environment.CurrentDirectory, "Settings.cfg" };
        //    string fullpath = Path.Combine(paths);
        //    string[] lines = File.ReadAllLines(fullpath);
        //    txtopener.Text = lines[0];
        //    Exelocation.Text = lines[1];
        //}

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
                Savetxt.IsEnabled = true;
            }
            
           
        }

        private void Buttonsavetxt(object sender, RoutedEventArgs e)
        {
            if (Int32.TryParse(txtEditor.Text, out _))
            {
                File.WriteAllText(idlocation.Text, txtEditor.Text);
                txtopener.Text = txtEditor.Text;
                if (Light.IsChecked == true)
                {
                    Subwindow subWindow = new Subwindow(); //Create new window
                    subWindow.ShowDialog();
                }
                else
                {
                    WindowDark subWindow = new WindowDark(); //Create new window
                    subWindow.ShowDialog();
                }
                
            }

            else
            {
                MessageBox.Show("Only type Numbers into this box");
                return;
            }
            
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
            string[] paths2 = {Environment.CurrentDirectory, "Settings.cfg" };
            string fullpath2 = Path.Combine(paths2);
            if (!File.Exists(fullpath2))
            {
                TextWriter tw = new StreamWriter(fullpath2);
                tw.WriteLine(txtEditor.Text);
                tw.WriteLine(idlocation.Text);
                tw.WriteLine(Exelocation.Text);
                if (Light.IsChecked == true)
                {
                    tw.WriteLine("true");
                }

                else if (Light.IsChecked == false)
                {
                    tw.WriteLine("false");
                }                
                tw.Close();
            }
            else if (File.Exists(fullpath2))
            {
                TextWriter tw = new StreamWriter(fullpath2);
                tw.WriteLine(txtopener.Text);
                tw.WriteLine(idlocation.Text);
                tw.WriteLine(Exelocation.Text);
                if (Light.IsChecked == true)
                {
                    tw.WriteLine("true");
                }

                else if (Light.IsChecked == false)
                {
                    tw.WriteLine("false");
                }
                tw.Close();
            }
            //take old appid and exe location, take their values from the textboxes, convert to string, when final button is pressed make it save a .cfg in the same folder as itself
            String gamelocation = Exelocation.Text;            
            Process.Start(gamelocation);
            this.Close(); //close window
        }

        private void LightMode(object sender, RoutedEventArgs e)
        {
            if (Light.IsChecked == false)
            {
                MainGrid.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                txtopener.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                txtEditor.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                Opentxt.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
                Savetxt.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
                Exelocation.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                Browseexe.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
                idlocation.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                Launch.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
                Lighty.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));

                txtopener.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                txtEditor.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                Opentxt.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                Savetxt.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                Exelocation.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                Browseexe.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                idlocation.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                Launch.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                Lighty.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                Light.IsChecked = true;
            }
            else
            {
                MainGrid.Background = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                txtopener.Background = new SolidColorBrush(Color.FromRgb(38, 38, 38));
                txtEditor.Background = new SolidColorBrush(Color.FromRgb(38, 38, 38));
                Opentxt.Background = new SolidColorBrush(Color.FromRgb(38, 38, 38));
                Savetxt.Background = new SolidColorBrush(Color.FromRgb(38, 38, 38));
                Exelocation.Background = new SolidColorBrush(Color.FromRgb(38, 38, 38));
                Browseexe.Background = new SolidColorBrush(Color.FromRgb(38, 38, 38));
                idlocation.Background = new SolidColorBrush(Color.FromRgb(38, 38, 38));
                Launch.Background = new SolidColorBrush(Color.FromRgb(38, 38, 38));
                Lighty.Background = new SolidColorBrush(Color.FromRgb(38, 38, 38));

                txtopener.Foreground = new SolidColorBrush(Color.FromRgb(51, 204, 51));
                txtEditor.Foreground = new SolidColorBrush(Color.FromRgb(51, 204, 51));
                Opentxt.Foreground = new SolidColorBrush(Color.FromRgb(51, 204, 51));
                Savetxt.Foreground = new SolidColorBrush(Color.FromRgb(51, 204, 51));
                Exelocation.Foreground = new SolidColorBrush(Color.FromRgb(51, 204, 51));
                Browseexe.Foreground = new SolidColorBrush(Color.FromRgb(51, 204, 51));
                idlocation.Foreground = new SolidColorBrush(Color.FromRgb(51, 204, 51));
                Launch.Foreground = new SolidColorBrush(Color.FromRgb(51, 204, 51));
                Lighty.Foreground = new SolidColorBrush(Color.FromRgb(51, 204, 51));
                Light.IsChecked = false;
            }                   
        }
    }
}
