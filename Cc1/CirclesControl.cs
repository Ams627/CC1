using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Cc1
{
    public class CirclesControl : Control
    {
        static CirclesControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CirclesControl), new FrameworkPropertyMetadata(typeof(CirclesControl)));
        }

        public int Num
        {
            get { return (int)GetValue(NumProperty); }
            set { SetValue(NumProperty, value); }
        }

        public static readonly DependencyProperty NumProperty =
            DependencyProperty.Register("Num", typeof(int), typeof(CirclesControl), new PropertyMetadata(2, new PropertyChangedCallback(OnNumChanged)));

        private static void OnNumChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is CirclesControl control)
            {
                System.Diagnostics.Debug.WriteLine($"Num changed - value is now {control.Num}");
                control.ApplyTemplate();
            }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            var canvasPart = Template.FindName("Part_Canvas", this);
            if (canvasPart is Canvas canvas)
            {
                for (int i = 0; i < Num; i++)
                {
                    var circle = new Ellipse
                    {
                        Height = 50,
                        Width = 50,
                        Fill = Brushes.Red,
                        Stroke = Brushes.Green
                    };
                    canvas.Children.Add(circle);
                    Canvas.SetLeft(circle, i * 55);
                    Canvas.SetTop(circle, 50);
                }
            }
        }
    }
}
