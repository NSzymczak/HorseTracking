using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseTrackingDesktop.Models.Dto
{
    public class UserDto
    {
        public int UserId { get; set; }

        public string Login { get; set; }
        public string Hash { get; set; }
        public string Salt { get; set; }
        public DateTime? CreatedDateTime { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string PostalCode { get; set; }

        public virtual UserTypes Type { get; set; }

        public static UserAcounts ConvertBack(UserDto userDto)
        {
            return new UserAcounts()
            {
                UserId = userDto.UserId,
                Login = userDto.Login,
                Hash = userDto.Hash,
                Salt = userDto.Salt,
                CreatedDateTime = userDto.CreatedDateTime,
                Type = userDto.Type,
                Detail = new PeopleDetails()
                {
                    Name = userDto.Name,
                    Surname = userDto.Surname,
                    PhoneNumber = userDto.PhoneNumber,
                    Email = userDto.Email,
                    City = userDto.City,
                    Street = userDto.Street,
                    Number = userDto.Number,
                    PostalCode = userDto.PostalCode
                }
            };
        }

        public static UserDto Convert(UserAcounts user)
        {
            return new UserDto()
            {
                UserId = user.UserId,
                Login = user.Login,
                Hash = user.Hash,
                Salt = user.Salt,
                CreatedDateTime = user.CreatedDateTime,
                Type = user.Type,

                Name = user.Detail.Name,
                Surname = user.Detail.Surname,
                PhoneNumber = user.Detail.PhoneNumber,
                Email = user.Detail.Email,
                City = user.Detail.City,
                Street = user.Detail.Street,
                Number = user.Detail.Number,
                PostalCode = user.Detail.PostalCode
            };
        }
    }
}