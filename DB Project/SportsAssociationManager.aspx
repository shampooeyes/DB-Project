<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SportsAssociationManager.aspx.cs" Inherits="DB_Project.SportsAssociationManager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title></title>
    <link rel="stylesheet" type="text/css" href="SAMstyle.css"/>
</head>
<body style="background-image: url('background.png');">

    <style>
        input[value="Delete Match"] {
    background: red;
}

input[type="submit"] {
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.3);
}

input[value="Delete Match"]:hover {
    background: #cc0000;
}

form {
    width: 1000px;
    margin: 50px auto;
    padding: 20px;
    background-color: white;
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.8);
    border: 1px solid #ccc;
    border-radius: 10px;
    font-family: Roboto
}
    </style>


  <form id="form1" runat="server">
  <!-- Add a new match form -->
    <h2>Add a new match</h2>
    <p>
      <label for="hostClubName">Host club name:</label>
      <asp:TextBox ID="addHostName" runat="server"></asp:TextBox>
    </p>
    <p>
      <label for="guestClubName">Guest club name:</label>
      <asp:TextBox ID="addGuestName" runat="server"></asp:TextBox>
    </p>
    <p>
      <label for="startTime">Start time:</label>
      <asp:TextBox ID="addStartTime" runat="server" placeholder="YYYY-MM-DD hh:mm"></asp:TextBox>
    </p>
    <p>
      <label for="endTime">End time:</label>
      <asp:TextBox ID="addEndTime" runat="server" placeholder="YYYY-MM-DD hh:mm"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="addMatchResponse" runat="server"/>
      <asp:Button ID="addMatchButton" runat="server" Text="Add Match" OnClick="addMatchButton_Click" />
    </p>

  <!-- Delete a match form -->
    <h2>Delete a match</h2>
    <p>
      <label for="hostClubName">Host club name:</label>
      <asp:TextBox ID="deleteHostName" runat="server"></asp:TextBox>
    </p>
    <p>
      <label for="guestClubName">Guest club name:</label>
      <asp:TextBox ID="deleteGuestName" runat="server"></asp:TextBox>
    </p>
    <p>
      <label for="startTime">Start time:</label>
      <asp:TextBox ID="deleteStartTime" runat="server" placeholder="YYYY-MM-DD hh:mm"></asp:TextBox>
    </p>
    <p>
      <label for="endTime">End time:</label>
      <asp:TextBox ID="deleteEndTime" runat="server" placeholder="YYYY-MM-DD hh:mm"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="deleteMatchResponse" runat="server"/>
      <asp:Button ID="deleteMatchButton" runat="server" Text="Delete Match" OnClick="deleteMatchButton_Click" />
    </p>

  <!-- View upcoming matches table -->
  <h2>Upcoming matches</h2>
      <asp:Label ID="upcomingMatchesLabel" runat="server" />
  <asp:GridView ID="upcomingMatchesGrid" runat="server" AutoGenerateColumns="false">
    <Columns>
      <asp:BoundField DataField="Host" HeaderText="Host Club Name" />
      <asp:BoundField DataField="Guest" HeaderText="Guest Club Name" />
      <asp:BoundField DataField="Start_Time" HeaderText="Start Time" />
      <asp:BoundField DataField="End_Time" HeaderText="End Time" />
    </Columns>
  </asp:GridView>

  <!-- View already played matches table -->
  <h2>Already played matches</h2>
      <asp:Label ID="viewAllPlayedMatchesLabel" runat="server" />
  <asp:GridView ID="playedMatchesGrid" runat="server" AutoGenerateColumns="false">
    <Columns>
      <asp:BoundField DataField="Host" HeaderText="Host Club Name" />
      <asp:BoundField DataField="Guest" HeaderText="Guest Club Name" />
      <asp:BoundField DataField="Start_Time" HeaderText="Start Time" />
      <asp:BoundField DataField="End_Time" HeaderText="End Time" />
    </Columns>
  </asp:GridView>

  <!-- View pairs of club names that have never played a match -->
  <h2>Club name pairs that have never played a match</h2>
      <asp:Label ID="viewAllClubsNeverPlayedLabel" runat="server" />
  <asp:GridView ID="clubsNeverPlayedGrid" runat="server" AutoGenerateColumns="false">
    <Columns>
      <asp:BoundField DataField="Club1" HeaderText="Club 1 Name" />
      <asp:BoundField DataField="Club2" HeaderText="Club 2 Name" />
    </Columns>
  </asp:GridView>

      
      </form>

</body>
</html>
