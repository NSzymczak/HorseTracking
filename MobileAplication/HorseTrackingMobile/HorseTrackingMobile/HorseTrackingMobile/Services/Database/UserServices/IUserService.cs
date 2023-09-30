using HorseTrackingMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HorseTrackingMobile.Services.Database.UserServices
{
    public interface IUserService
    {
        User GetLoggedUser(int id);

        List<User> GetAllUsers();

        User GetUser(string login, string password);

        List<User> GetTrainers();

        User GetTrainer(int id);

        PeopleDetails GetDetails(int id);

        User GetHorseOwner(string horseID);
    }
}