using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using Prism.Mvvm;


namespace SuperYahtzee.Controls.ControlsViewModels
{
    internal class PiceUCViewModel : BindableBase
    {
        private int _value = 3;

        private Brush _bgColor = new SolidColorBrush() {Color=Colors.CadetBlue};


        private double _angle;

        public double Angle
        {
            get { return _angle; }
            set { SetProperty(ref _angle, value); }
        }

        private bool _visible;
        public bool Visible
        {
            get { return _visible; }
            set { SetProperty(ref _visible, value); }
        }

        public Brush BgColor
        {
            get { return _bgColor; }
            set
            {
                SetProperty(ref _bgColor, value);
            }
        }

        public int Value
        {
            get { return _value; }
            set
            {
                SetProperty(ref _value, value);
            }
        }

        public PiceUCViewModel()
        {
            Angle = 0;
            Visible = true;
        }

        public void StartRandom()
        {
            var currentBgColor = BgColor;
            var rnd = new Random(DateTime.Now.Millisecond);
            int ticks = rnd.Next(10, 20);
            BgColor = new SolidColorBrush() { Color = Colors.DarkOrange };
            var timer = new DispatcherTimer();
            double angelOffset = 360 / ticks;
            timer.Tick += delegate
            {
                Value = rnd.Next(1, 7);
                Angle += angelOffset;
                ticks--;
                if (ticks <= 0)
                {
                    timer.Stop();
                    Angle = 0;
                    BgColor = currentBgColor;
                }
            };
            
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Start();

        }
    }
}
