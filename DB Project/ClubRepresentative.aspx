<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClubRepresentative.aspx.cs" Inherits="DB_Project.ClubRepresentative" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="SAMstyle.css"/>
    <title></title>
</head>
<body  style="background-image: url('background.png');">
    <style>
        form {
            background-color: white;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.8);
        }
    </style>

    <form id="form1" runat="server">
        <div>
      <h2>Club Information</h2>
      <asp:GridView ID="gvClubTable" runat="server">

     </asp:GridView>
             </div>
        <div>
            <h2>All Upcoming Matches</h2>
            <asp:Label ID="UpcomingMatches" runat="server"></asp:Label>
            <asp:GridView ID="upcomMatch" runat="server">
            </asp:GridView>
        </div>
        <div>
            <h2>All Available Stadiums</h2>


             Enter date:
            <asp:TextBox ID="dateTextBox" runat="server" placeholder="YYYY-MM-DD hh:mm"></asp:TextBox>

            <br />
            <asp:Label ID="availableStadiumsResponse" runat="server"></asp:Label>
            
            <asp:Button ID="stadButton" runat="server" Text="Enter" OnClick="stadButton_Click" />

            <br />

            <br />
            <asp:GridView ID="availStadTable" runat="server"></asp:GridView>


            <br />
            <h2>Send a host request</h2><br />
            Stadium name:
            <br />
            <asp:TextBox ID="stadTextBox" runat="server"></asp:TextBox>
            <br />
            Start time:<br />
            <asp:TextBox ID="timeTextBox" runat="server" placeholder="YYYY-MM-DD hh:mm"></asp:TextBox>
            <br />
            <asp:Label ID="hostRequestResponse" runat="server" />
            <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
            <br />


        </div>
    </form>
</body>
</html>
