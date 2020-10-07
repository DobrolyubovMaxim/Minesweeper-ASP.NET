using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Minesweper
{
    [Serializable]
    public partial class Cell : System.Web.UI.UserControl
    {
        public bool opened
        {
            get
            {
                if (ViewState["opened"] != null)
                    return (bool)ViewState["opened"];
                else
                    return false;
            }
            set
            {
                ViewState["opened"] = value;
            }
        }
        public int info
        {
            get
            {
                if (ViewState["info"] != null)
                    return (int)ViewState["info"];
                else
                    return 0;
            }
            set
            {
                ViewState["info"] = value;
            }
        }
        public int x_coordinate
        {
            get
            {
                if (ViewState["x_coordinate"] != null)
                    return (int)ViewState["x_coordinate"];
                else
                    return -1;
            }
            set
            {
                ViewState["x_coordinate"] = value;
            }
        }
        public int y_coordinate
        {
            get
            {
                if (ViewState["y_coordinate"] != null)
                    return (int)ViewState["y_coordinate"];
                else
                    return -1;
            }
            set
            {
                ViewState["y_coordinate"] = value;
            }
        }
        public bool lastClick = false;

        public void Page_Load(object sender, EventArgs e)
        {
            if (opened)
            {
                cellID.Style["background"] = "#c0c0c0";
                cellID.Style["border"] = "1px solid #808080";
                switch (info)
                {
                    case 0:
                        cellID.Text = "";
                        break;
                    case 1:
                        cellID.Text = "" + info;
                        cellID.Style["color"] = "rgb(0, 0, 255)";
                        break;
                    case 2:
                        cellID.Text = "" + info;
                        cellID.Style["color"] = "rgb(0, 128, 0)";
                        break;
                    case 3:
                        cellID.Text = "" + info;
                        cellID.Style["color"] = "rgb(255, 0, 0)";
                        break;
                    case 4:
                        cellID.Text = "" + info;
                        cellID.Style["color"] = "rgb(0, 0, 128)";
                        break;
                    case 5:
                        cellID.Text = "" + info;
                        cellID.Style["color"] = "rgb(128, 0, 0)";
                        break;
                    case 6:
                        cellID.Text = "" + info;
                        cellID.Style["color"] = "rgb(0, 128, 128)";
                        break;
                    case 7:
                        cellID.Text = "" + info;
                        cellID.Style["color"] = "rgb(0, 0, 0)";
                        break;
                    case 8:
                        cellID.Text = "" + info;
                        cellID.Style["color"] = "rgb(128, 128, 128)";
                        break;
                    case 9:
                        cellID.Text = "";
                        cellID.Style["background"] = "url(../img/redmine.png)";
                        break;
                    case 10:
                    case 11:
                    case 12:
                    case 13:
                    case 14:
                    case 15:
                    case 16:
                    case 17:
                    case 18:
                    case 19:
                        //сюда невозможно попасть
                        break;
                }
            }
            else
            {
                switch (info)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                        cellID.Style["background"] =  "#c0c0c0";
                        break;
                    //debug show mines
                    //case 9:
                    //    cellID.Text = "";
                    //    cellID.Style["background"] = "url(../img/greymine.png)";
                    //    break;
                    case 10:
                    case 11:
                    case 12:
                    case 13:
                    case 14:
                    case 15:
                    case 16:
                    case 17:
                    case 18:
                    case 19:
                        //картинка
                        cellID.Text = "";
                        cellID.Style["background"] = "url(../img/redflag.png)";
                        break;
                }
            }
        }

        protected void cell_Click(object sender, EventArgs e)
        {
            ((Field)Parent.Parent.Parent.Parent.Parent).OpenCell(this);
        }
        public void cell_RMBClick()
        {
            ((Field)Parent.Parent.Parent.Parent.Parent).OpenCell(this);
        }
    }
}