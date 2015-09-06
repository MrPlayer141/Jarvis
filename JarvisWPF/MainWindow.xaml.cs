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
        bool IDE = true;

        public MainWindow()
        {
            InitializeComponent();
            Update_Info();
            startup();

        }

        #region Startup
        public void startup()
        {
            if (IDE == true)
            {}
            else
            {
                Version();
                Uptime();
                Hello();
                bugDisclamer();
                roadmap();
            }
        }

        public void Version()
        {
            string sysVersion = string.Format("Willkommen . Ich lade Jarvis {0} Version {1} Punkt {2} Punkt {3} Punkt {4} Build {5}!",
                (string)"Alpha",
                (int) 1,
                (int) 0,
                (int) 0,
                (int) 2,
                (int) 1100
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
        }

        public void Hello()
        {
            JarvisSpeak("Wilkommen ich bin Jarvis. Das Laden weitere Informationen ist bald verfügbar, sowie das selbst Aktualisieren und die Unterstützung mehere Sprachen.", VoiceGender.Male, 2);
        }

        public void bugDisclamer()
        {
            JarvisSpeak("Die Entwicklung von Jarvis hat noch keinen stabielen zustand erreicht. Deshalb können noch fehler auftreten. Fehler können auf Git Hab gemeldet werden.", VoiceGender.Female, 1);
        }

        public void roadmap()
        {
            JarvisSpeak("Die geplante Weiterentwicklung von Jarvis kann auf Trello punkt Kom angeschaut werden.", VoiceGender.Male, 1);

        }

        #endregion

        #region Fuktionen

        public void Update_Info()
        {
            Jarvis.Code.SyS_Counter Info = new Jarvis.Code.SyS_Counter();

            PerformanceCounter perfUptimeCount = new PerformanceCounter("System", "System Up Time");
            perfUptimeCount.NextValue();
            TimeSpan uptimeSpan = TimeSpan.FromSeconds(perfUptimeCount.NextValue());
            string systemUptimeMessage = string.Format("Der Computer ist online seit {0} Tagen {1} Stunden {2} Minuten",
                (int)uptimeSpan.TotalDays,
                (int)uptimeSpan.Hours,
                (int)uptimeSpan.Minutes
                );
            lbl_Uptime.Content = systemUptimeMessage;

            Process currentProc = Process.GetCurrentProcess();
            long memoryUsed = currentProc.PrivateMemorySize64 / 1024 / 1024;

            int CurrentCPU = Info.CPU_Count();
            int CurrentRAM = Info.RAM_Count();

            string CPU = "CPU Belastung: " + Convert.ToString(CurrentCPU) + "%";
            string RAM = "RAM verfügbar: " + Convert.ToString(CurrentRAM) + "MB";

            lbl_CPU.Content = CPU;
            lbl_Ram.Content = RAM;
            lbl_JavisRam.Content = "Jarvis nutzt " + Convert.ToString(memoryUsed) + " MB RAM";

            Thread.Sleep(500);
        }

        #endregion

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

        #region Buttons

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Button: CPU and RAM Info
            Jarvis.BasicModule.CPU_RAM_HDD_Info Check = new Jarvis.BasicModule.CPU_RAM_HDD_Info();
            Update_Info();
            Check.CPUandRam();

            //JarvisSpeak("Diese Funktion wurde Temporär entfernt wegen Code umstrukturierung", VoiceGender.Male, 2);
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            //Button: Fehler Melden
            Process.Start("https://github.com/MrPlayer141/Jarvis/issues");
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //Button: Update
            Update_Info();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            //Button: Trello
            Process.Start("https://trello.com/b/CKa6GwBX/jarvis");
        }
        #endregion
    }

}

