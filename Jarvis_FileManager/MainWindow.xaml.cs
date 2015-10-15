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
        bool edit = false;

        public MainWindow()
        {
            InitializeComponent();
            LoadDefaultFiles();
            FileManager.Visibility = Visibility.Hidden;
            MainUser.Visibility = Visibility.Hidden;
            CustomUser.Visibility = Visibility.Visible;
            Init();
        }

        private void Init()
        {
            tBox_Slot1.Text = Convert.ToString(btn_Slot1.Content);
            tBox_Slot2.Text = Convert.ToString(btn_Slot2.Content);
            tBox_Slot3.Text = Convert.ToString(btn_Slot3.Content);
            tBox_Slot4.Text = Convert.ToString(btn_Slot4.Content);
            tBox_Slot5.Text = Convert.ToString(btn_Slot5.Content);
            tBox_Slot1.Visibility = Visibility.Hidden;
            tBox_Slot2.Visibility = Visibility.Hidden;
            tBox_Slot3.Visibility = Visibility.Hidden;
            tBox_Slot4.Visibility = Visibility.Hidden;
            tBox_Slot5.Visibility = Visibility.Hidden;

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

        private void btn_edit_Click(object sender, RoutedEventArgs e)
        {
            if (edit == true)
            {
                if (tBox_Slot1.Text == Convert.ToString(btn_Slot1.Content) &&
                tBox_Slot2.Text == Convert.ToString(btn_Slot2.Content) &&
                tBox_Slot3.Text == Convert.ToString(btn_Slot3.Content) &&
                tBox_Slot4.Text == Convert.ToString(btn_Slot4.Content) &&
                tBox_Slot5.Text == Convert.ToString(btn_Slot5.Content)
                    )
                {
                    tBox_Slot1.Visibility = Visibility.Hidden;
                    tBox_Slot2.Visibility = Visibility.Hidden;
                    tBox_Slot3.Visibility = Visibility.Hidden;
                    tBox_Slot4.Visibility = Visibility.Hidden;
                    tBox_Slot5.Visibility = Visibility.Hidden;


                }
                else { MessageBox.Show("Speichern!!!!", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error); }
            }
            else
            {
                edit = true;
                tBox_Slot1.Visibility = Visibility.Visible;
                tBox_Slot2.Visibility = Visibility.Visible;
                tBox_Slot3.Visibility = Visibility.Visible;
                tBox_Slot4.Visibility = Visibility.Visible;
                tBox_Slot5.Visibility = Visibility.Visible;

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
