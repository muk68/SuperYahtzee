using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using Microsoft.Practices.Unity;
using SuperYahtzee.Controls.ControlsViewModels;

namespace SuperYahtzee.Controls
{
    /// <summary>
    /// Interaction logic for Pices.xaml
    /// </summary>
    public partial class Pices : UserControl
    {
        public Pices()
        {
            InitializeComponent();
        }

        [Dependency]
        internal PicesViewModel ViewModel
        {
            set { DataContext = value; }
            get { return DataContext as PicesViewModel; }
        }
    }
}
