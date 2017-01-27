using System;
using System.Windows.Media;
using System.Windows.Threading;
using Prism.Mvvm;


namespace SuperYahtzee.Controls.ControlsViewModels
{
    public class PiceUCViewModel : BindableBase
    {
        private int _value = 3;

        private Brush _bgColor = new SolidColorBrush() {Color=Colors.CadetBlue};

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



        public void StartRandom()
        {
            var currentBgColor = BgColor;
            var rnd = new Random(DateTime.Now.Millisecond);
            int ticks = rnd.Next(10, 20);
            BgColor = new SolidColorBrush() { Color = Colors.DarkOrange };
            var timer = new DispatcherTimer();
            timer.Tick += delegate
            {
                Value = rnd.Next(1, 7);
                ticks--;
                if (ticks <= 0)
                {
                    timer.Stop();
                    BgColor = currentBgColor;
                }
            };
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Start();

        }
    }
}
