using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Timers;
using System.Data.Entity;
using Minesweper.Models.Repository;
using Minesweper.Models;

namespace Minesweper
{
    public partial class Field : System.Web.UI.UserControl
    {
        private GameField currentField = null;
        private Cell[,] cells;

        private Repository repository = new Repository();

        public IEnumerable<Highscores> GetHighscores()
        {
            return repository.Highscores;
        }
        public int StopGame //0 - игра идёт; 1 - выйграл; -1 - проиграл; 2 - игра не началась
        {
            get
            {
                return (int)ViewState["StopGame"];
            }
            set
            {
                switch (value)
                {
                    case 0:
                        Timer1.Enabled = true;
                        break;
                    case 1:
                        Timer1.Enabled = false;
                        Win();
                        break;
                    case -1:
                        Timer1.Enabled = false;
                        Lose();
                        break;
                    case 2:
                        Timer1.Enabled = false;
                        break;
                }
                ViewState["StopGame"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                UpdateField();
            }
            else
            {
                InitField();
            }
        }

        public void OpenCell(Cell sender)
        {
            if (StopGame == 2)
                StopGame = 0;

            if (StopGame == 0)
            {
                if (FlagSwitch.Style["background"] == "url(../img/pointer.png)")
                {
                    if (currentField.UserField[sender.x_coordinate + sender.y_coordinate * currentField.SizeX])
                    {
                        if (currentField.OpenAround(sender.x_coordinate, sender.y_coordinate) == 0)
                        {
                            if (currentField.CheckWin())
                                StopGame = 1;
                        }
                        else
                        {
                            StopGame = -1;
                        }
                    }
                    else
                    {
                        if (currentField.Open(sender.x_coordinate, sender.y_coordinate))
                        {
                            if (currentField.CheckWin())
                                StopGame = 1;
                        }
                        else
                        {
                            StopGame = -1;
                        }

                    }

                    foreach (int[] cell in currentField.ForUpdate)
                    {
                        cells[cell[1], cell[0]].opened = true;
                        cells[cell[1], cell[0]].Page_Load(this, new EventArgs());
                    }
                    currentField.ForUpdate.Clear();
                    Bombs.Text = ThreeDigitFormater(currentField.Bombs);

                    ViewState["GameField"] = currentField;
                }
                else
                {
                    currentField.PutFlag(sender.x_coordinate, sender.y_coordinate);
                    cells[sender.y_coordinate, sender.x_coordinate].info = currentField.FieldData[sender.y_coordinate * currentField.SizeX + sender.x_coordinate];
                    cells[sender.y_coordinate, sender.x_coordinate].Page_Load(this, new EventArgs());
                    Bombs.Text = ThreeDigitFormater(currentField.Bombs);
                }
            }
        }

        public void InitField()
        {
            switch (Request.QueryString["diff"])
            {
                case "1":
                    currentField = new GameField(9, 9, 10);
                    CellsGrid.Style["grid-template-columns"] = String.Format("repeat({0},20px)", 9);
                    break;
                case "2":
                    currentField = new GameField(16, 16, 40);
                    CellsGrid.Style["grid-template-columns"] = String.Format("repeat({0},20px)", 16);
                    break;
                case "3":
                    currentField = new GameField(30, 16, 99);
                    CellsGrid.Style["grid-template-columns"] = String.Format("repeat({0},20px)", 30);
                    break;
                default:
                    currentField = new GameField(9, 9, 10);
                    CellsGrid.Style["grid-template-columns"] = String.Format("repeat({0},20px)", 9);
                    break;
            }
            ViewState["GameField"] = currentField;
            StopGame = 2;
            Bombs.Text = ThreeDigitFormater(currentField.Bombs);

            cells = new Cell[currentField.SizeY, currentField.SizeX];

            for (int i = 0; i < currentField.SizeY; i++)
                for (int j = 0; j < currentField.SizeX; j++)
                {
                    cells[i, j] = (Cell)Page.LoadControl(@"~\Cell.ascx");
                    cells[i, j].info = currentField.FieldData[currentField.SizeX * i + j];
                    cells[i, j].opened = currentField.UserField[currentField.SizeX * i + j];
                    cells[i, j].x_coordinate = j;
                    cells[i, j].y_coordinate = i;

                    FieldPlaceHolder.Controls.Add(cells[i, j]);
                }
        }

        public void UpdateField()
        {
            currentField = (GameField)ViewState["GameField"];
            Bombs.Text = ThreeDigitFormater(currentField.Bombs);
            cells = new Cell[currentField.SizeY, currentField.SizeX];

            for (int i = 0; i < currentField.SizeY; i++)
                for (int j = 0; j < currentField.SizeX; j++)
                {
                    cells[i, j] = (Cell)Page.LoadControl(@"~\Cell.ascx");
                    cells[i, j].info = currentField.FieldData[currentField.SizeX * i + j];
                    cells[i, j].opened = currentField.UserField[currentField.SizeX * i + j];
                    cells[i, j].x_coordinate = j;
                    cells[i, j].y_coordinate = i;

                    FieldPlaceHolder.Controls.Add(cells[i, j]);
                }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            if (int.Parse(GameTimer.Text) >= 999)
            {
                GameTimer.Text = "999";
                Timer1.Enabled = false;
            }
            else
                GameTimer.Text = ThreeDigitFormater(int.Parse(GameTimer.Text) + 1);

        }

        private static string ThreeDigitFormater(int threeDigits)
        {
            if (threeDigits < -99)
                return "-99";
            else if (threeDigits < -9)
                return String.Format("-{0}", -threeDigits);
            else if (threeDigits < 0)
                return String.Format("-0{0}", -threeDigits);
            else if (threeDigits < 10)
                return String.Format("00{0}", threeDigits);
            else if (threeDigits < 100)
                return String.Format("0{0}", threeDigits);
            else if (threeDigits < 1000)
                return String.Format("{0}", threeDigits);
            else
                return "999";

        }

        protected void FlagSwitch_Click(object sender, EventArgs e)
        {
            if (FlagSwitch.Style["background"] == "url(../img/redflag.png)")
                FlagSwitch.Style["background"] = "url(../img/pointer.png)";
            else
                FlagSwitch.Style["background"] = "url(../img/redflag.png)";
        }

        public void Win()
        {
            SmileMan.Style["background"] = "url(../img/winSmile.png)";
            Record.Visible = true;
        }

        public void Lose()
        {
            SmileMan.Style["background"] = "url(../img/loseSmile.png)";
        }

        protected void SmileMan_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        public void NewGame()
        {
            currentField = new GameField(currentField.SizeX, currentField.SizeY, currentField.Bombs);

            ViewState["GameField"] = currentField;
            StopGame = 2;
            Bombs.Text = ThreeDigitFormater(currentField.Bombs);
            GameTimer.Text = "000";

            UpdatePanel4.Controls[0].Controls[1].Controls[0].Controls.Clear();

            for (int i = 0; i < currentField.SizeY; i++)
                for (int j = 0; j < currentField.SizeX; j++)
                {
                    cells[i, j] = (Cell)Page.LoadControl(@"~\Cell.ascx");
                    cells[i, j].info = currentField.FieldData[currentField.SizeX * i + j];
                    cells[i, j].opened = currentField.UserField[currentField.SizeX * i + j];
                    FieldPlaceHolder.Controls.Add(cells[i, j]);
                }
            SmileMan.Style["background"] = "url(../img/smile.png)";
        }

        protected void recordSave_Click(object sender, EventArgs e)
        {
            repository.AddNewHighscore(UserNameTextBox.Text, int.Parse(Request.QueryString["diff"]), int.Parse(GameTimer.Text));
            UserNameTextBox.Text = "Введите имя";
            Record.Visible = false;
        }

        protected void recordNo_Click(object sender, EventArgs e)
        {
            UserNameTextBox.Text = "Введите имя";
            Record.Visible = false;
        }
    }
}