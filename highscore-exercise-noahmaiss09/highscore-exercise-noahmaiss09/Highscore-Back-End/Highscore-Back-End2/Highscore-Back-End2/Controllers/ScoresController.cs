using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Highscore_Back_End2.Data;
using Model;
using BusinessLogic;

namespace Highscore_Back_End2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoresController : ControllerBase
    {
        private readonly HighscoreListDataContext _context;

        public ScoresController(HighscoreListDataContext context)
        {
            _context = context;
        }

        // POST: api/Scores
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<HighscoreList> PostScore(Score score)
        {
            HighscoreList highscoreList = await _context.HighscoreLists
                                                    .Include(hl => hl.Scores)
                                                    .FirstAsync(hl => hl.HighscoreListId == 1);



            var logic = new HighscoreLogic();

            highscoreList = logic.addScore(score, highscoreList);
            if (highscoreList != null)
            {
                _context.HighscoreLists.Update(highscoreList);
                await _context.SaveChangesAsync();

                return highscoreList;
            } else
            {
                return null;
            }
        }
    }
}
