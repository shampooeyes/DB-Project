<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Fan.aspx.cs" Inherits="DB_Project.Fan" EnableEventValidation="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="SAMstyle.css"/>
    <title></title>
</head>
<body style="background-image: url('background.png');">
    <style>
        input[value="Purchase Ticket"] {
    background-color: #4caf50;
    border: none;
    color: white;
    padding: 10px;
    margin: 5px;
    text-align: center;
    text-decoration: none;
    display: inline-block;
    border-radius: 6px;
    font-size: 16px;
    cursor: pointer;

    }

        form {
            background-color: white;
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.8);
        }
}
    </style>
    <form id="form1" runat="server">
        
        <p>
      <h2>View Matches For Following Date and Time:</h2>
      <asp:TextBox ID="selectedDateTime" runat="server" placeholder="YYYY-MM-DD hh:mm"></asp:TextBox><br />
        <asp:Label ID="selectedDateTimeResponse" runat="server" ForeColor="Red"/>
            <asp:Button ID="selectDateButton" runat="server" Text="Go" OnClick="viewMatchesFromDate"/>
    </p>
        <div id="gridDiv" style="display:none;">
            <h2>Available Matches To Attend</h2>
  <asp:GridView ID="availableMatchesGrid" runat="server" AutoGenerateColumns="false"  OnRowEditing="availableMatchesGrid_RowEditing">
    <Columns>
      <asp:BoundField DataField="Host" HeaderText="Host Club Name" />
      <asp:BoundField DataField="Guest" HeaderText="Guest Club Name" />
      <asp:BoundField DataField="Stadium" HeaderText="Stadium" />
      <asp:BoundField DataField="Location" HeaderText="Location" />
        <asp:TemplateField>
            <ItemTemplate>
                <asp:Button ID="Button1" runat="server" Text="Purchase Ticket" CommandName="Edit" CommandArgument='<%# Eval("Host")%>' />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
  </asp:GridView>
        </div>
    </form>
</body>
</html>
