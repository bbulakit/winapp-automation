using System;
using System.Timers;
namespace WinApp.Automation.Timers
{
    public class CommonTimer : IDisposable
    {
        private Timer _timer;
        public delegate void AppMonitorTimerHandler(object sender, ElapsedEventArgs e);
        public event AppMonitorTimerHandler OnAppMonitorTimerElapsed;
        public CommonTimer(double interval)
        {
            _timer = new Timer(interval);
            _timer.Elapsed += Timer_Elapsed;
        }

        public void Start() => _timer.Enabled = true;
        public void Stop() => _timer.Enabled = false;

        public void ForceElapse()
        {
            Stop();
            OnAppMonitorTimerElapsed?.Invoke(this, null);
            Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                _timer.Enabled = false;
                OnAppMonitorTimerElapsed?.Invoke(sender, e);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _timer.Enabled = true;
            }
        }

        public void Dispose()
        {
            _timer.Enabled = false;
            _timer.Dispose();
        }
    }
}
