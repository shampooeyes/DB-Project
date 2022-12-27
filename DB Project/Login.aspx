<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DB_Project.Login" %>

<!DOCTYPE html>

<html>
<head>
  <title>Login</title>
  <style>
    body {
      font-family: Roboto;
      margin: 0;
      padding: 0;
    }

    .login-form {
      width: 300px;
      margin: 100px auto;
      border: 1px solid #ccc;
      background-color: white;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.8);
      border-radius: 5px;
      padding: 20px;
      text-align: center;
    }

    .login-form label {
      display: block;
      margin-top: 10px;
      margin-bottom: 5px;
    }

    .login-form input[type="text"], .login-form input[type="password"] {
      width: 90%;
      border: 1px solid #ccc;
      border-radius: 5px;
      padding: 8px;
      font-size: 16px;
      margin: 0 auto; 
    }

    .login-form input[type="submit"] {
      background-color: #4CAF50;
      color: white;
      border: none;
      border-radius: 5px;
      padding: 10px 20px;
      font-size: 16px;
      cursor: pointer;
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
    }

    .login-form input[id="registerButton"] {
      color: #4CAF50;
      background-color: white;
      border-color: #4CAF50;
      border: solid;
      border-radius: 5px;
      padding: 10px 20px;
      font-size: 16px;
      cursor: pointer;
    }

    .login-form input[id="loginButton"]:hover {
      background-color: #45a049;
    }
  </style>
</head>
<body style="background-image: url('background.png');">
  <form class="login-form" runat="server">
    <h2>Login</h2>
    <label for="username">Username:</label>
    <asp:TextBox ID="usernameTextBox" runat="server"></asp:TextBox>
    <label for="password">Password:</label>
    <asp:TextBox ID="passwordTextBox" runat="server" TextMode="Password"></asp:TextBox><br />
    <asp:Label ID="loginResponse" runat="server" ForeColor ="Red"></asp:Label><br />
    <asp:Button ID="loginButton" runat="server" Text="Login" OnClick="login" /> <br /><br />
     <asp:Label ID="registerLabel" runat="server" Text="Don't have an account?" ></asp:Label><br />
    <asp:Button ID="registerButton" runat="server" Text="Register" OnClick="Register" />
  </form>
</body>
</html>
