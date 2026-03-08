using Microsoft.EntityFrameworkCore;
using System.Reflection.PortableExecutable;

namespace TelemetryApi.Model
{


    public class MAchineDbContext : DbContext
    {
        public MAchineDbContext(DbContextOptions<MAchineDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MachineEntry>().ToTable("machines");
            modelBuilder.Entity<Telemetry>().ToTable("telemetrysnapshots");
        }

        public DbSet<MachineEntry> Machines { get; set; }
        public DbSet<Telemetry> Telemetries { get; set; }
       
    }
}
