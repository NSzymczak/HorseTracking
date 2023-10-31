using HorseTrackingMobile.Models;
using HorseTrackingMobile.Services.AppState;
using HorseTrackingMobile.Services.Database;
using HorseTrackingMobile.Services.Database.UserServices;
using PasswordHashing;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Xamarin.Essentials;

namespace HorseTrackingMobile.Database.UserServices
{
    public class UserService : IUserService
    {
        private readonly IConnectionService _connectionService;
        private readonly IAppState _appState;

        public UserService(IConnectionService connectionServices, IAppState appState)
        {
            _connectionService = connectionServices;
            _appState = appState;
            _appState.ListOfTrainer = GetTrainers();
        }

        public User GetHorseOwner(string horseID)
        {
            var query = $"SELECT * FROM Horses as h inner join UserAcounts as u " +
                        $"on h.userID = u.userID Where horseID='{horseID}'";

            var cmd = new SqlCommand(query, _connectionService.GetConnection());
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                return new User()
                {
                    Id = Convert.ToInt32(reader["userID"]),
                    Type = GetUserType(Convert.ToInt32(reader["typeID"])),
                    Details = GetDetails(Convert.ToInt32(reader["detailID"])),
                    CreatedDate = (DateTime)reader["createdDateTime"]
                };
            }
            return null;
        }

        public User GetUser(string login)
        {
            var query = $"SELECT * FROM UserAcounts WHERE login='{login}'";

            var cmd = new SqlCommand(query, _connectionService.GetConnection());
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                return new User()
                {
                    Id = Convert.ToInt32(reader["userID"]),
                    Type = GetUserType(Convert.ToInt32(reader["typeID"])),
                    Details = GetDetails(Convert.ToInt32(reader["detailID"])),
                    Login = reader["login"].ToString(),
                    Hash = reader["hash"].ToString(),
                    CreatedDate = (DateTime)reader["createdDateTime"]
                };
            }
            return null;
        }

        public User GetUser(string login, string password)
        {
            var query = $"SELECT * FROM UserAcounts WHERE login='{login}' AND hash='{password}'";

            var cmd = new SqlCommand(query, _connectionService.GetConnection());
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                return new User()
                {
                    Id = Convert.ToInt32(reader["userID"]),
                    Type = GetUserType(Convert.ToInt32(reader["typeID"])),
                    Details = GetDetails(Convert.ToInt32(reader["detailID"])),
                    Login = reader["login"].ToString(),
                    Hash = reader["hash"].ToString(),
                    CreatedDate = (DateTime)reader["createdDateTime"]
                };
            }
            return null;
        }

        public User GetUser(int id)
        {
            var query = $"SELECT * FROM UserAcounts WHERE userID='{id}'";

            var cmd = new SqlCommand(query, _connectionService.GetConnection());
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                return new User()
                {
                    Id = Convert.ToInt32(reader["userID"]),
                    Login = reader["login"].ToString(),
                    Hash = reader["hash"].ToString()
                };
            }
            return null;
        }

        public User GetLoggedUser(int id)
        {
            try
            {
                var query = $"SELECT * FROM UserAcounts WHERE userID={id}";

                var cmd = new SqlCommand(query, _connectionService.GetConnection());
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    return new User()
                    {
                        Id = Convert.ToInt32(reader["userID"]),
                        Type = GetUserType(Convert.ToInt32(reader["typeID"])),
                        Details = GetDetails(Convert.ToInt32(reader["detailID"])),
                        Login = reader["login"].ToString(),
                        Hash = reader["hash"].ToString(),
                        CreatedDate = (DateTime)reader["createdDateTime"]
                    };
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public List<User> GetTrainers()
        {
            try
            {
                var query = $"Select * from UserAcounts where typeID = 4";

                var cmd = new SqlCommand(query, _connectionService.GetConnection());
                var reader = cmd.ExecuteReader();

                List<User> userList = new List<User>();
                while (reader.Read())
                {
                    userList.Add(new User()
                    {
                        Id = Convert.ToInt32(reader["userID"]),
                        Type = GetUserType(Convert.ToInt32(reader["typeID"])),
                        Details = GetDetails(Convert.ToInt32(reader["detailID"])),
                        Login = reader["login"].ToString(),
                        Hash = reader["hash"].ToString(),
                        Salt = reader["salt"].ToString(),
                        CreatedDate = (DateTime)reader["createdDateTime"]
                    });
                }
                return userList;
            }
            catch (Exception ex)
            {
                return new List<User> { };
            }
        }

        public User GetTrainer(int id)
        {
            var query = $"Select * from UserAcounts where userID={id}";

            var cmd = new SqlCommand(query, _connectionService.GetConnection());
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                return new User()
                {
                    Id = Convert.ToInt32(reader["userID"]),
                    Type = GetUserType(Convert.ToInt32(reader["typeID"])),
                    Details = GetDetails(Convert.ToInt32(reader["detailID"])),
                    Login = reader["login"].ToString(),
                    Hash = reader["hash"].ToString(),
                    Salt = reader["salt"].ToString(),
                    CreatedDate = (DateTime)reader["createdDateTime"]
                };
            }
            return null;
        }

        public List<User> GetAllUsers()
        {
            var query = $"SELECT * FROM UserAcounts";

            var cmd = new SqlCommand(query, _connectionService.GetConnection());
            var reader = cmd.ExecuteReader();

            List<User> userList = new List<User>();
            while (reader.Read())
            {
                userList.Add(new User()
                {
                    Id = Convert.ToInt32(reader["userID"]),
                    Type = GetUserType(Convert.ToInt32(reader["typeID"])),
                    Details = GetDetails(Convert.ToInt32(reader["detailID"])),
                    Login = reader["login"].ToString(),
                    Hash = reader["hash"].ToString(),
                    Salt = reader["salt"].ToString(),
                    CreatedDate = (DateTime)reader["createdDateTime"]
                });
            }
            return userList;
        }

        public PeopleDetails GetDetails(int id)
        {
            var query = $"SELECT * FROM PeopleDetails WHERE detailID='{id}'";

            var cmd = new SqlCommand(query, _connectionService.GetConnection());
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                return new PeopleDetails()
                {
                    ID = Convert.ToInt32(reader["detailID"]),
                    Name = reader["name"].ToString(),
                    Surname = reader["surname"].ToString(),
                    PhoneNumber = reader["phone"].ToString(),
                    Email = reader["email"].ToString(),
                    City = reader["city"].ToString(),
                    Street = reader["street"].ToString(),
                    Number = reader["number"].ToString(),
                    PostalCode = reader["postalCode"].ToString(),
                };
            }
            return new PeopleDetails();
        }

        public UserType GetUserType(int id)
        {
            var query = $"SELECT * FROM UserTypes WHERE typeID={id}";
            var cmd = new SqlCommand(query, _connectionService.GetConnection());
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                return new UserType()
                {
                    ID = Convert.ToInt32(reader["typeID"]),
                    Type = reader["typeName"].ToString()
                };
            }
            return null;
        }

        public bool ChangePassword(int id, string newPassword, string oldPassword)
        {
            var hashNew = PasswordHasher.Hash(newPassword);
            var user = GetUser(id);
            if (PasswordHasher.Validate(oldPassword, user.Hash))
            {
                var query = $"UPDATE UserAcounts " +
                               $"SET hash = '{hashNew}' " +
                               $"WHERE userID = {id}";

                var cmd = new SqlCommand(query, _connectionService.GetConnection());
                cmd.ExecuteReader();
                return true;
            }
            return false;
        }
    }
}