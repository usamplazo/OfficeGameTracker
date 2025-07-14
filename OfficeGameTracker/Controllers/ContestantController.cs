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
            return _context.Contestants.ToList();
        }

        [HttpGet]

        public Contestant GetContestantById(Guid id)
        {
            return _context.Contestants.SingleOrDefault(con => con.ContestantId == id);
        }

        [HttpPut]

        public Contestant AddOrUpdateContestant(Contestant contestant)
        {
            Contestant? existingContestant = _context.Contestants.FirstOrDefault(con => con.ContestantId == contestant.ContestantId);
            if (existingContestant is not null)
            {
                existingContestant.Username = contestant.Username;
                existingContestant.Email = contestant.Email;
                existingContestant.IsAdmin = contestant.IsAdmin;
                existingContestant.Age = contestant.Age;
                existingContestant.Image = contestant.Image;
                existingContestant.ModifiedOnUtc = DateTime.UtcNow;

                _context.Contestants.Update(existingContestant);
                return existingContestant;
            }

            _context.Contestants.Add(contestant);
            return contestant;
        }

        [HttpPost]
        public void RemoveContestant(Guid contestantId)
        {
            Contestant? existingContestant = _context.Contestants.FirstOrDefault(con => con.ContestantId == contestantId);
            _context.Contestants.Remove(existingContestant);

            return;
        }

        [HttpGet]

        public List<Scoreboard> GetContestantScoreboard(Guid contestantId)
        {
            return _context.Scoreboards.Where(score => score.ContestantId == contestantId)
                                                  .OrderBy(score => score.ModifiedOnUtc)
                                                  .ToList();
        }

        [HttpGet]
        public List<Scoreboard> GetAllScoreboardsForDiscipline(Guid disciplineId)
        {
            return _context.Scoreboards.Where(score => score.DisciplineId == disciplineId).ToList();
        }

        [HttpGet]
        public List<Scoreboard> GetDisciplineScoreboardsForContestant(Guid contestantId, Guid disciplineId)
        {
            return _context.Scoreboards
                                    .Where(score => score.ContestantId == contestantId
                                                        && score.DisciplineId == disciplineId)
                                    .ToList();
        }
    }
}
