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
            modelBuilder.Entity<MachineStatus>().ToTable("machines");
            modelBuilder.Entity<Telemetry>().ToTable("telemetrysnapshots");
        }

        public DbSet<MachineStatus> Machines { get; set; }
        public DbSet<Telemetry> Telemetries { get; set; }
    }
}
