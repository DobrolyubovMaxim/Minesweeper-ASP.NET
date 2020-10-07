<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Minesweeper.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Minesweeper</title>
    <link href="Style/Style.css" rel="stylesheet" />
    <link runat="server" rel="shortcut icon" href="~/favicon.ico" type="image/x-icon" />
    <link runat="server" rel="icon" href="~/favicon.ico" type="image/ico" />
    <link href='@Url.Content("~/Content/bootstrap.min.css")' rel="stylesheet" type="text/css" />
    <script src='@Url.Content("~/Scripts/bootstrap.min.js")'></script>
</head>
<body style="background: #c0c0c0">
    <form id="form1" runat="server">
        <div class="title-container">
            <div class="main-page-title">
                Minesweeper
            </div>
        </div>

        <%--<div class="main-page-body">
            <asp:Button ID="Button1" runat="server" Text="Начать" class="main-page-button" OnClick="StartButton_Click" />
        </div>--%>

        <div id="confirmDelete" class="choise-difficulty">
            <div class="choise-difficulty-window">
                Выберите сложность
                <div class="choise-difficulty-btns">
                    <asp:Button ID="Button2" runat="server" Text="Новичек" class="choise-difficulty-btn" OnClick="Dif1Button_Click"/>
                    <asp:Button ID="Button3" runat="server" Text="Любитель" class="choise-difficulty-btn" OnClick="Dif2Button_Click"/>
                    <asp:Button ID="Button4" runat="server" Text="Профессионал" class="choise-difficulty-btn" OnClick="Dif3Button_Click"/>
                </div>
            </div>
        </div>
    </form>

</body>
</html>

