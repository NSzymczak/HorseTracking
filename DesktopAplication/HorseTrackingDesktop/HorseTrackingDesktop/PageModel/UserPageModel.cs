using HorseTrackingDesktop.Models;
using HorseTrackingDesktop.Services.Database.UserService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseTrackingDesktop.PageModel
{
    public class UserPageModel
    {
        private readonly IUserServices _userServices;
        public List<UserAcounts> Users { get; set; }

        public UserPageModel(IUserServices userServices) 
        { 
            _userServices= userServices;
            Users = userServices.GetAllUsers().Result;
        }
    }
}
