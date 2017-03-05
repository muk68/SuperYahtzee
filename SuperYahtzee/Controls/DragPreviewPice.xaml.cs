
using System.Windows;
using System.Windows.Data;
using DragDrop;
using Microsoft.Practices.Unity;
using SuperYahtzee.Controls.ControlsViewModels;


namespace SuperYahtzee.Controls
{
    /// <summary>
    /// Interaction logic for DragPreviewPice.xaml
    /// </summary>
    public partial class DragPreviewPice : DragDropPreviewBase
    {
        public DragPreviewPice()
        {
            InitializeComponent();
        }

        public override void StateChangedHandler(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var self = (DragPreviewPice)d;

            //Do custom code-behind things here
            switch ((DropState)e.NewValue)
            {
                case DropState.CanDrop:

                    break;
                case DropState.CannotDrop:

                    break;
            }
        }


        [Dependency]
        internal PiceUCViewModel ViewModel
        {
            get { return DataContext as PiceUCViewModel; }
            set
            {
                DataContext = value;
                //if (value != null)
                //{
                //    var binding = new Binding(nameof(value.Value))
                //    {
                //        Mode = BindingMode.TwoWay,
                //        UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
                //    };
                //    //SetBinding(NumberProperty, binding);
                //}
            }
        }

        //private int _nummer=0;
        //public int Number
        //{
        //    get
        //    {
        //        return (int)GetValue(NumberProperty);
        //    }
        //    set
        //    {
        //        SetValue(NumberProperty, value);
        //    }
        //}

        //// Dependency Property
        //public static readonly DependencyProperty NumberProperty =
        //DependencyProperty.Register("Number", typeof(int), typeof(PiceUC),
        //new PropertyMetadata(0));
    }
}
