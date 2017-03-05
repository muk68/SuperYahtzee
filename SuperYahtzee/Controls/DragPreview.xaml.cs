using System.Windows;
using DragDrop;

namespace SuperYahtzee.Controls
{
    /// <summary>
    /// Interaction logic for DragPreview.xaml
    /// </summary>
    public partial class DragPreview : DragDropPreviewBase
    {
        public DragPreview()
        {
            InitializeComponent();                        
        }

        public override void StateChangedHandler(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var self = (DragPreview)d;

            //Do custom code-behind things here
            switch ((DropState)e.NewValue)
            {
                case DropState.CanDrop:
                    
                    break;
                case DropState.CannotDrop:
                   
                    break;
            }
        }
    }
}
