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

        public DbSet<MachineStatus> Machines { get; set; }
        public DbSet<Telemetry> Telemetries { get; set; }
    }
}
