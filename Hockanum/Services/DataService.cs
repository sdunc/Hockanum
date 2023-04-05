using System;
using System.Timers;

namespace Hockanum.Services
{
    public class DataService
    {
        private readonly Timer timer;
        private DateTime lastTimestamp;
        public TimeSpan RefreshPeriod { get; private set; }
        public event EventHandler? NewData;

        private volatile object locker = new(); // even DateTime access is not atomic

        public DataService()
        {
            timer = new System.Timers.Timer
            { 
                Interval = 1000 
            };
            timer.Elapsed += Timer_Elapsed;
            timer.Start();

            lastTimestamp = DateTime.Now;
        }

        private void Timer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            try
            {
                timer.Stop();
                RefreshPeriod = DateTime.Now - lastTimestamp;
                lastTimestamp = DateTime.Now;
                NewData?.Invoke(this, EventArgs.Empty);
            }
            finally
            {
                timer.Start();
            }
        }
    }
}
