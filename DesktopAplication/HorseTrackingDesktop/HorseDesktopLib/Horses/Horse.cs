using HorseDesktopLib.Users;
using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace HorseDesktopLib.Horses
{
    public class Horse
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public User User { get; set; }
        public string Mother { get; set; }
        public string Father { get; set; }
        public DateTime Birthday { get; set; }
        public string Race { get; set; }
        public string Breeder { get; set; }
        public string Passport { get; set; }
        public Image Photo { get; set; }
        public HorseStatus Status { get; set; }
        public static Horse CurrentHorse { get; set; }
        public static ObservableCollection<Horse> UserHorses { get; set; } = new();

    }
}
