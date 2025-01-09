using Boei_API.Models;
using Microsoft.EntityFrameworkCore;


namespace Boei_API
{
    public class OracleDbContext : DbContext
    {
        public DbSet<Buoy> Buoys { get; set; }
        public DbSet<BuoySensor> BuoySensors { get; set; }
        public DbSet<GPSLocation> GPSLocations { get; set; }
        public DbSet<Measurement> Measurements { get; set; }
        public DbSet<SensorType> SensorTypes { get; set; }

        public OracleDbContext(DbContextOptions options) : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Buoy>().HasKey(b => b.ID);

            modelBuilder.Entity<SensorType>().HasKey(s => s.ID);

            modelBuilder.Entity<BuoySensor>().HasKey(s => s.ID);
            modelBuilder.Entity<BuoySensor>()
                .HasOne(s => s.Buoy)
                .WithMany(b => b.Sensors)
                .HasForeignKey(s => s.BuoyID)
                .HasPrincipalKey(b => b.ID)
                .IsRequired();
            modelBuilder.Entity<BuoySensor>()
                .HasOne(s => s.SensorType)
                .WithMany()
                .HasForeignKey(s => s.SensorTypesID)
                .HasPrincipalKey(t => t.ID)
                .IsRequired();

            modelBuilder.Entity<GPSLocation>().HasKey(l => l.ID);
            modelBuilder.Entity<GPSLocation>()
                .HasOne(l => l.Buoy)
                .WithMany(b => b.Locations)
                .HasForeignKey(l => l.BuoyID)
                .HasPrincipalKey(b => b.ID)
                .IsRequired();

            modelBuilder.Entity<Measurement>().HasKey(m => m.ID);
            modelBuilder.Entity<Measurement>()
                .HasOne(m => m.Sensor )
                .WithMany(s => s.Measurements)
                .HasForeignKey(m => m.BuoySensorID)
                .HasPrincipalKey(b => b.ID)
                .IsRequired();

        }


    }
}
