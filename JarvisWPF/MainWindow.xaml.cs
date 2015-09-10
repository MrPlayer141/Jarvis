﻿using System;
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

using System.Speech.Synthesis;
using System.Diagnostics;
using System.Threading;

namespace JarvisWPF
{

    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            Jarvis.Code.Startup st = new Jarvis.Code.Startup();
            InitializeComponent();
            Update_Info();
            st.startup();

        }


        #region Fuktionen

        public void Update_Info()
        {
            Jarvis.Code.SyS_Counter Info = new Jarvis.Code.SyS_Counter();

            string CPU = "";
            string RAM = "";
            int CurrentCPU = 0;
            int CurrentRAM = 0;
            long memoryUsed = 0;
            string systemUptimeMessage = "";
            float CPUCount = 0;

            systemUptimeMessage = Info.Uptime();
            lbl_Uptime.Content = systemUptimeMessage;

            Process currentProc = Process.GetCurrentProcess();
            memoryUsed = currentProc.PrivateMemorySize64 / 1024 / 1024;

            CPUCount = Info.CPU_Count();
            CurrentCPU = (int)CPUCount;
            CurrentRAM = Info.RAM_Count();

             CPU = "Counter Defekt -> CPU Belastung: " + Convert.ToString(CurrentCPU) + "%";
             RAM = "RAM verfügbar: " + Convert.ToString(CurrentRAM) + "MB";

            lbl_CPU.Content = CPU;
            lbl_Ram.Content = RAM;
            lbl_JavisRam.Content = "Jarvis nutzt " + Convert.ToString(memoryUsed) + " MB RAM";
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

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            //Button: Einstellungen
            Jarvis.Settings.WindowSettings window = new Jarvis.Settings.WindowSettings();
            window.Show();

        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            //Button: Login
            Jarvis.AdminRoom Admin = new Jarvis.AdminRoom();
            Admin.Show();
        }
        #endregion
    }

}

