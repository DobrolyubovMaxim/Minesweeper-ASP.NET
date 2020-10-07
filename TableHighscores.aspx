<%@ Page Title="Minesweeper" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TableHighscores.aspx.cs" Inherits="Test.TableHighscores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="highscores-body">
        <div class='highscores-container'>
            <% 
                Response.Write(String.Format(@"
                                <div class='highscores-item'>Имя</div>
                                <div class='highscores-item'>Сложность</div>
                                <div class='highscores-item'>Время</div> "));

                foreach (Minesweper.Models.Highscores highscores in GetHighscores())
                {
                    Response.Write(String.Format(@"
                                <div class='highscores-item'>{0}</div>
                                <div class='highscores-item'>{1}</div>
                                <div class='highscores-item'>{2}</div> ",
                            highscores.UserName, highscores.DifficultyToString(), highscores.Scores));
                }
            %>
        </div>
    </div>
</asp:Content>
