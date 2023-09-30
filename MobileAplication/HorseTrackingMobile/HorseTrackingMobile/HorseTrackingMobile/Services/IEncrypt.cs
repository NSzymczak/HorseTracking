using System;
using System.Collections.Generic;
using System.Text;

namespace HorseTrackingMobile.Services
{
    public interface IEncrypt
    {
        string EncryptText(string toEncrypt);

        string DecryptText(string toDecrypt);
    }
}