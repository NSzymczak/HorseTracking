using Microsoft.VisualBasic;

namespace HorseDesktopLib.Users
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Hash { get; set; }
        public string Salt { get; set; }

        public PeopleDetails Details { get; set; }
        public UserType Type { get; set; }

        public DateAndTime CreatedDateTime { get; set; }


        public static User CurrentUser { get; set; }
    }
}
