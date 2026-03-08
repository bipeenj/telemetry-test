using Microsoft.AspNetCore.Mvc;
using TelemetryApi.Model;
using Microsoft.EntityFrameworkCore;
namespace TelemetryApi.Controller
{
    [ApiController]
    [Route("api/machines")]
    public class TelemetryController : ControllerBase
    {
        private readonly MAchineDbContext _context;

        public TelemetryController(MAchineDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetMachines()
        {
            var machines = await _context.Machines?.ToListAsync();
            return Ok(machines);
        }
    }
}
