using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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