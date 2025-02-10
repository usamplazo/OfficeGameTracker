using Microsoft.AspNetCore.Mvc;
using OfficeGameTracker.Data;
using OfficeGameTracker.Entities;

namespace OfficeGameTracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContestantController : Controller
    {
        private readonly GameTrackerDbContext _context;
        public ContestantController(GameTrackerDbContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<Contestant> Get()
        {
            var test = _context.Disciplines.ToList();
            return [.. _context.Contestants];
        }
    }
}
