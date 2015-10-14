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

using System.Data;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Jarvis_FileManager
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //sort code with regions

        string directory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

        public MainWindow()
        {
            InitializeComponent();
            LoadDefaultFiles();
            MainUser.Visibility = Visibility.Hidden;
            CustomUser.Visibility = Visibility.Hidden;
        }

        private void LoadDefaultFiles()
        {
            tBox_Upload_File.Text = directory;
        }


        private void DG_Loaded(object sender, RoutedEventArgs e)
        {
            int Zahl = 1000;
            var items = new List<File>();
            items.Add(new File("", Zahl,"Test", false));
            items.Add(new File("", Zahl, "Test", false));
            var grid = sender as DataGrid;
            grid.ItemsSource = items;
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                tBox_Upload_File.Text = filename;
            }
        }
    }



    public class File
    {
        public string FileName { get; set; }
        public int Size { get; set; }
        public string Status { get; set; }
        public bool installed { get; set; }

        public File(string FileName, int Size, string Status, bool installed)
        {
            this.FileName = FileName;
            this.Size = Size;
            this.Status = Status;
            this.installed = installed;
        }

    }

}
