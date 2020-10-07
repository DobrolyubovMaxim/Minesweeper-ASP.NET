using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Minesweeper
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Dif1Button_Click(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("~/Game.aspx?diff={0}", 1));
        }

        protected void Dif2Button_Click(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("~/Game.aspx?diff={0}", 2));
        }

        protected void Dif3Button_Click(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("~/Game.aspx?diff={0}", 3));
        }
    }
}