using System;
using System.Diagnostics;
using System.Timers;
using System.Windows;
using System.Windows.Input;

namespace TheTimerWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Timer _mainTimer = new Timer();
        Timer _secondsTimer = new Timer();

        private void StartTimerButtonClick(object sender, RoutedEventArgs e)
        {
            int min = int.Parse(Mins.Text);
            int sec = int.Parse(Secs.Text);

            var period = new TimeSpan(0, min, sec);

            _mainTimer.Interval = period.TotalMilliseconds;
            _mainTimer.Elapsed += MainTimerElapsed;
            _mainTimer.AutoReset = false;

            _secondsTimer.Interval = 920; //make second's timer a bit shorter cause of precessing delay
            _secondsTimer.Elapsed += SecondsTimerElapsed;

            _mainTimer.Start();
            _secondsTimer.Start();

            Mins.IsEnabled = false;
            Secs.IsEnabled = false;
            StartButton.IsEnabled = false;
            StopButton.IsEnabled = true;
        }

        private void StopTimerButtonClick(object sender, RoutedEventArgs e)
        {
            StopTimer();
        }

        private void SecondsTimerElapsed(object sender, ElapsedEventArgs e)
        {
            MessageBox.Show($"Time is up: {Stopwatch.GetTimestamp()}/{TimeSpan.TicksPerSecond}", "SecondsTimer");
        }

        private void MainTimerElapsed(object sender, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(StopTimer);
            MessageBox.Show($"Time is up: {Stopwatch.GetTimestamp()}/{TimeSpan.TicksPerSecond}", "MainTimer");
        }

        private void StopTimer()
        {
            _secondsTimer.AutoReset = false;
            _secondsTimer.Enabled = false;
            _mainTimer.Enabled = false;

            Mins.IsEnabled = true;
            Secs.IsEnabled = true;

            StartButton.IsEnabled = true;
            StopButton.IsEnabled = false;
        }

        private void PreviewTimeTextboxKeyDown(object sender, KeyEventArgs e)
        {
            //add normal check for digits and for editing key inclusive Tab
            //if (((e.Key >= Key.D0 && e.Key <= Key.D9) || e.Key == Key.Clear || e.Key == Key.Delete) && 
            //    ((TextBox)sender).Text.Length < 2)
            //    return;
            
            //e.Handled = true;
        }
    }
}
