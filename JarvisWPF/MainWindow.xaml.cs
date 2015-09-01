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

using System.Diagnostics;
using System.Threading;
using System.Speech.Synthesis;


namespace JarvisWPF
{

    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            startup();

        }

        public void startup()
        {
            
            Version();
            Uptime();
        }

        public void Version()
        {
            string sysVersion = string.Format("Willkommen . Ich lade Jarvis Version {0} Punkt {1} Punkt {2} Punkt {3} Build {4}!",
                (int) 1,
                (int) 0,
                (int) 0,
                (int) 1,
                (int) 1037
                );

            JarvisSpeak(sysVersion, VoiceGender.Male, 1);

        }
        
        public void Uptime()
        {
            PerformanceCounter perfUptimeCount = new PerformanceCounter("System", "System Up Time");
            perfUptimeCount.NextValue();
            TimeSpan uptimeSpan = TimeSpan.FromSeconds(perfUptimeCount.NextValue());
            string systemUptimeMessage = string.Format("Der Computer ist online seit {0} Tagen {1} Stunden {2} Minuten",
                (int)uptimeSpan.TotalDays,
                (int)uptimeSpan.Hours,
                (int)uptimeSpan.Minutes
                );

            JarvisSpeak(systemUptimeMessage, VoiceGender.Male, 1);
            lbl_Uptime.Content = systemUptimeMessage;

            JarvisSpeak("Wilkommen ich bin Jarvis. Das Laden weitere Informationen ist bald verfügbar, sowie das selbst Aktualisieren und die Unterstützung mehere Sprachen.", VoiceGender.Male, 2);
        }

        public static void DefaultList(string URLList)
        {
            Process p1 = new Process();
            p1.StartInfo.FileName = "chrome.exe";
            p1.StartInfo.Arguments = URLList;
            p1.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            p1.Start();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            JarvisSpeak("Fehler sind noch da. Ich bitte um nachsicht.", VoiceGender.Female, 1);

            Jarvis.BasicModule.CPU_RAM_HDD_Info Check = new Jarvis.BasicModule.CPU_RAM_HDD_Info();
            Jarvis.Code.SyS_Counter Info = new Jarvis.Code.SyS_Counter();
            int CurrentCPU = Info.CPU_Count();
            int CurrentRAM = Info.RAM_Count();

            string CPU = "CPU Belastung: " + Convert.ToString(CurrentCPU) + "%";
            string RAM = "RAM verfügbar: " + Convert.ToString(CurrentRAM) + "MB";

            lbl_CPU.Content = CPU;
            lbl_Ram.Content = RAM;

            Check.CPUandRam();
            
            //JarvisSpeak("Diese Funktion wurde Temporär entfernt wegen Code umstrukturierung", VoiceGender.Male, 2);

        }

        #region Speech
        public static SpeechSynthesizer synth = new SpeechSynthesizer();
        /// <summary>
        /// Speaks with a selected voice
        /// </summary>
        /// <param name="message"></param>
        /// <param name="voiceGender"></param>
        public static void JarvisSpeak(string message, VoiceGender voiceGender)
        {
            synth.SelectVoiceByHints(voiceGender);
            synth.Speak(message);
        }

        /// <summary>
        /// Speaks with a selected voice at a selected speed
        /// </summary>
        /// <param name="message"></param>
        /// <param name="voiceGender"></param>
        /// <param name="rate"></param>
        public static void JarvisSpeak(string message, VoiceGender voiceGender, int rate)
        {
            synth.Rate = rate;
            JarvisSpeak(message, voiceGender);

        }
        #endregion

    }

}

