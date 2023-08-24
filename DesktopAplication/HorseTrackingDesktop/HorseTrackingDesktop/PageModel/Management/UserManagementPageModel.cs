using CommunityToolkit.Mvvm.Input;
using HorseTrackingDesktop.Models;
using HorseTrackingDesktop.Models.Dto;
using HorseTrackingDesktop.Services.Database.UserService;
using HorseTrackingDesktop.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorseTrackingDesktop.PageModel.Management
{
    internal partial class UserManagementPageModel : BaseViewModel
    {
        private readonly IUserServices _userServices;
        public UserDto SelectedUser { get; set; }

        public List<UserDto> Users { get; set; }

        public List<UserTypes> Types { get; set; }

        public UserManagementPageModel(IUserServices userServices)
        {
            _userServices = userServices;
        }

        public async Task SetUp()
        {
            await GetUsers();
            if (Users.Count > 0)
            {
                SelectedUser = Users.First();
            }
            Types = await _userServices.GetUserTypes();
            OnPropertyChanged(nameof(Users));
            OnPropertyChanged(nameof(SelectedUser));
            OnPropertyChanged(nameof(Types));
        }

        public async Task GetUsers()
        {
            Users = (await _userServices.GetAllUsers()).Select(UserDto.Convert).ToList();
        }

        public async Task Add(UserDto user)
        {
            if (user.UserId == 0)
            {
                await _userServices.AddUser(UserDto.ConvertBack(user));
            }
            else
            {
                await _userServices.EditUser(UserDto.ConvertBack(user));
            }
        }

        [RelayCommand]
        public Task ResetPassword()
        {
            return Task.CompletedTask;
        }
    }
}