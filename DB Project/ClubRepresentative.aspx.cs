using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.Configuration;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace DB_Project
{
    public partial class ClubRepresentative : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                viewClubInfo(this, null);
                viewAllUpcomingMatches(this, null);
                viewAllAvailableStadiums(this, null);
            }
        }

        protected void viewClubInfo(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["DBProject"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);



            string sql = $"SELECT id AS 'ID', name AS 'Club Name', location AS 'Location' from Club WHERE name = '{Session["club"]}'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            gvClubTable.DataSource = reader;
            gvClubTable.DataBind();

            conn.Close();
        }

        protected void viewAllUpcomingMatches(object sender, EventArgs e)
        {
            string clubName = (string)Session["club"];

            string connStr = ConfigurationManager.ConnectionStrings["DBProject"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);

            string sql = $"SELECT * FROM allUpcomingMatches WHERE Host = '{clubName}' OR Guest = '{clubName}'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;

            conn.Open();
            string checkEmpty = (string)cmd.ExecuteScalar();
            if (checkEmpty == null)
            {
                UpcomingMatches.Text = "No Matches Found 😞";
            }
            SqlDataReader reader = cmd.ExecuteReader();
            upcomMatch.DataSource = reader;
            upcomMatch.DataBind();
            reader.Close();
            conn.Close();
        }

        protected void viewAllAvailableStadiums(object sender, EventArgs e)
        {
            
        }



        protected void stadButton_Click(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["DBProject"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);

            string date = dateTextBox.Text;

            if (!DateTime.TryParseExact(date, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
            {
                availableStadiumsResponse.Text = "Request must be in the following format: YYYY-MM-DD hh:mm.";
                availableStadiumsResponse.ForeColor = Colors.Red;
                return;
            }

            string sql = $"SELECT * FROM viewAvailableStadiumsOn ('{Session["date"]}')";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;


            conn.Open();
            string checkEmpty = (string)cmd.ExecuteScalar();
            if (checkEmpty == null)
            {
                availableStadiumsResponse.Text = "No available Stadiums Found 😞";
            }
            SqlDataReader reader = cmd.ExecuteReader();
            availStadTable.DataSource = reader;
            availStadTable.DataBind();
            reader.Close();
            conn.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DBProject"].ToString();

            SqlConnection conn = new SqlConnection(connStr);

            string stadium = stadTextBox.Text;
            string time = timeTextBox.Text;

            if (!DateTime.TryParseExact(time, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
            {
                hostRequestResponse.Text = "Request must be in the following format: YYYY-MM-DD hh:mm.";
                return;
            }

            SqlCommand represent = new SqlCommand("addHostRequest", conn);
            represent.CommandType = CommandType.StoredProcedure;
            represent.Parameters.Add(new SqlParameter("@club_name", Session["club"]));
            represent.Parameters.Add(new SqlParameter("@stadium_name", stadium));
            represent.Parameters.Add(new SqlParameter("@start_time", time));

            conn.Open();
            try
            {
                represent.ExecuteNonQuery();
            } catch (Exception ex)
            {
                hostRequestResponse.Text = "No match found at the specified stadium and time.";
                hostRequestResponse.ForeColor = Colors.Red;
                return;
            }
            
            conn.Close();

            Response.Redirect("ClubRepresentative.aspx");

            hostRequestResponse.Text = "Host request sent successfully.";
        }
    }
}