using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using System.Threading;
using System.Speech.Synthesis;

namespace Jarvis.BasicModule
{
    class CPU_RAM_HDD_Info
    {
        #region Logic

        public void CPUandRam()
            {
            int speechSpeed = 1;
            JarvisSpeak("Starte Jarvis CPU und Arbeitspeicher Counter.", VoiceGender.Male, speechSpeed);

            Jarvis.Code.SyS_Counter info = new Code.SyS_Counter();
            int currentCpuPercentage = info.CPU_Count();
            int currentAvailableMemory = info.RAM_Count();

            Process currentProc = Process.GetCurrentProcess();
            long memoryUsed = currentProc.PrivateMemorySize64 / 1024 / 1024;

            List<string> cpuMaxedOutMessages = new List<string>();
            cpuMaxedOutMessages.Add("ACHTUNG: Die CPU jagt official Eichhörnchen!");
            cpuMaxedOutMessages.Add("ALARM! ALARM! ALARM! ALARM! Ich bin überlastet!");
            cpuMaxedOutMessages.Add("ACHTUNG: Ich gehe gleich in Flammen auf!");
            cpuMaxedOutMessages.Add("Scheinbar wilst du ein Lagerfeuer in deinen Zimmer machen so wie du mich überlastest");
            cpuMaxedOutMessages.Add("Achtung ich bin überlastet stoppe den download deiner Pornos");
            Random rand = new Random();


            if (currentCpuPercentage > 80 )
            {
                if (currentCpuPercentage == 100)
                {
                    string cpuLoadVocalMessage = cpuMaxedOutMessages[rand.Next(5)];
                    JarvisSpeak(cpuLoadVocalMessage, VoiceGender.Male, speechSpeed);
                }
            }

            else
            {
                string cpuLoadVocalMessage = String.Format("Die CPU ist zu {0} Prozent belastet", currentCpuPercentage);
                JarvisSpeak(cpuLoadVocalMessage, VoiceGender.Male, speechSpeed);
            }


            if (currentAvailableMemory > 1024)
        {
                
            string memAvailableVocalMessage = String.Format("Du hast {0} Megabeit vom Arbeitsspeicher verfügbar. Von deinen Verbrauchten Arbeitsspeicher nutzt Jarvis {1} Megabeit",
                currentAvailableMemory,
                memoryUsed
                );
            JarvisSpeak(memAvailableVocalMessage, VoiceGender.Male, 1);
        }
        else
        {
            JarvisSpeak("Achtung du hast kaum noch Arbeitsspeicher.", VoiceGender.Male, speechSpeed);
        }
            
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
    }
}

