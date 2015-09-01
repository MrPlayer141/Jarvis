﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using System.Threading;
using System.Speech.Synthesis;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
          int currentCpuPercentage = (int)perfCpuCount.NextValue();
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
