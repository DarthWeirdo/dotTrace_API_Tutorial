using System;
using System.Windows;
using System.Windows.Threading;

namespace GameOfLife
{
    public partial class MainWindow
    {
        private readonly Grid _mainGrid;
        private readonly DispatcherTimer _timer;   
        private int _genCounter;        

        public MainWindow()
        {
            InitializeComponent();
            _mainGrid = new Grid(MainCanvas);

            _timer = new DispatcherTimer();
            _timer.Tick += OnTimer;
            _timer.Interval = TimeSpan.FromMilliseconds(200);
        }        


        private void Button_OnClick(object sender, EventArgs e)
        {
            if (!_timer.IsEnabled)
            {
                _timer.Start();
                ButtonStart.Content = "Stop";                
            }
            else
            {
                _timer.Stop();
                ButtonStart.Content = "Start";
            }
        }

        private void OnTimer(object sender, EventArgs e)
        {
            _mainGrid.Update();
            _genCounter++;
            lblGenCount.Content = "Generations: " + _genCounter;
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            _mainGrid.Clear();
        }
    }
}
