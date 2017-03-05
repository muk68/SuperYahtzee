using System.Windows.Media;

using Prism.Mvvm;
using Brush = System.Drawing;

namespace SuperYahtzee.Controls.ControlsViewModels
{
    class DragPreviewPiceViewModel:BindableBase
    {
        private int _value = 3;

        private System.Windows.Media.Brush  _bgColor = new SolidColorBrush() { Color = Colors.AntiqueWhite };

        public System.Windows.Media.Brush BgColor
        {
            get { return _bgColor; }
            set
            {
                SetProperty(ref _bgColor, value);
            }
        }


        public int Value
        {
            get { return _value; }
            set
            {
                SetProperty(ref _value, value);
            }
        }
    }
}
