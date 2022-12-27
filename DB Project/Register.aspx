<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="DB_Project.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
        }

        form {
            width: 300px;
            margin: 100px auto;
            border: 1px solid #ccc;
            border-radius: 5px;
            padding: 20px;
            text-align: center;
        }

        label {
            display: block;
            margin-top: 10px;
            margin-bottom: 5px;
        }

        input[type="text"], input[type="password"] {
            width: 100%;
            border: 1px solid #ccc;
            border-radius: 5px;
            padding: 8px;
            font-size: 16px;
        }

        input[type="submit"] {
            background-color: #4CAF50;
            color: white;
            border: none;
            border-radius: 5px;
            padding: 10px 20px;
            font-size: 16px;
            cursor: pointer;
        }

        input[id="registerButton"]:hover {
            background-color: #45a049;
        }
    </style>
    <form runat="server">
        <h2>Register</h2>
        <label for="name">Name:</label>
        <asp:TextBox ID="nameTextBox" runat="server"></asp:TextBox>
        <label for="username">Username:</label>
        <asp:TextBox ID="usernameTextBox" runat="server"></asp:TextBox>
        <label for="password">Password:</label>
        <asp:TextBox ID="passwordTextBox" runat="server" TextMode="Password"></asp:TextBox><br />
        <div id="clubRepDiv" style="display:none;">
            <label for="name">Club Name:</label>
            <asp:TextBox ID="clubNameTextBox" runat="server"></asp:TextBox>
        </div>
        <div id="managerDiv" style="display:none;">
            <label for="name">Stadium Name:</label>
            <asp:TextBox ID="stadiumNameTextBox" runat="server"></asp:TextBox>
        </div>
        <div id="fanDiv" style="display:none;">
            
            <label for="name">National ID:</label>
            <asp:TextBox ID="nationalIDTextBox" runat="server"></asp:TextBox>
            
            <label for="name">Phone:</label>
            <asp:TextBox ID="phoneTextBox" runat="server"></asp:TextBox>
            
            <label for="name">Birth Date:</label>
            <asp:TextBox ID="birthDateTextBox" runat="server" placeholder="YYYY-MM-DD"></asp:TextBox>
            
            <label for="name">Address:</label>
            <asp:TextBox ID="addressTextBox" runat="server"></asp:TextBox>
        </div>
        <asp:Label ID="registerResponse" runat="server" ForeColor="Red"></asp:Label><br />
        <asp:Button ID="registerButton" runat="server" Text="Register" OnClick="register" />
    </form>

</body>
</html>
