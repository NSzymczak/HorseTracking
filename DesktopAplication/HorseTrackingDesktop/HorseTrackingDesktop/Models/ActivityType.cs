using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HorseTrackingDesktop.Models
{
    public class ActivityType
    {
        public ActivityType(int id, string name, Color color, ImageSource image)
        {
            ID = id;
            Name = name;
            Color = color;
            Image = image;
        }

        public static Dictionary<int, ActivityType> ActivityTypeIdMap = new Dictionary<int, ActivityType>();

        static ActivityType()
        {
            Ride = new ActivityType(0, "Jazda", (Color)ColorConverter.ConvertFromString("#FBDE15"), new BitmapImage(new Uri("Riding.png")));
            Walk = new ActivityType(1, "Spacer", (Color)ColorConverter.ConvertFromString("#404E4D"), new BitmapImage(new Uri("Walk.png")));
            Jump = new ActivityType(2, "Skoki", (Color)ColorConverter.ConvertFromString("#FF9D2B"), new BitmapImage(new Uri("Jump.png")));
            Lounge = new ActivityType(3, "Lonża", (Color)ColorConverter.ConvertFromString("#A02323"), new BitmapImage(new Uri("Lounge.png")));
            HorsebackRiding = new ActivityType(4, "Teren", (Color)ColorConverter.ConvertFromString("#228B22"), new BitmapImage(new Uri("Horseback.png")));
            Carousel = new ActivityType(5, "Karuzela", (Color)ColorConverter.ConvertFromString("#3C8279"), new BitmapImage(new Uri("Carusele.png")));
            Grass = new ActivityType(6, "Padok", (Color)ColorConverter.ConvertFromString("#9BC53D"), new BitmapImage(new Uri("Grass.png")));
            Competition = new ActivityType(7, "Zawody", (Color)ColorConverter.ConvertFromString("#61304B"), new BitmapImage(new Uri("Competition.png")));
            Cross = new ActivityType(8, "Kros", (Color)ColorConverter.ConvertFromString("#C3423F"), new BitmapImage(new Uri("Cross.png")));
            Dressage = new ActivityType(9, "Ujeżdżenie", (Color)ColorConverter.ConvertFromString("#8B4513"), new BitmapImage(new Uri("Dressage.png")));
            FreeJump = new ActivityType(10, "Skoki luzem", (Color)ColorConverter.ConvertFromString("#FFC736"), new BitmapImage(new Uri("FreeJump.png")));

            ListOfActivity = new List<ActivityType>
            {
                Ride,
                Walk,
                Jump,
                Lounge,
                HorsebackRiding,
                Carousel,
                Grass,
                Competition,
                Cross,
                Dressage,
                FreeJump
            };

            foreach (var activity in ListOfActivity)
            {
                if (!ActivityTypeIdMap.ContainsKey(activity.ID))
                    ActivityTypeIdMap.Add(activity.ID, activity);
            }
        }

        public static List<ActivityType> ListOfActivity { get; protected set; }
        public int ID { get; }
        public string Name { get; }
        public Color Color { get; set; }
        public ImageSource Image { get; set; }

        public static ActivityType Ride { get; set; }
        public static ActivityType Walk { get; set; }
        public static ActivityType FreeJump { get; set; }
        public static ActivityType Jump { get; set; }
        public static ActivityType Lounge { get; set; }
        public static ActivityType HorsebackRiding { get; set; }
        public static ActivityType Carousel { get; set; }
        public static ActivityType Grass { get; set; }
        public static ActivityType Competition { get; set; }
        public static ActivityType Cross { get; set; }
        public static ActivityType Dressage { get; set; }
    }
}