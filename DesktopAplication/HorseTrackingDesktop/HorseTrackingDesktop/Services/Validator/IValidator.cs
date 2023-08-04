using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseTrackingDesktop.Services.Validator
{
    public interface IValidator
    {
        bool TextValidator(string input);
    }
}