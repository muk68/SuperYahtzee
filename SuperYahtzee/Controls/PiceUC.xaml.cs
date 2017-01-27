
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Microsoft.Practices.Unity;
using SuperYahtzee.Controls.ControlsViewModels;

namespace SuperYahtzee.Controls
{
    /// <summary>
    /// Interaction logic for PiceUC.xaml
    /// </summary>
    public partial class PiceUC : UserControl
    {
        public PiceUC()
        {
            InitializeComponent();
        }

        

        [Dependency]
        internal PiceUCViewModel ViewModel
        {
            get { return DataContext as PiceUCViewModel; }
            set
            {
                DataContext = value;
                if (value != null)
                {
                    var binding = new Binding(nameof(value.Value))
                    {
                        Mode = BindingMode.TwoWay,
                        UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
                    };
                    SetBinding(NumberProperty, binding);
                }
            }
        }

        //private int _nummer=0;
        public int Number
        {
            get
            {
                return (int)GetValue(NumberProperty);
            }
            set
            {
                SetValue(NumberProperty, value);
            }
        }

        // Dependency Property
        public static readonly DependencyProperty NumberProperty =
        DependencyProperty.Register("Number", typeof(int), typeof(PiceUC),
        new PropertyMetadata(0));
    }
}
