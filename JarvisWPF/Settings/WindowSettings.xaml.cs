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

namespace Jarvis.Settings
{
    /// <summary>
    /// Interaktionslogik für WindowSettings.xaml
    /// </summary>
    public partial class WindowSettings : Window
    {
        public WindowSettings()
        {
            InitializeComponent();
            init_Buttons();
        }

        private void init_Buttons()
        {

            if (Properties.Settings.Default.fastStart == true)
            {
                btn_fastOff.IsEnabled = true;
                btn_fastOn.IsEnabled = false;
            }
            else
            {
                btn_fastOff.IsEnabled = false;
                btn_fastOn.IsEnabled = true;
            }


        }


        #region Buttons
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.fastStart = true;
            btn_fastOff.IsEnabled = true;
            btn_fastOn.IsEnabled = false;
            Properties.Settings.Default.Save();
        }

        private void btn_fastOff_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.fastStart = false;
            btn_fastOff.IsEnabled = false;
            btn_fastOn.IsEnabled = true;
            Properties.Settings.Default.Save();
        }


        #endregion

    }
}
