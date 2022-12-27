<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="DB_Project.Homepage" %>

<!DOCTYPE html>
<html>
<head>
    <style>
        .card {
            width: 300px;
            height: 200px;
            border: 1px solid black;
            border-radius: 5px;
            padding: 5px;
            margin: 10px;
            display: flex;
            align-items: center;
            justify-content: center;
            flex-direction: column;
        }


        .title {
            font-size: 20px;
            font-weight: bold;
            text-align: center;
            font-family: Roboto;
            margin-bottom: 10px;
            margin: auto;
        }

        .button {
            width: 50%;
            padding: 12px 20px;
            display: block;
            margin: auto;
            box-sizing: border-box;
            border: none;
            border-radius: 4px;
            background-color: #4CAF50; /* Green */
            color: white;
            cursor: pointer;
            margin: auto;
        }

        form {
            width: 1000px;
            margin: 0 auto;
            padding: 20px;
            border: 1px solid #ccc;
            border-radius: 5px;
            font-family: Roboto;
            display: flex;
            justify-content: space-between;
        }
    </style>
</head>
<body>
    <form runat="server" method="post">
        <div id="myDiv" class="card">
            <div class="title">System Admin Account</div>
            <asp:Button CssClass="button" ID="adminRedirectButton" runat="server" OnClick="AdminRedirect" Text="View" />
        </div>
        <div class="card">
            <div class="title">Stadium Manager Account</div>
            <asp:Button CssClass="button" ID="managerRedirectButton" runat="server" OnClick="ManagerRedirect" Text="View" />
        </div>
        <div class="card">
            <div class="title">Fan Account</div>
            <asp:Button CssClass="button" ID="fanRedirectButton" runat="server" OnClick="FanRedirect" Text="View" />
        </div>
        <div class="card">
            <div class="title">Sports Association Manager Account</div>
            <asp:Button CssClass="button" ID="SAManagerRedirectButton" runat="server" OnClick="SAManagerRedirect" Text="View" />
        </div>
        <div class="card">
            <div class="title">Club Representative Account</div>
            <asp:Button CssClass="button" ID="clubrepRedirectButton" runat="server" OnClick="ClubRepresentativeRedirect" Text="View" />
        </div>
    </form>
</body>
</html>

