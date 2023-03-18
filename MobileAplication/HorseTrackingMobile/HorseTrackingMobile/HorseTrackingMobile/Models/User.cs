using System;
using System.Collections.Generic;
using System.Text;

namespace HorseTrackingMobile.Models
{
    public class User
    {
        public int Id { get; set; }
        public UserType Type { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public PeopleDetails Details { get; set; }

        public static User CurrentUser { get; set; }


    }
}
