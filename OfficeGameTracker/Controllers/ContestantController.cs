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

        [HttpGet]
        public IEnumerable<Contestant> GetContestants()
        {
            List<Contestant> contestants = _context.Contestants.ToList();
            return contestants;
        }
    }
}
