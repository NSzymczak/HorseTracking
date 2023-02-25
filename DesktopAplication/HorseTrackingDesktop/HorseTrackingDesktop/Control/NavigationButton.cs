using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;

namespace HorseTrackingDesktop.Control
{
    public class NavigationButton: Button
    {
        static NavigationButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NavigationButton), new FrameworkPropertyMetadata(typeof(NavigationButton)));
        }

        public NavigationButton()
        {
            this.Template = (ControlTemplate)Application.Current.Resources["Template"];
        }
        public ImageSource ImageSource
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        public static readonly DependencyProperty ImageSourceProperty = DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(NavigationButton), new PropertyMetadata(null));
        
        public Brush Highlight
        {
            get { return (Brush)GetValue(HighlightProperty); }
            set { SetValue(HighlightProperty, value); }
        }
        public static readonly DependencyProperty HighlightProperty = DependencyProperty.Register("Highlight", typeof(Brush), typeof(NavigationButton), new PropertyMetadata(null));

        public Uri Routing
        {
            get { return (Uri)GetValue(RoutingProperty); }
            set { SetValue(RoutingProperty, value); }
        }
        public static readonly DependencyProperty RoutingProperty = DependencyProperty.Register("Routing", typeof(Uri), typeof(NavigationButton), new PropertyMetadata(null));
    }
}
