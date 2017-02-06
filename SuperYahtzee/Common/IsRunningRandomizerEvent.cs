
using System;
using Prism.Events;
using SuperYahtzee.Controls.ControlsViewModels;

namespace SuperYahtzee.Common
{
    public sealed class IsRunningRandomizerEvent : PubSubEvent<IsRunningRandomizerEventArgs>
    {
    }

    public sealed class IsRunningRandomizerEventArgs : EventArgs
    {
        public bool IsRunningRandomizer { get; private set; }

        public object Sender { get; private set; }

        public IsRunningRandomizerEventArgs(object sender, bool isRunningRandomizer)
        {
            Sender = sender;
            IsRunningRandomizer = isRunningRandomizer;
        }
    }
}
