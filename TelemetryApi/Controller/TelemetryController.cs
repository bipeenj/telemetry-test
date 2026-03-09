using Microsoft.AspNetCore.Mvc;
using TelemetryApi.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Client.TelemetryCore.TelemetryClient;
using System.Reflection.PortableExecutable;
using Microsoft.Identity.Web;
namespace TelemetryApi.Controller
{
    [Authorize]
    [ApiController]
    
    public class TelemetryController : ControllerBase
    {
        private readonly MAchineDbContext _context;

        public TelemetryController(MAchineDbContext context)
        {
            _context = context;
        }
        [AllowAnonymous]
        [Route("api/machines")]
        [HttpGet]
        public async Task<IActionResult> GetMachines()
        {
            if(User!=null && User.Claims!=null)
            {

            }

            var machines = _context.Telemetries.GroupBy(t => t.machineid).AsEnumerable()
               .Select(g => g
            .OrderByDescending(m => m.report_time)
            .FirstOrDefault()).Select(t => new
            {
                MachineId = t.machineid,
                LatestStatus = t.status,
                LatestTemperatureC = t.temperaturec,
                LatestLastErrorCode = t.errorcode,
                HasAlert = t.status != "OK" || t.temperaturec > 28
            }).ToList();
            return Ok(machines);
        }
        [Route("api/Telemetry")]
        [HttpPost]
        public async Task<IActionResult> Telemetry([FromBody] List<Telemetry> telemetry)
        {
            foreach (var entry in telemetry)
            {
                // Update latest per machine
                var machine = await _context.Machines
                    .FirstOrDefaultAsync(m => m.machineid == entry.machineid);

                if (machine == null)
                {
                    machine = new MachineEntry
                    {
                        machineid = entry.machineid,
                        createdat = entry.report_time,
                    };
                    _context.Machines.Add(machine);
                }
                entry.id = _context.Telemetries.Count()+1;
                _context.Telemetries.Add(entry);
            }

            await _context.SaveChangesAsync();
            return Ok(new { message = "Telemetry processed successfully" });
        }
    }
}
