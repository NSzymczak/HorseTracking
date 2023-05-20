using HorseTrackingMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HorseTrackingMobile.Services.Database.UserServices
{
    public interface IUserService
    {
        User GetLoggedUser();
        List<User> GetAllUsers();
        List<User> GetUser(string login, string password);
    }
}
