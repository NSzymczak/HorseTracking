using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseTrackingDesktop.Services.Hasher
{
    public interface IHasher
    {
        string[] HashPassword(string password);

        bool CheckPassword(string password, string hash, string salt);
    }
}