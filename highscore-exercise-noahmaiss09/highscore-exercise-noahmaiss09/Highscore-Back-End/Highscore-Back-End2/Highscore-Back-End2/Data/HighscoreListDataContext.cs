using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Highscore_Back_End2.Data
{
    public class HighscoreListDataContext : DbContext
    {
        public HighscoreListDataContext(DbContextOptions<HighscoreListDataContext> options)
            : base(options)
        { }

        public DbSet<HighscoreList> HighscoreLists { get; set; }

        public DbSet<Score> Scores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<HighscoreList>(hl =>
            {
                hl.HasMany(hl => hl.Scores)
                    .WithOne(s => s.HighscoreList);
            });

            modelBuilder.Entity<HighscoreList>(h1 =>
            {
                h1.HasData(new HighscoreList { HighscoreListId = 1 });
            });
        }
    }
}
