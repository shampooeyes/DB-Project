<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="System Admin Form.aspx.cs" Inherits="DB_Project.System_Admin_Form" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-image: url('background.png');">
    <style>
        form {
  width: 1000px;
    margin: 50px auto;
  padding: 20px;
  border: 1px solid #ccc;
  background-color:white;
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.8);
  border-radius: 5px;
  font-family: Roboto
}


h2 {
  text-align: center;
  margin-bottom: 20px;
}

input[type="submit"] {
  width: 100%;
  padding: 12px 20px;
  margin: 8px 0;
  box-sizing: border-box;
  border: none;
  border-radius: 4px;
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.3);
  background-color: #4CAF50; /* Green */
  color: white;
  cursor: pointer;
}
input[value="Delete club"], input[value="Delete stadium"] {
  width: 100%;
  padding: 12px 20px;
  margin: 8px 0;
  box-sizing: border-box;
  border: none;
  border-radius: 4px;
  background-color: #ff0000; /* Red */
  color: white;
  cursor: pointer;
}

input[type="submit"]:hover {
  background-color: #45a049;
}

input[value="Delete club"]:hover, input[value="Delete stadium"]:hover {
  background-color: #cc0000;
}

    </style>
    <form runat="server" method="post" style="display:flex; flex-direction:column;">
  <div style="display:flex; justify-content:space-between;">
    <div style="float:left; width:45%;">
      <h2>Add a new club</h2>
      Club name:<br/>
      <asp:TextBox ID="clubNameTextBox" runat="server"></asp:TextBox><br/><br />
      Club location:<br/>
      <asp:TextBox ID="clubLocationTextBox" runat="server"></asp:TextBox><br/><br/>
      <asp:Label ID="addClubResponse" runat="server"></asp:Label>
      <asp:Button ID="addClubButton" runat="server" OnClick="AddClub" Text="Add club" />

      <h2>Delete a club</h2>
      Club name:<br/>
      <asp:TextBox ID="deleteClubNameTextBox" runat="server"></asp:TextBox><br/><br/>
      <asp:Label ID="deleteClubResponse" runat="server"></asp:Label>
      <asp:Button ID="deleteClubButton" runat="server" OnClick="DeleteClub" Text="Delete club" />
    </div>

    <div style="float:right; width:45%;">
      <h2>Add a new stadium</h2>
      Stadium name:<br/>
      <asp:TextBox ID="stadiumNameTextBox" runat="server"></asp:TextBox><br/><br />
      Stadium location:<br/>
      <asp:TextBox ID="stadiumLocationTextBox" runat="server"></asp:TextBox><br/><br />
      Stadium capacity:<br/>
      <asp:TextBox ID="stadiumCapacityTextBox" runat="server" TextMode="Number"></asp:TextBox><br/><br/>
      <asp:Label ID="addStadiumResponse" runat="server"></asp:Label>
      <asp:Button ID="addStadiumButton" runat="server" onClick="AddStadium" Text="Add stadium" />


      <h2>Delete a stadium</h2>
      Stadium name:<br/>
      <asp:TextBox ID="deleteStadiumNameTextBox" runat="server"></asp:TextBox><br/><br/>
      <asp:Label ID="deleteStadiumResponse" runat="server"></asp:Label>
      <asp:Button ID="deleteStadiumButton" runat="server" OnClick="DeleteStadium" Text="Delete stadium" />
    </div>
  </div>

  <div style="margin-top:20px; margin: 0 auto">
    <h2>Block a fan</h2>
    National ID number:<br/>
    <asp:TextBox ID="fanIdTextBox" runat="server" TextMode="Number"></asp:TextBox><br/><br/>
    <asp:Label ID="blockFanResponse" runat="server"></asp:Label>
    <asp:Button ID="blockFanButton" runat="server" OnClick="BlockFan" Text="Block fan" style="background-color: #FF0000"/>
            </div>
        
</form>

</body>
</html>
