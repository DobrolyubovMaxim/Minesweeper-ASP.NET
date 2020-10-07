using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Minesweper.Models
{
    public class Highscores
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public int Difficulty { get; set; }
        public int Scores { get; set; }

        public string DifficultyToString()
        {
            switch (Difficulty)
            {
                default:
                case 1: return "Новичек";
                case 2: return "Любитель";
                case 3: return "Профессионал";
            }
        }
    }
}