using System.Data.Entity;
using Entity.Models.Entity;

namespace Entity.Models
{
    public class DevicesContext : DbContext
    {     
        static DevicesContext()
               {
                   Database.SetInitializer<DevicesContext>(new DevicesContextInitializer());
               }



        public DbSet<Device> Device { get; set; }
        public DbSet<AirConditioning> AirConditioning { get; set; }
        public DbSet<Bluray> Bluray { get; set; }
        public DbSet<Fridge> Fridge { get; set; }
        public DbSet<Kettle> Kettle { get; set; }
        public DbSet<Lamp> Lamp { get; set; }
        public DbSet<StereoSystem> StereoSystem { get; set; }
        public DbSet<TeleVision> TeleVision { get; set; }
       
    }
}