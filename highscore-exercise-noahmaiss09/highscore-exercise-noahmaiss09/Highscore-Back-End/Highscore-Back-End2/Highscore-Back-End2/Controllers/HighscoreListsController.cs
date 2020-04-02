using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Highscore_Back_End2.Data;
using Model;

namespace Highscore_Back_End2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HighscoreListsController : ControllerBase
    {
        private readonly HighscoreListDataContext _context;

        public HighscoreListsController(HighscoreListDataContext context)
        {
            _context = context;
        }

        // GET: api/HighscoreLists/5
        [HttpGet]
        public async Task<ActionResult<HighscoreList>> GetHighscoreList()
        {
            var highscoreList = await _context.HighscoreLists
                                            .Include(hl => hl.Scores)
                                            .FirstAsync(hl => hl.HighscoreListId == 1);

            highscoreList.Scores = highscoreList.Scores.OrderByDescending(s => s.Points).ToList();

            if (highscoreList == null)
            {
                return NotFound();
            }

            return highscoreList;
        }
    }
}
