using System;
using System.Windows.Media;
using System.Windows.Threading;
using Prism.Events;
using Prism.Interactivity.DefaultPopupWindows;
using Prism.Mvvm;
using SuperYahtzee.Common;

namespace SuperYahtzee.Controls.ControlsViewModels
{
    internal class PicesViewModel : BindableBase
    {
        private readonly IEventAggregator _aggregator;
        public PiceUCViewModel PiceUcW1 { get; private set; }
        public PiceUCViewModel PiceUcW2 { get; private set; }
        public PiceUCViewModel PiceUcW3 { get; private set; }
        public PiceUCViewModel PiceUcW4 { get; private set; }
        public PiceUCViewModel PiceUcW5 { get; private set; }

        public PiceUCViewModel PiceUcS1 { get; private set; }
        public PiceUCViewModel PiceUcS2 { get; private set; }
        public PiceUCViewModel PiceUcS3 { get; private set; }
        public PiceUCViewModel PiceUcS4 { get; private set; }
        public PiceUCViewModel PiceUcS5 { get; private set; }

        public bool IsRunningRandomizer { get; private set; }

        bool[] isEnd = { true, true, true, true, true };

        private double _angle;

        public double Angle
        {
            get { return _angle; }
            set { SetProperty(ref _angle, value); }
        }

        public PicesViewModel(IEventAggregator aggregator)
        {
            _aggregator = aggregator;
            IsRunningRandomizer = false;
            var valueBrush = new SolidColorBrush(Colors.AntiqueWhite) { Opacity = 50 };
            var rnd = new Random(DateTime.Now.Millisecond);

            PiceUcW1 = new PiceUCViewModel(aggregator) { Value = rnd.Next(1, 7) };
            PiceUcW2 = new PiceUCViewModel(aggregator) { Value = rnd.Next(1, 7) };
            PiceUcW3 = new PiceUCViewModel(aggregator) { Value = rnd.Next(1, 7) };
            PiceUcW4 = new PiceUCViewModel(aggregator) { Value = rnd.Next(1, 7) };
            PiceUcW5 = new PiceUCViewModel(aggregator) { Value = rnd.Next(1, 7) };

            PiceUcS1 = new PiceUCViewModel(aggregator) { Value = 0, BgColor = valueBrush };
            PiceUcS2 = new PiceUCViewModel(aggregator) { Value = 0, BgColor = valueBrush };
            PiceUcS3 = new PiceUCViewModel(aggregator) { Value = 0, BgColor = valueBrush };
            PiceUcS4 = new PiceUCViewModel(aggregator) { Value = 0, BgColor = valueBrush };
            PiceUcS5 = new PiceUCViewModel(aggregator) { Value = 0, BgColor = valueBrush };
        }

        public void StartRandom()
        {
            IsRunningRandomizer = true;
            var rnd = new Random(DateTime.Now.Millisecond);
            bool[] isStart = { false, false, false, false, false };
            isEnd[0] = isEnd[1] = isEnd[2] = isEnd[3] = isEnd[4] = false;
            _aggregator.GetEvent<IsRunningRandomizerEvent>().Subscribe(IsRunningRandomizerEventHandler, ThreadOption.PublisherThread, false);
            while (!isStart[0] || !isStart[1] || !isStart[2] || !isStart[3] || !isStart[4])
            {
                int next = rnd.Next(0, 5);
                switch (next)
                {
                    case 0:
                        if (isStart[0]) continue;
                        PiceUcW1.StartRandom(rnd.Next(100, 20000000));
                        isStart[0] = true;
                        break;
                    case 1:
                        if (isStart[1]) continue;
                        PiceUcW2.StartRandom(rnd.Next(100, 20000000));
                        isStart[1] = true;
                        break;
                    case 2:
                        if (isStart[2]) continue;
                        PiceUcW3.StartRandom(rnd.Next(100, 20000000));
                        isStart[2] = true;
                        break;
                    case 3:
                        if (isStart[3]) continue;
                        PiceUcW4.StartRandom(rnd.Next(100, 20000000));
                        isStart[3] = true;
                        break;
                    case 4:
                        if (isStart[4]) continue;
                        PiceUcW5.StartRandom(rnd.Next(100, 20000000));
                        isStart[4] = true;
                        break;
                }
            }
        }


        private void IsRunningRandomizerEventHandler(IsRunningRandomizerEventArgs obj)
        {
            if (obj.Sender == PiceUcW1 && !obj.IsRunningRandomizer) isEnd[0] = true;
            if (obj.Sender == PiceUcW2 && !obj.IsRunningRandomizer) isEnd[1] = true;
            if (obj.Sender == PiceUcW3 && !obj.IsRunningRandomizer) isEnd[2] = true;
            if (obj.Sender == PiceUcW4 && !obj.IsRunningRandomizer) isEnd[3] = true;
            if (obj.Sender == PiceUcW5 && !obj.IsRunningRandomizer) isEnd[4] = true;
            if (isEnd[0] & isEnd[1] & isEnd[2] & isEnd[3] & isEnd[4])
            {
                _aggregator.GetEvent<IsRunningRandomizerEvent>().Unsubscribe(IsRunningRandomizerEventHandler);
                IsRunningRandomizer = false;
                _aggregator.GetEvent<IsRunningRandomizerEvent>().Publish(new IsRunningRandomizerEventArgs(this, IsRunningRandomizer));

            }
        }

    }
}