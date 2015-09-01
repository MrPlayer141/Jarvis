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
        private static SpeechSynthesizer synth = new SpeechSynthesizer();
        


        public MainWindow()
        {
            InitializeComponent();
            startup();
            //Jarvis.Code.SyS_Counter info = new Jarvis.Code.CPU_RAM_INFO();
            //info.interact();
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
                (int) 2,
                (int) 1026
                );

            JarvisSpeak(sysVersion, VoiceGender.Male, 1);

        }

        public void PerformanceCounter()
        {

        }

        
        public void Uptime()
        {


            PerformanceCounter perfUptimeCount = new PerformanceCounter("System", "System Up Time");
            perfUptimeCount.NextValue();
            TimeSpan uptimeSpan = TimeSpan.FromSeconds(perfUptimeCount.NextValue());
            string systemUptimeMessage = string.Format("Der Computer ist an seit {0} Tagen {1} Stunden {2} Minuten ",
                (int)uptimeSpan.TotalDays,
                (int)uptimeSpan.Hours,
                (int)uptimeSpan.Minutes
                );

            JarvisSpeak(systemUptimeMessage, VoiceGender.Male, 1);
            lbl_Uptime.Content = systemUptimeMessage;

            JarvisSpeak("Wilkommen ich bin Jarvis. Das Laden weitere Informationen ist bald verfügbar, sowie das selbst Aktualisieren und die Unterstüzung meheren Sprachen..", VoiceGender.Male, 2);
        }



        public async void CPU_RAM()
        {


           List<string> cpuMaxedOutMessages = new List<string>();
            cpuMaxedOutMessages.Add("ACHTUNG: Die CPU jagt official Eichhörnchen!");
            cpuMaxedOutMessages.Add("ALARM! ALARM! ALARM! ALARM! Ich bin überlastet!");
            cpuMaxedOutMessages.Add("ACHTUNG: Ich gehe gleich in Flammen auf!");
            cpuMaxedOutMessages.Add("Scheinbar wilst du ein Lagerfeuer in deinen Zimmer machen so wie du mich überlastest");
            cpuMaxedOutMessages.Add("Achtung ich bin überlastet stoppe den download deiner Pornos");
            Random rand = new Random();

            JarvisSpeak("CPU Belastungs info gestartet.", VoiceGender.Male, 2);

            #region in Other Class

            //PerformanceCounter perfCpuCount = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");
            //perfCpuCount.NextValue();


            //PerformanceCounter perfMemCount = new PerformanceCounter("Memory", "Available MBytes");
            //perfMemCount.NextValue();

            //int currentCpuPercentage = (int)perfCpuCount.NextValue();
            //int currentAvailableMemory = (int)perfMemCount.NextValue();

            #endregion



            int speechSpeed = 1;


                

            //    lbl_CPU.Content = "CPU Belastung: " + currentCpuPercentage + "%";
            //    lbl_Ram.Content = "Ram verfügbar: " + currentAvailableMemory;

            //    #region Logic
            //    if ( currentCpuPercentage > 80 )
            //    {
            //        if (currentCpuPercentage == 100)
            //        {
            //            string cpuLoadVocalMessage = cpuMaxedOutMessages[rand.Next(5)];
            //            JerrySpeak(cpuLoadVocalMessage, VoiceGender.Male, speechSpeed);
            //        }
            //        else
            //        {
            //            string cpuLoadVocalMessage = String.Format("Die CPU ist zu {0} Prozent belastet", currentCpuPercentage);
            //            JerrySpeak(cpuLoadVocalMessage, VoiceGender.Male, 1);
            //        }
            //    }
            //    #endregion


            //if (currentAvailableMemory > 1024)
            //{
            //    string memAvailableVocalMessage = String.Format("Du hast {0} Megabite vom Arbeitsspeicher verfügbar",
            //        currentAvailableMemory);
            //    JarvisSpeak(memAvailableVocalMessage, VoiceGender.Male, 1);
            //}
            //else
            //{
            //    JarvisSpeak("Achtung du hast kaum noch Arbeitsspeicher.", VoiceGender.Male, 1);
            //}


        }

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
            //JarvisSpeak("Fehler sind noch da. Ich bitte um nachsicht.", VoiceGender.Female, 1);
            //CPU_RAM();
            JarvisSpeak("Diese Funktion wurde Temporär entfernt wegen Code umstrukturierung", VoiceGender.Male, 2);
        } 

        }
    }

