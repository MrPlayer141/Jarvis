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
using InI;
using System.Threading;

namespace Jarvis_worker
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Var
        bool Changelog = false;
        bool Detail = false;
        string directory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

        #endregion

        public MainWindow()
        {
            InitializeComponent();
            Init();

        }

        #region function

        private void Init()
        {
            cBox_Version.Items.Add("Alpha");
            cBox_Version.Items.Add("Beta");
            cBox_Version.Items.Add("Release");
            cBox_Item.Items.Add("+");
            cBox_Item.Items.Add("-");
            cBox_Item.Items.Add("~");
            Hidden();
        }

        private void Hidden()
        {   
            lbl_Changelog.Visibility = Visibility.Hidden;
            btn_add.Visibility = Visibility.Hidden;
            tBox_AddItem.Visibility = Visibility.Hidden;
            //tBox_Items.Visibility = Visibility.Hidden;
            cBox_Item.Visibility = Visibility.Hidden;
            btn_CHoff.Visibility = Visibility.Hidden;
            lBox_Ch.Visibility = Visibility.Hidden;
            lBox_Items.Visibility = Visibility.Hidden;
            btn_DetailOff.Visibility = Visibility.Hidden;
            btn_DetailOn.Visibility = Visibility.Hidden;
            tBox_Detail.Visibility = Visibility.Hidden;
            Changelog = false;
            Detail = false;
        }
        private void Visible()
        {
            lbl_Changelog.Visibility = Visibility.Visible;
            btn_add.Visibility = Visibility.Visible;
            tBox_AddItem.Visibility = Visibility.Visible;
           // tBox_Items.Visibility = Visibility.Visible;
            cBox_Item.Visibility = Visibility.Visible;
            btn_CHoff.Visibility = Visibility.Visible;
            lBox_Ch.Visibility = Visibility.Visible;
            lBox_Items.Visibility = Visibility.Visible;
            btn_DetailOn.Visibility = Visibility.Visible;
            Changelog = true;
        }

        private void sendUpdate()
        {
            MessageBox.Show("True");

            INI_packer();
            Thread.Sleep(1000);
            if (Changelog == true)
            {
                Changelog_packer();
                Thread.Sleep(1000);
            }
            Update_send();
            Thread.Sleep(1000);
            Clear();
        }

        private void is_update()
        {
            //Test if all settings for the update ok.
            MessageBox.Show("Debug 1");

        }

        private void INI_packer()
        {
            //Generate the ini file for the update.
            string Version = Convert.ToString(cBox_Version.SelectedItem) + " " + Convert.ToString(tBox_Version_Main.Text) + "." + Convert.ToString(tBox_Version_second.Text) + "." + Convert.ToString(tBox_Version_pre.Text) + "." + Convert.ToString(tBox_Version_preBuild.Text) + " Build " + Convert.ToString(tBox_Version_Build.Text);
            MessageBox.Show(Version);
            IniFile Packer = new IniFile(directory + "/Data/Config.ini");

        }

        private void Changelog_packer()
        {
            //Generate the Changelog or update it
            MessageBox.Show("Debug 3");
        }

        private void Update_send()
        {
            //send the Update to the main Server.
            MessageBox.Show("Debug 4");
        }

        private void Clear()
        {
            //Clear all files

            MessageBox.Show("Debug 5");
        }

        #endregion

        #region Button


        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            if (tBox_AddItem.Text == "")
            {
                MessageBox.Show("Bitte einen Text eingeben", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                lBox_Ch.Items.Add(cBox_Item.SelectedItem);
                lBox_Items.Items.Add(tBox_AddItem.Text);
            }
        }

        private void btn_DetailOn_Click(object sender, RoutedEventArgs e)
        {
            btn_DetailOff.Visibility = Visibility.Visible;
            tBox_Detail.Visibility = Visibility.Visible;
            btn_DetailOn.Visibility = Visibility.Visible;
            Detail = true;
        }

        private void btn_DetailOff_Click(object sender, RoutedEventArgs e)
        {
            btn_DetailOff.Visibility = Visibility.Hidden;
            btn_DetailOn.Visibility = Visibility.Visible;
            tBox_Detail.Visibility = Visibility.Hidden;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {


        }

        private void btn_CHon_Click(object sender, RoutedEventArgs e)
        {
            btn_CHoff.Visibility = Visibility.Visible;
            btn_CHon.Visibility = Visibility.Hidden;
            Visible();
        }

        private void btn_CHoff_Click(object sender, RoutedEventArgs e)
        {
            btn_CHon.Visibility = Visibility.Visible;
            Hidden();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Would you like to send the Update?", "Send Update?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
            { }
            else
            {
                sendUpdate();
            }
        }
       

        #endregion

        #region unused
        private void tBox_Items_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void cBox_Item_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cBox_Version_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void tBox_Version_Main_TextChanged(object sender, TextChangedEventArgs e)
        {

        }



        #endregion

    }
}
