using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HorseTrackingDesktop.Models
{
    public class ActivityType
    {
        public ActivityType(int id, string name, Color color)
        {
            ID = id;
            Name = name;
            Color = color;
        }

        public static Dictionary<int, ActivityType> ActivityTypeIdMap = new Dictionary<int, ActivityType>();

        static ActivityType()
        {
            Ride = new ActivityType(0, "Jazda", (Color)ColorConverter.ConvertFromString("#FBDE15"));
            Walk = new ActivityType(1, "Spacer", (Color)ColorConverter.ConvertFromString("#404E4D"));
            Jump = new ActivityType(2, "Skoki", (Color)ColorConverter.ConvertFromString("#FF9D2B"));
            Lounge = new ActivityType(3, "Lonża", (Color)ColorConverter.ConvertFromString("#A02323"));
            HorsebackRiding = new ActivityType(4, "Teren", (Color)ColorConverter.ConvertFromString("#228B22"));
            Carousel = new ActivityType(5, "Karuzela", (Color)ColorConverter.ConvertFromString("#3C8279"));
            Grass = new ActivityType(6, "Padok", (Color)ColorConverter.ConvertFromString("#9BC53D"));
            Competition = new ActivityType(7, "Zawody", (Color)ColorConverter.ConvertFromString("#61304B"));
            Cross = new ActivityType(8, "Kros", (Color)ColorConverter.ConvertFromString("#C3423F"));
            Dressage = new ActivityType(9, "Ujeżdżenie", (Color)ColorConverter.ConvertFromString("#8B4513"));
            FreeJump = new ActivityType(10, "Skoki luzem", (Color)ColorConverter.ConvertFromString("#FFC736"));

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