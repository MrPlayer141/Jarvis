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

        private void init_Infos()
        {
            string Version = string.Format("{0} {1}.{2}.{3}.{4} Build {5}",
               (string)SettingsVersion.Default.Main,
               (int)SettingsVersion.Default.Ver_Main,
               (int)SettingsVersion.Default.Ver_Unter,
               (int)SettingsVersion.Default.Ver_Pre,
               (int)SettingsVersion.Default.Ver_PreBuild,
               (int)SettingsVersion.Default.Build
               );

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
        
    }
}
