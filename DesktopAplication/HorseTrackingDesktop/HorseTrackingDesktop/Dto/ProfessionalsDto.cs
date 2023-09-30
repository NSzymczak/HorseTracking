using HorseTrackingDesktop.Models;

namespace HorseTrackingDesktop.Dto
{
    public class ProfessionalsDto
    {
        public int ID { get; set; }
        public string Degree { get; set; }
        public Specialisations Specialisation { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string PostalCode { get; set; }

        public static Professionals ConvertBack(ProfessionalsDto professionalsDto)
        {
            return new Professionals()
            {
                ProfessionalId = professionalsDto.ID,
                Degree = professionalsDto.Degree,
                Specialisation = professionalsDto.Specialisation,
                Detail = new PeopleDetails()
                {
                    Name = professionalsDto.Name,
                    Surname = professionalsDto.Surname,
                    PhoneNumber = professionalsDto.PhoneNumber,
                    Email = professionalsDto.Email,
                    City = professionalsDto.City,
                    Street = professionalsDto.Street,
                    Number = professionalsDto.Number,
                    PostalCode = professionalsDto.PostalCode
                }
            };
        }

        public static ProfessionalsDto Convert(Professionals professionals)
        {
            return new ProfessionalsDto()
            {
                ID = professionals.ProfessionalId,
                Degree = professionals.Degree,
                Specialisation = professionals.Specialisation,
                Name = professionals.Detail.Name,
                Surname = professionals.Detail.Surname,
                PhoneNumber = professionals.Detail.PhoneNumber,
                Email = professionals.Detail.Email,
                City = professionals.Detail.City,
                Street = professionals.Detail.Street,
                Number = professionals.Detail.Number,
                PostalCode = professionals.Detail.PostalCode
            };
        }
    }
}