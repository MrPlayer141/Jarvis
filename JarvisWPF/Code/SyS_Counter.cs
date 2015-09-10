using System.Diagnostics;
using System.Threading;
using System;

namespace Jarvis.Code
{
    public class SyS_Counter
    {
        // Make it Async


        #region Count

        public int CPU_Count()
        {
            
            PerformanceCounter perfCpuCount = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");
           perfCpuCount.NextValue();
            int currentCpuPercentage = 0;
            currentCpuPercentage = (int)perfCpuCount.NextValue();
            return currentCpuPercentage;
        }

        public int RAM_Count()
        {
            PerformanceCounter perfMemCount = new PerformanceCounter("Memory", "Available MBytes");
            perfMemCount.NextValue();
            int currentAvailableMemory = (int)perfMemCount.NextValue();
            return currentAvailableMemory;
        }
        public string Uptime()
        {
            string Uptime;
            Uptime = "";
            PerformanceCounter perfUptimeCount = new PerformanceCounter("System", "System Up Time");
            perfUptimeCount.NextValue();
            TimeSpan uptimeSpan = TimeSpan.FromSeconds(perfUptimeCount.NextValue());

            string systemUptimeMessage = string.Format("Der Computer ist online seit {0} Tagen {1} Stunden {2} Minuten",
                (int)uptimeSpan.TotalDays,
                (int)uptimeSpan.Hours,
                (int)uptimeSpan.Minutes
                );
            
            return Uptime = systemUptimeMessage;

        }

        #endregion

    }
}
