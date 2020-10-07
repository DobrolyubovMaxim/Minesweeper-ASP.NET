<%@ Page Title="Minesweeper" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Game.aspx.cs" Inherits="Minesweeper.Default" %>

<%@ Register TagPrefix="uc1" TagName="Field" Src="Field.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:Field ID="Field1" runat="server" />
</asp:Content>
