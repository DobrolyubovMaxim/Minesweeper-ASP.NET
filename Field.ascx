<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Field.ascx.cs" Inherits="Minesweper.Field" %>

<div class="game-container">
    <div class="game">

        <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick" Interval="1000" Enabled="False"></asp:Timer>

        <div class="status-bar">

            <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Always">
                <ContentTemplate>
                    <asp:Label ID="Bombs" runat="server" Text="999" class="bombs"></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>


            <div class="center-buttoms">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="SmileMan" runat="server" class="smile" OnClick="SmileMan_Click" Style="background: url(../img/smile.png);" />
                        <asp:Button ID="FlagSwitch" runat="server" class="flag-switch" OnClick="FlagSwitch_Click" Style="background: url(../img/pointer.png);" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                </Triggers>
                <ContentTemplate>
                    <asp:Label ID="GameTimer" runat="server" Text="000" class="timer"></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>

        <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Always">
            <ContentTemplate>
                <asp:Label ID="CellsGrid" runat="server" class="cells-grid">
                    <asp:PlaceHolder runat="server" ID="FieldPlaceHolder" Visible="true"></asp:PlaceHolder>
                </asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>

    <asp:UpdatePanel ID="RecordUpdatePanel" runat="server">
        <ContentTemplate>
            <asp:Label runat="server" ID="Record" class="record" Visible="False">
                <asp:Label ID="Recordasd" runat="server">
                    <div class="record-window">
                        <h3>Победа!</h3>
                        <asp:TextBox ID="UserNameTextBox" runat="server" Text="Введите имя" Style="color: black"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="UserNameTextBoxRequiredFieldValidator" ControlToValidate="UserNameTextBox"
                            runat="server" Text="Введите имя" Style="color: red"></asp:RequiredFieldValidator>
                        <div class="record-btns">
                            <asp:Button ID="recordSave" class="record-btn" runat="server" Text="Save" OnClick="recordSave_Click" />
                            <asp:Button ID="recordNo" class="record-btn" runat="server" Text="Нет" OnClick="recordNo_Click" CausesValidation="False" />
                        </div>
                    </div>
                </asp:Label>
            </asp:Label>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
