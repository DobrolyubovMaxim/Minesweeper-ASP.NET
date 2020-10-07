using Minesweper.Models;
using Minesweper.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Test
{
    public partial class TableHighscores : System.Web.UI.Page
    {
        private Repository repository = new Repository();

        public IEnumerable<Highscores> GetHighscores()
        {
            return repository.Highscores;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}