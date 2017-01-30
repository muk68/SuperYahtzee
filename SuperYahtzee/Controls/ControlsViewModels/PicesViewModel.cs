using System;
using Prism.Mvvm;

namespace SuperYahtzee.Controls.ControlsViewModels
{
    internal class PicesViewModel : BindableBase
    {

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

        public PicesViewModel()
        {
            var rnd = new Random(DateTime.Now.Millisecond);

            PiceUcW1 = new PiceUCViewModel { Value = rnd.Next(1, 7) };
            PiceUcW2 = new PiceUCViewModel { Value = rnd.Next(1, 7) };
            PiceUcW3 = new PiceUCViewModel { Value = rnd.Next(1, 7) };
            PiceUcW4 = new PiceUCViewModel { Value = rnd.Next(1, 7) };
            PiceUcW5 = new PiceUCViewModel { Value = rnd.Next(1, 7) };

            PiceUcS1 = new PiceUCViewModel { Visible = false };
            PiceUcS2 = new PiceUCViewModel { Visible = false };
            PiceUcS3 = new PiceUCViewModel { Visible = false };
            PiceUcS4 = new PiceUCViewModel { Visible = false };
            PiceUcS5 = new PiceUCViewModel { Visible = false };
        }

    }
}