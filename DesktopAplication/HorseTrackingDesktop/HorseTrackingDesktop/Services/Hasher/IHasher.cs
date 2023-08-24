namespace HorseTrackingDesktop.Services.Hasher
{
    public interface IHasher
    {
        string[] HashPassword(string password);

        bool CheckPassword(string password, string hash, string salt);
    }
}