using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Threading;

namespace SickLidar
{
    /// <summary>
    /// High-Performance Timer in C#
    /// http://www.codeproject.com/Articles/2635/High-Performance-Timer-in-C
    /// </summary>
    public class HiPerfTimer
    {
        #region fields

        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceCounter(
            out long lpPerformanceCount);

        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceFrequency(
            out long lpFrequency);

        [DllImport("kernel32.dll")]
        private static extern uint GetTickCount();

        public long startTime;
        public long stopTime;
        public long freq;

        #endregion

        #region constructor
        
        /// <summary>
        /// basic constructor
        /// </summary>
        public HiPerfTimer() 
        {
            startTime = 0;
            stopTime = 0;

            if (QueryPerformanceFrequency(out freq) == false)
            {
                // high-performance counter not supported
                throw new Win32Exception();
            }
        }
        
        #endregion

        #region Method

        // Start the timer
        public void Start()
        {
            // lets do the waiting threads there work
            Thread.Sleep(0);

            QueryPerformanceCounter(out startTime);
        }

        // Stop the timer
        public void Stop()
        {
            QueryPerformanceCounter(out stopTime);
        }

        // Returns the duration of the timer (in milliseconds)
        public double Duration
        {
            get
            {
                return (double)(stopTime - startTime) / (double)freq * (double)1000.0;
            }
        }

        /// <summary>
        /// Get tick count
        /// </summary>
        /// <returns></returns>
        public uint TotalTickCount()
        {
            return GetTickCount();
        }

        #endregion

    }
}
