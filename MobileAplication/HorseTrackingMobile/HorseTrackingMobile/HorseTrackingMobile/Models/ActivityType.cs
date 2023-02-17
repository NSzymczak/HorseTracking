using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace HorseTrackingMobile.Models
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
            Ride = new ActivityType(0, "Jazda", Color.FromHex("#FBDE15"), "riding_icon.svg");
            Walk = new ActivityType(1, "Spacer", Color.FromHex("#404E4D"), "walk_icon.svg");
            Jump = new ActivityType(2, "Skoki", Color.FromHex("#FF9D2B"), "jumping_icon.svg");
            Lounge = new ActivityType(3, "Lonża", Color.FromHex("#A02323"), "lounge_icon.svg");
            HorsebackRiding = new ActivityType(4, "Teren", Color.FromHex("#228B22"), "horseback_riding_icon.svg");
            Carousel = new ActivityType(5, "Karuzela", Color.FromHex("#3C8279"), "carusele_icon.svg");
            Grass = new ActivityType(6, "Padok", Color.FromHex("#9BC53D"), "grass_icon.svg");
            Competition = new ActivityType(7, "Zawody",Color.FromHex("#61304B"), "competition_icon.svg");
            Cross = new ActivityType(8, "Kros", Color.FromHex("#C3423F"), "cross_icon.svg");
            Dressage = new ActivityType(9, "Ujeżdżenie", Color.FromHex("#8B4513"), "dressage_icon.svg");
            FreeJump = new ActivityType(10, "Skoki luzem", Color.FromHex("#FFC736"), "free_jump_icon.svg");

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
