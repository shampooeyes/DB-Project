<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StadiumManager.aspx.cs" Inherits="DB_Project.StadiumManager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="SAMstyle.css"/>
    <title></title>
</head>
<body style="background-image: url('background.png');">
    <style>
        form {
    background-color: white;
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.8);
    margin: 50px auto;
        }
        input[type="submit"] {
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
        }
    </style>

    <form id="form1" runat="server">
        <div>
      <h2>Stadium Information</h2>
      <asp:GridView ID="gvStadiumTable" runat="server">

     </asp:GridView>
             </div>
        <div>
            <h2>All Requests</h2>
            <asp:Label ID="requestsResponse" runat="server"></asp:Label>
            <asp:GridView ID="gvReqTable" runat="server">
            </asp:GridView>
        </div>
        <div>
            <h2>All Pending Requests</h2>
            <asp:Label ID="pendingRequestsResponse" runat="server"></asp:Label>
        <asp:GridView ID="gvUnReqTable" runat="server">
            <Columns>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:Button ID="AcceptButton" runat="server" Text="Accept" OnCommand="AcceptRejectButton" CommandName="Accept" CommandArgument='<%# Eval("Host")%>' />
            </ItemTemplate>
        </asp:TemplateField>
                <asp:TemplateField>
            <ItemTemplate>
                <asp:Button ID="RejectButton" runat="server" Text="Reject" style="background-color: red;" OnCommand="AcceptRejectButton" CommandName="Reject" CommandArgument='<%# Eval("Host")%>' />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
        </asp:GridView>
        </div>
    </form>
</body>
</html>
