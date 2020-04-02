using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Model
{
    public class HighscoreList
    {
        [Required]
        public int HighscoreListId { get; set; }

        //Foreign Keys

        public ICollection<Score> Scores { get; set; }
    }
}
