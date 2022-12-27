using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
using System.Globalization;

namespace DB_Project
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         
                string accountType = Request.QueryString["type"];
                string script;
                switch (accountType)
                {
                    case "club_representative":
                        script = "document.getElementById('clubRepDiv').style.display = 'block';";
                        ClientScript.RegisterStartupScript(GetType(), "hideDivScript", script, true);
                        break;
                    case "stadium_manager":
                        script = "document.getElementById('managerDiv').style.display = 'block';";
                        ClientScript.RegisterStartupScript(GetType(), "hideDivScript", script, true);
                        break;
                    case "fan":
                        script = "document.getElementById('fanDiv').style.display = 'block';";
                        ClientScript.RegisterStartupScript(GetType(), "hideDivScript", script, true);
                        break;
                }
            
        }
        protected void register(object sender, EventArgs e)
        {
            string accountType = Request.QueryString["type"];

            string name = nameTextBox.Text;
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;
            string clubName = clubNameTextBox.Text;
            string stadiumName = stadiumNameTextBox.Text;
            string nat_id = nationalIDTextBox.Text;
            string phone = phoneTextBox.Text;
            string birthDate = birthDateTextBox.Text;
            string address = addressTextBox.Text;

            if (username.IsEmpty() || password.IsEmpty() || name.IsEmpty())
            {
                registerResponse.Text = "Fields cannot be empty.";
                return;
            }

            if (username.Exceeds20() || password.Exceeds20() || name.Exceeds20())
            {
                registerResponse.Text = "Fields cannot exceed 20 characters";
                return;
            }

            string connStr = WebConfigurationManager.ConnectionStrings["DBProject"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand checkUserExistsProc = new SqlCommand("userExists", conn);
            checkUserExistsProc.CommandType = CommandType.StoredProcedure;
            checkUserExistsProc.Parameters.Add(new SqlParameter("@username", username));

            conn.Open();
            string userExists = (string) checkUserExistsProc.ExecuteScalar();
            conn.Close();
            if (userExists != null)
            {
                registerResponse.Text = "Username already exists.";
                return;
            }

            SqlCommand loginFunc = new SqlCommand("", conn);
            loginFunc.CommandType = CommandType.StoredProcedure;
            loginFunc.Parameters.Add(new SqlParameter("@name", name));
            loginFunc.Parameters.Add(new SqlParameter("@username", username));
            loginFunc.Parameters.Add(new SqlParameter("@password", password));

            if (accountType == "sports_association_manager")
            {
                loginFunc.CommandText = "addAssociationManager";

                conn.Open();
                loginFunc.ExecuteNonQuery();
                conn.Close();

                Session["username"] = username;
                Response.Redirect("SportsAssociationManager.aspx");
                return;
            } else if (accountType == "stadium_manager")
            { 
                if (stadiumName.IsEmpty())
                {
                    registerResponse.Text = "Fields cannot be empty.";
                    return;
                }

                if (stadiumName.Exceeds20())
                {
                    registerResponse.Text = "Fields cannot exceed 20 characters.";
                    return;
                }

                SqlCommand checkStadiumExists = new SqlCommand($"SELECT name FROM Stadium WHERE name = '{stadiumName}'", conn);
                checkStadiumExists.CommandType = CommandType.Text;

                conn.Open();
                string stadiumExists = (string) checkStadiumExists.ExecuteScalar();
                conn.Close() ;
                if (stadiumExists == null)
                {
                    registerResponse.Text = "Stadium does not exist.";
                    return;
                }

                loginFunc.CommandText = "addStadiumManager";
                loginFunc.Parameters.Add(new SqlParameter("@stadium_name", stadiumName));

                conn.Open();
                loginFunc.ExecuteNonQuery();
                conn.Close();

                Session["username"] = username;
                Session["stadium"] = stadiumName;
                Response.Redirect("StadiumManager.aspx");
                return;
            } else if (accountType == "club_representative")
            {
                if (clubName.IsEmpty())
                {
                    registerResponse.Text = "Fields cannot be empty.";
                    return;
                }

                if (clubName.Exceeds20())
                {
                    registerResponse.Text = "Fields cannot exceed 20 characters.";
                    return;
                }

                SqlCommand checkClubExists = new SqlCommand($"SELECT name FROM Club WHERE name = '{clubName}'", conn);
                checkClubExists.CommandType = CommandType.Text;

                conn.Open();
                string clubExists = (string) checkClubExists.ExecuteScalar();
                conn.Close();
                if (clubExists == null)
                {
                    registerResponse.Text = "Club does not exist.";
                    return;
                }


                loginFunc.CommandText = "addRepresentative";
                loginFunc.Parameters.Add(new SqlParameter("@club_name", clubName));

                conn.Open();
                try
                {
                int i = loginFunc.ExecuteNonQuery();
                } catch (Exception _)
                {
                    registerResponse.Text = "This club already has a registered representative.";
                    return;
                }
                
                conn.Close();

                Session["username"] = username;
                Session["club"] = clubName;
                Response.Redirect("ClubRepresentative.aspx");
                return;
            } else if (accountType == "fan")
            { 
                if (nat_id.IsEmpty() || phone.IsEmpty() || birthDate.IsEmpty() || address.IsEmpty())
                {
                    registerResponse.Text = "Fields cannot be empty.";
                    return;
                }

                if (nat_id.Exceeds20() || address.Exceeds20() || phone.Exceeds20())
                {
                    registerResponse.Text = "Fields cannot exceed 20 characters.";
                    return;
                }

                if (!int.TryParse(phone, out _))
                {
                    registerResponse.Text = "Phone must me a number";
                    return;
                }

                if (!DateTime.TryParseExact(birthDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
                {
                    registerResponse.Text = "Birth date must be in the following format: YYYY-MM-DD";
                    return;
                }

                SqlCommand checkNationalIDExists = new SqlCommand($"SELECT name FROM Fan WHERE nat_ID = '{nat_id}'", conn);
                checkNationalIDExists.CommandType = CommandType.Text;

                conn.Open();
                string natIDExists = (string)checkNationalIDExists.ExecuteScalar();
                conn.Close();
                if (natIDExists != null)
                {
                    registerResponse.Text = "National ID is already taken.";
                    return;
                }

                loginFunc.CommandText = "addFan";
                loginFunc.Parameters.Add(new SqlParameter("@nat_id", nat_id));
                loginFunc.Parameters.Add(new SqlParameter("@birthdate", birthDate));
                loginFunc.Parameters.Add(new SqlParameter("@phone", int.Parse(phone)));
                loginFunc.Parameters.Add(new SqlParameter("@address", address));

                conn.Open();
                loginFunc.ExecuteNonQuery();
                conn.Close();

                Session["username"] = username;
                Session["nat_id"] = nat_id;
                Response.Redirect("Fan.aspx");
                return;
            }
        }

    }
}