using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace DB_Project
{
    public partial class StadiumManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                viewStadiumInfo(this, null);
                viewAllRequests(this, null);
                viewAllPendingRequests(this, null);
            }
        }

        protected void viewStadiumInfo(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["DBProject"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);

            string sql = "SELECT name AS 'Stadium Name', location AS 'Location', status AS 'Status', capacity AS 'Capacity' from Stadium WHERE name= @Stadium_name";
            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.Add(new SqlParameter("@Stadium_name", value: Session["stadium"]));
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            gvStadiumTable.DataSource = reader;
            gvStadiumTable.DataBind();

            conn.Close();
        }

        protected void viewAllRequests(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["DBProject"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);

            string sql = $"SELECT * FROM viewAllRequestsForManager ('{Session["username"]}')";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType= CommandType.Text; 

            conn.Open();
            string checkEmpty = (string) cmd.ExecuteScalar();
            if (checkEmpty == null )
            {
                requestsResponse.Text = "No Requests Found 😞";
            }
            SqlDataReader reader = cmd.ExecuteReader();
            gvReqTable.DataSource = reader;
            gvReqTable.DataBind();
            reader.Close();
            conn.Close();
        }

        protected void viewAllPendingRequests(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["DBProject"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);

            string sql = $"SELECT * FROM allPendingRequests ('{Session["username"]}')";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;

            conn.Open();
            string checkEmpty = (string)cmd.ExecuteScalar();
            if (checkEmpty == null)
            {
                pendingRequestsResponse.Text = "No Requests Found 😞";
            }
            SqlDataReader reader = cmd.ExecuteReader();
            gvUnReqTable.DataSource = reader;
            gvUnReqTable.DataBind();
            reader.Close();
            conn.Close();
        }

        protected void gvUnReqTable_RowEditing(object sender, GridViewEditEventArgs e)
        {
            
        }

        protected void AcceptRejectButton(object sender, CommandEventArgs e)
        {
            Button button = (Button)sender;
            GridViewRow row = (GridViewRow)button.NamingContainer;
            int rowIndex = row.RowIndex;

            string username = (string) Session["username"];
            string hostName = gvUnReqTable.Rows[rowIndex].Cells[3].Text;
            string guestName = gvUnReqTable.Rows[rowIndex].Cells[4].Text;
            string startTime = gvUnReqTable.Rows[rowIndex].Cells[5].Text;
        

            string connStr = ConfigurationManager.ConnectionStrings["DBProject"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand addSmProc = new SqlCommand("acceptRequest", conn);
            if (e.CommandName == "Reject")
            {
                addSmProc.CommandText = "rejectRequest";
            }

            addSmProc.CommandType = CommandType.StoredProcedure;

            addSmProc.Parameters.Add(new SqlParameter("@manager_username", username));
            addSmProc.Parameters.Add(new SqlParameter("@host_name", hostName));
            addSmProc.Parameters.Add(new SqlParameter("@guest_name", guestName));
            addSmProc.Parameters.Add(new SqlParameter("@start_time", startTime));

            conn.Open();
            addSmProc.ExecuteNonQuery();
            conn.Close();

            Response.Redirect("StadiumManager.aspx");
        }
    }
}