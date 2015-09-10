﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Speech.Synthesis;
using System.Diagnostics;
using System.Threading;

namespace Jarvis.Code
{
    class Startup
    {
        #region Startup

        bool IDE = Properties.Settings.Default.fastStart;
        SyS_Counter Count = new SyS_Counter();

        public void startup()
        {
            if (IDE == true)
            { }
            else
            {
                Version();
                Uptime();
                Updates();
                Hello();
                bugDisclamer();
                roadmap();
            }
        }

        public void Version()
        {
            string sysVersion = string.Format("Willkommen . Ich lade Jarvis {0} Version {1} Punkt {2} Punkt {3} Punkt {4} Build {5}!",
                (string)"Alpha",
                (int)1,
                (int)0,
                (int)0,
                (int)4,
                (int)1231
                );
            JarvisSpeak(sysVersion, VoiceGender.Male, 1);
        }

        public void Uptime()
        {
            string systemUptimeMessage = Count.Uptime();           
            JarvisSpeak(systemUptimeMessage, VoiceGender.Male, 1);
        }

        public void Updates()
        {
            bool avable = false;
            //JarvisSpeak("Ich überprüfe ob ein Update für Jarvis verfügbar ist", VoiceGender.Male, 1);
            

            if (avable == true)
            {

            }
            else
            {
                //JarvisSpeak("Jarvis ist auf den neusten Stand.", VoiceGender.Male, 1);
                JarvisSpeak("Das Automatische Up-Daten von Jarvis ist in der nächsten Version eingebaut!", VoiceGender.Male, 1);
            }
        }

        public void Hello()
        {
            JarvisSpeak("Wilkommen ich bin Jarvis. Das Laden weitere Informationen ist bald verfügbar, sowie die Unterstützung mehere Sprachen.", VoiceGender.Male, 2);
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
