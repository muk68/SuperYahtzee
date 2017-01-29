

using Prism.Commands;
using Prism.Mvvm;
using SuperYahtzee.Controls.ControlsViewModels;

namespace SuperYahtzee.ViewModels
{

    internal class MainWindowViewModel : BindableBase
    {
        public DelegateCommand<object> StartStopCommand { get; }
        
        public PiceUCViewModel PiceUC { get; private set; }
        /// <summary>
        /// Initializes a new instance of the MainWindowViewModel class.
        /// </summary>
        public MainWindowViewModel(PiceUCViewModel piceUc)
        {
            PiceUC = piceUc;
            StartStopCommand = new DelegateCommand<object>(StartStop);
            //_piceUC = new PiceUCViewModel();
            PiceUC.Value = 4;
        }

        #region Commands
        private void StartStop(object arg)
        {
            //var rnd = new Random(DateTime.Now.Millisecond);
            ////  Add a message.
            //PiceUC.Number = 2;
            //for (int i = 0; i < 10; i++)
            //{
            //    PiceUC.Number=rnd.Next(1, 6);
            //    Thread.Sleep(200);
            //}
            //PiceUC.Number=1;
            PiceUC.StartRandom();
            //PiceUC.Value = 1;
        }
        #endregion


    }
}