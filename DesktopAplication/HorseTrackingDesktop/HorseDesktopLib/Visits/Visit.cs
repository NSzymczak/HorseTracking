using HorseDesktopLib.Horses;

namespace HorseDesktopLib.Visits
{
    public class Visit
    {
        public int ID { get; set; }
        public float Price { get; set; }
        public Horse Horse { get; set; }
        public Doctor Doctor { get; set; }
        public string Summary { get; set; }
        public string ArtefactImage { get; set; }

    }
}
