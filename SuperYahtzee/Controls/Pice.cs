
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;


namespace SuperYahtzee.Controls
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:SuperYahtzee.Controls"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:SuperYahtzee.Controls;assembly=SuperYahtzee.Controls"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:Pice/>
    ///
    /// </summary>
    [TemplatePart(Name = "Main", Type = typeof(Border))]
    [TemplatePart(Name = "body", Type = typeof(ContentControl))]
    public class Pice : Control
    {
        static Pice()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Pice), new FrameworkPropertyMetadata(typeof(Pice)));
            CommandManager.RegisterClassCommandBinding(typeof(Pice), new CommandBinding(Pice.CustomCommand, C_Command));
            EventManager.RegisterClassHandler(typeof(Pice), Mouse.MouseDownEvent, new MouseButtonEventHandler(M_Down));
        }

        public static readonly DependencyProperty CPrt = DependencyProperty.Register("Color", typeof(Color), typeof(Pice), new PropertyMetadata(Colors.AliceBlue));

        public static readonly DependencyProperty RPrt = DependencyProperty.Register("Radius", typeof(Double), typeof(Pice), new PropertyMetadata(5.0));

        public Color Color
        {
            get
            {
                return (Color)GetValue(CPrt);
            }
            set
            {
                SetValue(CPrt, value);
            }
        }

        public Double Radius
        {
            get
            {
                return (Double)GetValue(RPrt);
            }
            set
            {
                SetValue(RPrt, value);
            }
        }

        Border _mb;
        ContentControl _body;

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            if (Template != null)
            {
                var mainBorder = Template.FindName("Main", this) as Border;
                if (mainBorder != _mb)
                {
                    //Firstly you have to unhook existing handler
                    if (_mb != null)
                    {
                        _mb.MouseEnter -= new MouseEventHandler(MB_MEnter);
                        _mb.MouseLeave -= new MouseEventHandler(MB_MLeave);
                    }
                    _mb = mainBorder;
                    if (_mb != null)
                    {
                        // Now we have to Add a default basecolor
                        _mb.Background = new SolidColorBrush(Color);
                        _mb.BorderBrush=new LinearGradientBrush(Colors.Black,Colors.Aqua,0);
                        _mb.Margin = new Thickness(4);
                        _mb.CornerRadius = new CornerRadius(Radius);
                        _mb.MouseEnter += new MouseEventHandler(MB_MEnter);
                        _mb.MouseLeave += new MouseEventHandler(MB_MLeave);
                    }
                }
                //_body = Template.FindName("body", this) as ContentControl;
            }
        }

        void MB_MLeave(object sender, MouseEventArgs e)
        {
            Border thisBorder = sender as Border;
            if (thisBorder != null)
            {
                thisBorder.Background = new SolidColorBrush(Colors.HotPink);
                if (_body != null)
                {
                    Run r = new Run("Mouse Has Been Left!");
                    r.Foreground = new SolidColorBrush(Colors.Yellow);
                    _body.Content = r;
                }
            }
        }

        void MB_MEnter(object sender, MouseEventArgs e)
        {
            Border thisBorder = sender as Border;
            if (thisBorder != null)
            {
                thisBorder.Background = new SolidColorBrush(Colors.Tomato);
                if (_body != null)
                {
                    Run r = new Run("Mouse Has Entered!");
                    r.Foreground = new SolidColorBrush(Colors.Silver);
                    _body.Content = r;
                }
            }
        }
        static void M_Down(object sender, MouseButtonEventArgs e)
        {
            Pice invoker = sender as Pice;
            //Do handle event
            //Raise your event
            invoker?.OnInvertCall();
            //Do Rest
        }

        public static readonly RoutedEvent InvertCallEvent = EventManager.RegisterRoutedEvent("InvertCall", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Pice));
        public event RoutedEventHandler InvertCall
        {
            add { AddHandler(InvertCallEvent, value); }
            remove { RemoveHandler(InvertCallEvent, value); }
        }
        private void OnInvertCall()
        {
            RoutedEventArgs args = new RoutedEventArgs(InvertCallEvent);
            RaiseEvent(args);
        }
        static void C_Command(object sender, ExecutedRoutedEventArgs e)
        {
            //Need to first retrieve the control
            Pice invoker = sender as Pice;
            //Do whatever you need
        }
        public static readonly ICommand CustomCommand = new RoutedUICommand("CustomCommand", "CustomCommand", typeof(Pice), new InputGestureCollection(new InputGesture[] { new KeyGesture(Key.Enter), new MouseGesture(MouseAction.LeftClick) }));
    }


}
