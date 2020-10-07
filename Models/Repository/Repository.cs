using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Minesweper.Models.Repository
{
    public class Repository
    {
        public EFDbContext context = new EFDbContext();

        public IEnumerable<Highscores> Highscores
        {
            get { return context.Highscores; }
        }

        public void AddNewHighscore(string UserName, int Difficulty, int Scores)
        {
            Highscores highscores = new Highscores
            {
                UserName = UserName.Length > 100 ? UserName.Substring(0, 99) : UserName,
                Difficulty = Difficulty,
                Scores = Scores
            };

            context.Highscores.Add(highscores);
            context.SaveChanges();
        }
    }
}