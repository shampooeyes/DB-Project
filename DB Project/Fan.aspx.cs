using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
using System.Web.UI.WebControls;
using System.Globalization;

namespace DB_Project
{
    public partial class Fan : System.Web.UI.Page
    {
        string start_time;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                viewAvailableMatches(this, null);
            }
        }
        protected void viewMatchesFromDate(object sender, EventArgs e)
        {
            if (!DateTime.TryParseExact(selectedDateTime.Text, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
            {
                selectedDateTimeResponse.Text = "Start time must be in the following format: YYYY-MM-DD hh:mm";
                return;
            }

            if (DateTime.Parse(selectedDateTime.Text).CompareTo(DateTime.Now) < 0)
            {
                selectedDateTimeResponse.Text = "Time cannot be in the past.";
                return;
            }

            start_time = selectedDateTime.Text;
            viewAvailableMatches(this, null);

            
        }

        protected void viewAvailableMatches(object sender, EventArgs e)
        {
            string script = "document.getElementById('gridDiv').style.display = 'block';";
            ClientScript.RegisterStartupScript(GetType(), "hideDivScript", script, true);


            string connStr = WebConfigurationManager.ConnectionStrings["DBProject"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand viewAvailableMatchesProc = new SqlCommand($"SELECT * FROM availableMatchesToAttend ('{start_time}')", conn);
            viewAvailableMatchesProc.CommandType = CommandType.Text;


            conn.Open();
            SqlDataReader reader = viewAvailableMatchesProc.ExecuteReader();

            availableMatchesGrid.DataSource = reader;
            availableMatchesGrid.DataBind();

            reader.Close();
            conn.Close();
        }

        protected void availableMatchesGrid_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int rowNum = e.NewEditIndex;
            string host = availableMatchesGrid.Rows[rowNum].Cells[0].Text;
            string guest = availableMatchesGrid.Rows[rowNum].Cells[1].Text;
            string nat_id = (string) Session["nat_id"];

            string connStr = WebConfigurationManager.ConnectionStrings["DBProject"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand purchaseTicketProc = new SqlCommand("purchaseTicket", conn);
            purchaseTicketProc.CommandType = CommandType.StoredProcedure;
            purchaseTicketProc.Parameters.Add(new SqlParameter("@nat_id", nat_id));
            purchaseTicketProc.Parameters.Add(new SqlParameter("@host_name", host));
            purchaseTicketProc.Parameters.Add(new SqlParameter("@guest_name", guest));
            purchaseTicketProc.Parameters.Add(new SqlParameter("@start_time", start_time));
        }

    }
}