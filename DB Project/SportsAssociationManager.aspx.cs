using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
using System.Globalization;

namespace DB_Project
{
    public partial class SportsAssociationManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            viewAllUpcomingMatches(this, null);
            viewAllPlayedMatches(this, null);
            viewAllClubsNeverPlayed(this, null);

        }
        protected void viewAllUpcomingMatches(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["DBProject"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand viewUpcomingMatchesProc = new SqlCommand("SELECT * FROM allUpcomingMatches", conn);
            viewUpcomingMatchesProc.CommandType = CommandType.Text;


            conn.Open();
            SqlDataReader reader = viewUpcomingMatchesProc.ExecuteReader();

            upcomingMatchesGrid.DataSource = reader;
            upcomingMatchesGrid.DataBind();

            reader.Close();
            conn.Close();
        }

        protected void viewAllPlayedMatches(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["DBProject"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand viewUpcomingMatchesProc = new SqlCommand("SELECT * FROM allPlayedMatches", conn);
            viewUpcomingMatchesProc.CommandType = CommandType.Text;


            conn.Open();
            SqlDataReader reader = viewUpcomingMatchesProc.ExecuteReader();

            playedMatchesGrid.DataSource = reader;
            playedMatchesGrid.DataBind();

            reader.Close();
            conn.Close();
        }
        protected void viewAllClubsNeverPlayed(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["DBProject"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand viewClubsNeverPlayedProc = new SqlCommand("SELECT * FROM clubsNeverMatched", conn);
            viewClubsNeverPlayedProc.CommandType = CommandType.Text;


            conn.Open();
            SqlDataReader reader = viewClubsNeverPlayedProc.ExecuteReader();

            clubsNeverPlayedGrid.DataSource = reader;
            clubsNeverPlayedGrid.DataBind();

            reader.Close();
            conn.Close();
        }
        protected void addMatchButton_Click(object sender, EventArgs e)
        {
            string host = addHostName.Text;
            string guest = addGuestName.Text;
            string start = addStartTime.Text;
            string end = addEndTime.Text;

            addMatchResponse.ForeColor = Colors.Red;

            if (host.IsEmpty() || guest.IsEmpty())
            {
                addMatchResponse.Text = "Club names cannot be empty.";
                return;
            }
            if (start.IsEmpty() || end.IsEmpty())
            {
                addMatchResponse.Text = "Start and end times cannot be empty.";
                return;
            }

            if (host.Exceeds20() || guest.Exceeds20())
            {
                addMatchResponse.Text = "Make sure inputs are 20 characters or less.";
                return;
            }

            if (!DateTime.TryParseExact(start, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out _)
                || !DateTime.TryParseExact(end, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
            {
                addMatchResponse.Text = "Start and end times must be in the following format: YYYY-MM-DD hh:mm";
                return;
            }

            string connStr = WebConfigurationManager.ConnectionStrings["DBProject"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand addMatchProc = new SqlCommand("addNewMatch", conn);
            addMatchProc.CommandType = CommandType.StoredProcedure;
            addMatchProc.Parameters.Add(new SqlParameter("@host", host));
            addMatchProc.Parameters.Add(new SqlParameter("@guest", guest));
            addMatchProc.Parameters.Add(new SqlParameter("@start_time", start));
            addMatchProc.Parameters.Add(new SqlParameter("@end_time", end));

            conn.Open();
            addMatchProc.ExecuteNonQuery();
            conn.Close();

            addMatchResponse.ForeColor = Colors.Green;
            addMatchResponse.Text = host + " vs " + guest + " match successfully added.";

            addHostName.Text = "";
            addGuestName.Text = "";
            addStartTime.Text = "";
            addEndTime.Text = "";

            Page_Load(this, null);
        }
        protected void deleteMatchButton_Click(object sender, EventArgs e)
        {
            string host = deleteHostName.Text;
            string guest = deleteGuestName.Text;
            string start = deleteStartTime.Text;
            string end = deleteEndTime.Text;

            deleteMatchResponse.ForeColor = Colors.Red;

            if (host.IsEmpty() || guest.IsEmpty())
            {
                deleteMatchResponse.Text = "Club names cannot be empty.";
                return; 
            }
            if (start.IsEmpty() || end.IsEmpty())
            {
                deleteMatchResponse.Text = "Start and end times cannot be empty.";
                return;
            }

            if (host.Exceeds20() || guest.Exceeds20())
            {
                deleteMatchResponse.Text = "Make sure inputs are 20 characters or less.";
                return;
            }

            if (!DateTime.TryParseExact(start, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out _)
                || !DateTime.TryParseExact(end, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
            {
                deleteMatchResponse.Text = "Start and end times must be in the following format: YYYY-MM-DD hh:mm";
                return;
            }

            string connStr = WebConfigurationManager.ConnectionStrings["DBProject"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand deleteMatchProc = new SqlCommand("deleteMatchWithTime", conn);
            deleteMatchProc.CommandType = CommandType.StoredProcedure;
            deleteMatchProc.Parameters.Add(new SqlParameter("@host", host));
            deleteMatchProc.Parameters.Add(new SqlParameter("@guest", guest));
            deleteMatchProc.Parameters.Add(new SqlParameter("@start_time", start));
            deleteMatchProc.Parameters.Add(new SqlParameter("@end_time", end));

            conn.Open();
            deleteMatchProc.ExecuteNonQuery();
            conn.Close();

            deleteMatchResponse.ForeColor = Colors.Green;
            deleteMatchResponse.Text = host + " vs " + guest + " match successfully deleted.";

            addHostName.Text = "";
            addGuestName.Text = "";
            addStartTime.Text = "";
            addEndTime.Text = "";

            Page_Load(this, null);
        }
    }
}