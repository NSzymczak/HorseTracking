using System.Windows;

namespace HorseTrackingDesktop.Services
{
    public class DataContextProxy : Freezable
    {
        protected override Freezable CreateInstanceCore()
        {
            return new DataContextProxy();
        }

        public object DataContext
        {
            get => GetValue(DataContextProperty);
            set => SetValue(DataContextProperty, value);
        }

        public static readonly DependencyProperty DataContextProperty =
            DependencyProperty.Register(
                "DataContext",
                typeof(object),
                typeof(DataContextProxy),
                new UIPropertyMetadata(null));
    }
}