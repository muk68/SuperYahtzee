using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using SuperYahtzee.Common;


namespace SuperYahtzee.Controls.ControlsViewModels
{
    public class PiceUCViewModel : BindableBase
    {
        public DelegateCommand<object> MouseDownCommand { get; }

        public DelegateCommand<object> MouseUpCommand { get; }

        public DelegateCommand<object> MouseMoveCommand { get; }

        //private EventHandler _endRunningRandomizer; // the underlying field
        //                                            // this isn't actually named "_MyEvent" but also "MyEvent",
        //                                            // but then you couldn't see the difference between the field
        //                                            // and the event.

        //private readonly WeakEventSource _myEventSource = new WeakEventSource();
        //public event EventHandler EndRunningRandomizer
        //{
        //    add { lock (this) {
        //        if (_endRunningRandomizer != null) _endRunningRandomizer += value;
        //    } }
        //    remove { lock (this) {
        //        if (_endRunningRandomizer != null) _endRunningRandomizer -= value;
        //    } }
        //}

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

        public bool IsRunningRandomizer { get; private set; }

        public int Value
        {
            get { return _value; }
            set
            {
                SetProperty(ref _value, value);
            }
        }

        private readonly IEventAggregator _aggregator;

        public PiceUCViewModel(IEventAggregator aggregator)
        {
            _aggregator = aggregator;
            Angle = 0;
            Visible = true;
            IsRunningRandomizer = false;

            MouseDownCommand = new DelegateCommand<object>(HandleMouseDownCommand);
            MouseUpCommand = new DelegateCommand<object>(HandleMouseUpCommand);
            MouseMoveCommand = new DelegateCommand<object>(HandleMouseMoveCommand);
        }

        public void HandleMouseDownCommand(object arg)
        {
            
        }

        public void HandleMouseUpCommand(object arg)
        {

        }

        private void HandleMouseMoveCommand(object arg)
        {

        }

        public void StartRandom(int seed)
        {
            IsRunningRandomizer = true;
            _aggregator.GetEvent<IsRunningRandomizerEvent>().Publish(new IsRunningRandomizerEventArgs(this,IsRunningRandomizer));
            var currentBgColor = BgColor;
            var rnd = new Random(seed);
            var ticks = rnd.Next(10, 20);
            BgColor = new SolidColorBrush() { Color = Colors.DarkOrange };
            var timer = new DispatcherTimer();
            var angelOffset = (double)360 / ticks;
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
                    IsRunningRandomizer = false;
                    _aggregator.GetEvent<IsRunningRandomizerEvent>().Publish(new IsRunningRandomizerEventArgs(this, IsRunningRandomizer));
                }
            };
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Start();
        }

        public void StartRandom()
        {
            StartRandom(DateTime.Now.Millisecond);

        }
    }
}
