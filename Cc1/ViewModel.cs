using System;
using System.Windows;
using System.Windows.Threading;

namespace Cc1
{
    public class ViewModel : DependencyObject
    {
        public ViewModel()
        {
            var timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(500)
            };
            timer.Tick += (s, e) =>
            {
                NumberOfCircles++;
                if (NumberOfCircles == 10)
                {
                    NumberOfCircles = 2;
                }
            };
            timer.Start();
        }
        public int NumberOfCircles
        {
            get { return (int)GetValue(NumberOfCirclesProperty); }
            set { SetValue(NumberOfCirclesProperty, value); }
        }

        public static readonly DependencyProperty NumberOfCirclesProperty =
            DependencyProperty.Register("NumberOfCircles", typeof(int), typeof(ViewModel), new PropertyMetadata(4));
    }
}
