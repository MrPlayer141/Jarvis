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
        string x;

        #region Main
        public AdminRoom()
        {
            InitializeComponent();
            lbl_AdminRoom.Visibility = Visibility.Hidden;
            btn_Logout.Visibility = Visibility.Hidden;
            lbl_User.Visibility = Visibility.Hidden;
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
                x = y[0]; Admin_True();
            }
            else if (tBox_User.Text == Ente_name() && tBox_pass.Password == Ente_password())
            {
                x = y[1]; Admin_True();
            }
            else if (tBox_pass.Password == Nothing)
            {
                User = tBox_User.Text;
                x = y[2] + User;
                MessageBox.Show(x, "Wilkommen User", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                lbl_AdminRoom.Visibility = Visibility.Hidden;
                lbl_Login.Visibility = Visibility.Visible;
                btn_Install_key.Visibility = Visibility.Hidden;
                btn_Logout.Visibility = Visibility.Hidden;
                lbl_Module.Visibility = Visibility.Hidden;
                MessageBox.Show("Benutzername oder Passwort falsch!", "Fehler");
            }

            
        }

        private void Admin_True()
        {

            lbl_User.Content = "Wilkommen " + tBox_User.Text;
            tBox_pass.Password = "";
            tBox_User.Text = "";

            lbl_Login.Visibility = Visibility.Hidden;
            lbl_Username.Visibility = Visibility.Hidden;
            lbl_Password.Visibility = Visibility.Hidden;
            tBox_pass.Visibility = Visibility.Hidden;
            tBox_User.Visibility = Visibility.Hidden;
            btn_Login.Visibility = Visibility.Hidden;

            lbl_AdminRoom.Visibility = Visibility.Visible;
            lbl_Module.Visibility = Visibility.Visible;
            btn_Install_key.Visibility = Visibility.Visible;
            btn_Logout.Visibility = Visibility.Visible;
            lbl_User.Visibility = Visibility.Visible;

            MessageBox.Show(x, "Wilkommen Admin", MessageBoxButton.OK, MessageBoxImage.Information);

        }
       
        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            //Button: Logout

            lbl_Login.Visibility = Visibility.Visible;
            lbl_Username.Visibility = Visibility.Visible;
            lbl_Password.Visibility = Visibility.Visible;
            tBox_pass.Visibility = Visibility.Visible;
            tBox_User.Visibility = Visibility.Visible;
            btn_Login.Visibility = Visibility.Visible;

            lbl_AdminRoom.Visibility = Visibility.Hidden;
            lbl_Login.Visibility = Visibility.Visible;
            btn_Install_key.Visibility = Visibility.Hidden;
            lbl_User.Visibility = Visibility.Hidden;
            lbl_User.Content = "";
            tBox_pass.Password = "";
            tBox_User.Text = "";
            lbl_Module.Visibility = Visibility.Hidden;

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //Button: install Keylogger


        }




        #endregion


    }
}

