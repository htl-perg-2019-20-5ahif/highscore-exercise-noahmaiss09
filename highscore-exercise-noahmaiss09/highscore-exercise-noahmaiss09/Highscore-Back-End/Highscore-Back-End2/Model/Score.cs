using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Model
{
    public class Score
    {
        [Required]
        public int ScoreId { get; set; }

        [Required]
        public String Name { get; set; }

        [Required]
        public int Points { get; set; }

        //Foreign Keys

        public int HighsoreListId { get; set; }

        public HighscoreList HighscoreList { get; set; }
    }
}
