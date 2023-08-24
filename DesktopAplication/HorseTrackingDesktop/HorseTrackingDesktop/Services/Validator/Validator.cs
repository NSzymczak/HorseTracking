using System.Text.RegularExpressions;

namespace HorseTrackingDesktop.Services.Validator
{
    public class Validator : IValidator
    {
        public bool TextValidator(string input)
        {
            var pattern = @"^[A-Za-ząćęłńóśźżĄĆĘŁŃÓŚŹŻ\s\-']+$";
            var regex = new Regex(pattern);

            return regex.IsMatch(input);
        }
    }
}