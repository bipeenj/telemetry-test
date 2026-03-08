using Microsoft.AspNetCore.Mvc;
using TelemetryApi.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
namespace TelemetryApi.Controller
{
    //[Authorize]
    [ApiController]
    
    public class TelemetryController : ControllerBase
    {
        private readonly MAchineDbContext _context;

        public TelemetryController(MAchineDbContext context)
        {
            _context = context;
        }
        [Route("api/machines")]
        [HttpGet]
        public async Task<IActionResult> GetMachines()
        {
            var machines = await _context.Machines?.ToListAsync();
            return Ok(machines);
        }
        [Route("api/Tele")]
        [HttpGet]
        public async Task<IActionResult> GetTelemetry()
        {
            var telemetries = await _context.Telemetries?.ToListAsync();
            return Ok(telemetries);
        }
    }
}
