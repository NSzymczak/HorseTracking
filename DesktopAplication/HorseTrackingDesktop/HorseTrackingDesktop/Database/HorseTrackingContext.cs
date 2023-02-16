using HorseDesktopLib.Horses;
using HorseDesktopLib.Users;
using Microsoft.EntityFrameworkCore;

namespace HorseTrackingDesktop.Database
{
    public class HorseTrackingContext: DbContext
    {
        public string ConnectionString { get; }

        public HorseTrackingContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(this.ConnectionString);
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Horse> Horse { get; set; }
        public DbSet<HorseStatus> HorseStatuses { get; set;}
        public DbSet<HorseGender> HorseGender { get; set;}

       

    }
}
