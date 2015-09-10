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

using System.Diagnostics;

namespace Jarvis
{
    /// <summary>
    /// Interaktionslogik für AdminRoom.xaml
    /// </summary>
    public partial class AdminRoom : Window
    {

        #region Main
        public AdminRoom()
        {
            InitializeComponent();
            lbl_AdminRoom.Visibility = Visibility.Hidden;
            btn_Logout.Visibility = Visibility.Hidden;
        }
        #endregion

        #region Admin Username

        public string admin_name()
        {
            string Username;
            return Username = "Game_Gen";
        }

        public string admin_password()
        {
            string password;
            return password = "MIcUha";
        }

        public string Ente_name()
        {
            string Username;
            return Username = "Ente";
        }

        public string Ente_password()
        {
            string password;
            return password = "entenzelder";

        }

        #endregion

        #region Button


        private void button_Click(object sender, RoutedEventArgs e)
        {
            string User;
            string Nothing = "";

            List<string> y = new List<string>();
            y.Add("Wilkommen Main-Developer !");
            y.Add("Wilkommen Ente !");
            y.Add("Wilkommen ");

            if (tBox_User.Text == admin_name() && tBox_pass.Password == admin_password())
            {
                string x = y[0];
                lbl_AdminRoom.Visibility = Visibility.Visible;
                lbl_Login.Visibility = Visibility.Hidden;
                btn_Install_key.Visibility = Visibility.Visible;
                btn_Logout.Visibility = Visibility.Visible;

                MessageBox.Show(x, "Wilkommen Admin", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (tBox_User.Text == Ente_name() && tBox_pass.Password == Ente_password())
            {
                string x = y[1];
                lbl_AdminRoom.Visibility = Visibility.Visible;
                lbl_Login.Visibility = Visibility.Hidden;
                btn_Logout.Visibility = Visibility.Visible;
                MessageBox.Show(x, "Wilkommen Admin", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (tBox_pass.Password == Nothing)
            {
                User = tBox_User.Text;
                string x = y[2] + User;
                MessageBox.Show(x, "Wilkommen User", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                lbl_AdminRoom.Visibility = Visibility.Hidden;
                lbl_Login.Visibility = Visibility.Visible;
                btn_Install_key.Visibility = Visibility.Hidden;
                btn_Logout.Visibility = Visibility.Hidden;
            }


        }


       
        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            //Button: Logout
            lbl_AdminRoom.Visibility = Visibility.Hidden;
            lbl_Login.Visibility = Visibility.Visible;
            btn_Install_key.Visibility = Visibility.Hidden;
            tBox_pass.Password = "";
            tBox_User.Text = "";

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //Button: install Keylogger


        }




        #endregion


    }
}

