using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using HorseTrackingMobile.Droid.Renderers;

[assembly: ExportRenderer(typeof(Entry), typeof(CustomEntry), new[] { typeof(VisualMarker.DefaultVisual) })]

namespace HorseTrackingMobile.Droid.Renderers
{
        public class CustomEntry : EntryRenderer
        {
            public CustomEntry(Context context) : base(context) { }

            protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
            {
                base.OnElementChanged(e);

                if (Control != null)
                {
                    Control.Background = null;
                    Control.SetBackgroundColor(Android.Graphics.Color.Transparent);
                }
            }
        }
    
}