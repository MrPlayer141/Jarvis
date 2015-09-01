using System.Diagnostics;


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

        #endregion

    }
}
