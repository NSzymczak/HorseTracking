using HorseTrackingDesktop.Models;
using HorseTrackingDesktop.Services.Database.UserService;
using System.Collections.Generic;

namespace HorseTrackingDesktop.PageModel
{
    public class UserPageModel
    {
        private readonly IUserServices _userServices;
        public List<UserAcounts> Users { get; set; }

        public UserPageModel(IUserServices userServices)
        {
            _userServices = userServices;
            Users = userServices.GetAllUsers().Result;
        }
    }
}