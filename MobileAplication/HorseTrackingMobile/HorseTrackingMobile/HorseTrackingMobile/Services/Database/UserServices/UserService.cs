using HorseTrackingMobile.Models;
using HorseTrackingMobile.Services.Database;
using HorseTrackingMobile.Services.Database.UserServices;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Xamarin.Essentials;

namespace HorseTrackingMobile.Database.UserServices
{
    public class UserService : BaseDataService, IUserService
    {
        public UserService(IConnectionService connectionServices) : base(connectionServices) { }

        public List<User> GetUser(string login, string password)
        {
            var query = $"SELECT * FROM UserAcount WHERE acountLogin='{login}' AND hash='{password}'";

            var cmd = new SqlCommand(query, sqlConnection);
            var reader = cmd.ExecuteReader();

            List<User> userList = new List<User>();
            while (reader.Read())
            {
                userList.Add(new User()
                {
                    Id = Convert.ToInt32(reader["userID"]),
                    Type = new UserType()
                    {
                        ID = Convert.ToInt32(reader["userTypeID"])
                    },
                    Details = new PeopleDetails()
                    {
                        ID = Convert.ToInt32(reader["detailsID"])
                    },
                    Login = reader["acountLogin"].ToString(),
                    Hash = reader["hash"].ToString(),
                    Salt = reader["salt"].ToString(),
                    CreatedDate = (DateTime)reader["createdDate"]
                });
            }
            return userList;
        }

        public List<User> GetAllUsers()
        {
            var query = $"SELECT * FROM UserAcount";

            var cmd = new SqlCommand(query, sqlConnection);
            var reader = cmd.ExecuteReader();

            List<User> userList = new List<User>();
            while (reader.Read())
            {
                userList.Add(new User()
                {
                    Id = Convert.ToInt32(reader["userID"]),
                    Type = new UserType()
                    {
                        ID = Convert.ToInt32(reader["userTypeID"])
                    },
                    Details = new PeopleDetails()
                    {
                        ID = Convert.ToInt32(reader["detailsID"])
                    },
                    Login = reader["acountLogin"].ToString(),
                    Hash = reader["hash"].ToString(),
                    Salt = reader["salt"].ToString(),
                    CreatedDate = (DateTime)reader["createdDate"]
                });
            }
            return userList;
        }
        public User GetLoggedUser()
        {
            var id = Preferences.Get(PreferencesKeys.UserID, 0);
            return GetAllUsers().Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
