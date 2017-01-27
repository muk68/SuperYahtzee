using System.Windows;
using System.Windows.Input;
using Microsoft.Practices.Unity;
using Prism.Commands;

namespace SuperYahtzee
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

        [Dependency]
        internal ViewModels.MainWindowViewModel ViewModel
        {
            set { DataContext = value; }
            get { return DataContext as ViewModels.MainWindowViewModel; }
        }


        

        
    }
}
