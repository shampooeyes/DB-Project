using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace DB_Project
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["type"] == "admin")
            {
                registerLabel.Visible = false;
                registerButton.Visible= false;
            }
        }

        protected void login(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;

            if (username.IsEmpty() || password.IsEmpty())
            {
                loginResponse.Text = "Username and password cannot be empty.";
                return;
            }

            if (username.Exceeds20() || password.Exceeds20())
            {
                loginResponse.Text = "Username and password cannot exceed 20 characters";
                return;
            }
            

            string connStr = WebConfigurationManager.ConnectionStrings["DBProject"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string accountType = Request.QueryString["type"];
            string sqlCommand = "";
            switch (accountType)
            {
                case "fan":
                    sqlCommand = "fanLogin";
                    break;
                case "admin":
                    sqlCommand = "adminLogin";
                    break;
                case "stadium_manager":
                    sqlCommand = "managerLogin";
                    break;
                case "sports_association_manager":
                    sqlCommand = "SAManagerLogin";
                    break;
                case "club_representative":
                    sqlCommand = "clubRepLogin";
                    break;
            }
            if (sqlCommand.IsEmpty()) return;
            
            SqlCommand loginFunc = new SqlCommand(sqlCommand, conn);
            loginFunc.CommandType = CommandType.StoredProcedure;
            loginFunc.Parameters.Add(new SqlParameter("@username", username));
            loginFunc.Parameters.Add(new SqlParameter("@password", password));

            conn.Open();
            string str = (string) loginFunc.ExecuteScalar();
            conn.Close();

            if (str == null)
            {
                loginResponse.Text = "Wrong username or password";
            } else
            {
                Session.Add("username", username);
                if (accountType == "fan") Session.Add("nat_id", str);

                switch (accountType)
                {
                    case "fan":
                        Response.Redirect("Fan.aspx");
                        break;
                    case "admin":
                        Response.Redirect("System%20Admin%20Form.aspx");
                        break;
                    case "stadium_manager":
                        SqlCommand getStadiumNameProc = new SqlCommand($"SELECT stadium FROM allStadiumManagers WHERE username = '{username}'", conn);
                        getStadiumNameProc.CommandType = CommandType.Text;
                        conn.Open();
                        string stadiumName = (string) getStadiumNameProc.ExecuteScalar();
                        Session["stadium"] = stadiumName;
                        conn.Close();

                        Response.Redirect("StadiumManager.aspx");
                        break;
                    case "sports_association_manager":
                        Response.Redirect("SportsAssociationManager.aspx");
                        break;
                    case "club_representative":
                        Response.Redirect("ClubRepresentative.aspx");
                        break;
                }
                
            }

        }
        protected void Register(object sender, EventArgs e)
        {
            string accountType = Request.QueryString["type"];
            Response.Redirect("Register.aspx?type="+accountType);
        }
    }
}