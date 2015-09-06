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

        #endregion

        #region Button

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (tBox_User.Text == admin_name() && tBox_pass.Text == admin_password())
            {
                MessageBox.Show("Wilkommen Main-Developer", "Wilkommen admin", MessageBoxButton.OK, MessageBoxImage.Information);
                lbl_AdminRoom.Visibility = Visibility.Visible;
                lbl_Login.Visibility = Visibility.Hidden;
            }
        }

        #endregion

    }
}

