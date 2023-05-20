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
    public class UserService : IUserService
    {
        IConnectionService _connectionService;
        public UserService(IConnectionService connectionServices)
        {
            _connectionService = connectionServices;
        }

        public User GetUser(string login, string password)
        {
            var query = $"SELECT * FROM UserAcount WHERE acountLogin='{login}' AND hash='{password}'";

            var cmd = new SqlCommand(query, _connectionService.GetConnection());
            var reader = cmd.ExecuteReader();

            List<User> userList = new List<User>();
            while (reader.Read())
            {
                return new User()
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
                };
            }
            return null;
        }

        public User GetLoggedUser(int id)
        {
            var query = $"SELECT * FROM UserAcount WHERE userID={id}";

            var cmd = new SqlCommand(query, _connectionService.GetConnection());
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                return new User()
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
                };
            }
            return null;
        }

        public List<User> GetTrainers()
        {
            var query = $"Select * from UserAcount where userTypeID = 4";

            var cmd = new SqlCommand(query, _connectionService.GetConnection());
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

            var cmd = new SqlCommand(query, _connectionService.GetConnection());
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
    }
}
