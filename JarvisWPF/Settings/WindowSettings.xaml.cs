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

using System.Speech.Synthesis;

namespace Jarvis.Settings
{
    /// <summary>
    /// Interaktionslogik für WindowSettings.xaml
    /// </summary>
    public partial class WindowSettings : Window
    {
        public static SpeechSynthesizer synth = new SpeechSynthesizer();
        public WindowSettings()
        {
            InitializeComponent();
            init_Buttons();
            init_Infos();
        }

        #region var

        #endregion

        // FTP Login: visualStudio_Project_Jarvis Passwort: // %20 14 \\

        private void init_Infos()
        {
            string Version = string.Format("{0} {1}.{2}.{3}.{4} Build {5}",
               (string)SettingsVersion.Default.Main,
               (byte)SettingsVersion.Default.Ver_Main,
               (byte)SettingsVersion.Default.Ver_Unter,
               (byte)SettingsVersion.Default.Ver_Pre,
               (byte)SettingsVersion.Default.Ver_PreBuild,
               (byte)SettingsVersion.Default.Build
               );
            synth.Volume = SettingsJarvis.Default.Volume;
            lbl_Culture.Content = synth.Voice.Culture;
            lbl_Age.Content = synth.Voice.Age;
            lbl_Gender.Content = synth.Voice.Gender;
            lbl_Sound.Content = Convert.ToString(synth.Volume);
            pBar.Value = synth.Volume;
            lbl_Version.Content = Version;
            slider.Value = synth.Volume;
        }

        private void init_Buttons()
        {
            if (SettingsJarvis.Default.fastStart == true)
            {
                btn_fastOff.IsEnabled = true;
                btn_fastOn.IsEnabled = false;
            }
            else
            {
                btn_fastOff.IsEnabled = false;
                btn_fastOn.IsEnabled = true;
            }

            if (SettingsJarvis.Default.Silent == true)
            {
                btn_silentOff.IsEnabled = true;
                btn_silentOn.IsEnabled = false;
            }
            else
            {
                btn_silentOn.IsEnabled = true;
                btn_silentOff.IsEnabled = false;
            }
        }


        #region Buttons
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            SettingsJarvis.Default.fastStart = true;
            btn_fastOff.IsEnabled = true;
            btn_fastOn.IsEnabled = false;
            
        }

        private void btn_fastOff_Click(object sender, RoutedEventArgs e)
        {
            SettingsJarvis.Default.fastStart = false;
            btn_fastOff.IsEnabled = false;
            btn_fastOn.IsEnabled = true;
        }

        private void btn_silentOn_Click(object sender, RoutedEventArgs e)
        {
            slider.IsEnabled = false;
            btn_TestSound.IsEnabled = false;
            SettingsJarvis.Default.SilentBackup = Convert.ToByte(synth.Volume);
            SettingsJarvis.Default.Volume = 0;
            init_Infos();
            btn_silentOff.IsEnabled = true;
            btn_silentOn.IsEnabled = false;
        }

        private void btn_silentOff_Click(object sender, RoutedEventArgs e)
        {
            slider.IsEnabled = true;
            btn_TestSound.IsEnabled = true;
            SettingsJarvis.Default.Volume = SettingsJarvis.Default.SilentBackup;
            SettingsJarvis.Default.SilentBackup = 0;
            init_Infos();
            btn_silentOff.IsEnabled = false;
            btn_silentOn.IsEnabled = true;
        }

        #endregion

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {         
            synth.Volume = (int)slider.Value;
            lbl_Sound.Content = Convert.ToString(synth.Volume);
            pBar.Value = synth.Volume;
            SpeakAsync();
        }
        bool speak = false;
        bool enable = false;

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            
            if (enable == false)
            { enable = true; }
            else { enable = false; }
            if (enable)
            {
                SpeakAsync();
                speak = true;
            }
            else
            {
                speak = false;
                synth.SpeakAsyncCancelAll();
            }
        }


           private async void SpeakAsync()
         {
            if (speak == true)
            {
                synth.SpeakAsync("Hallo ich bin Jarvis");
            }

        }



        private void button3_Click(object sender, RoutedEventArgs e)
        {
            SettingsJarvis.Default.Save();
        }


    }
}
