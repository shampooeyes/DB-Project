using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
namespace DB_Project
{
    public partial class System_Admin_Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddClub(object sender, EventArgs e)
        {
            string clubName = clubNameTextBox.Text;
            string clubLocation = clubLocationTextBox.Text;

            addClubResponse.ForeColor = Colors.Red;

            if (clubName.IsEmpty())
            {
                addClubResponse.Text = "Club name cannot be empty.";
                return;
            }
            if (clubLocation.IsEmpty())
            {
                addClubResponse.Text = "Club location cannot be empty.";
                return;
            }

            if (clubName.Exceeds20() || clubLocation.Exceeds20())
            {
                addClubResponse.Text = "Make sure inputs are 20 characters or less.";
                return;
            }
            
            string connStr = WebConfigurationManager.ConnectionStrings["DBProject"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand addClubProc = new SqlCommand("addClub", conn);
            addClubProc.CommandType = CommandType.StoredProcedure;
            addClubProc.Parameters.Add(new SqlParameter("@name", clubName));
            addClubProc.Parameters.Add(new SqlParameter("@location", clubLocation));

            conn.Open();
            addClubProc.ExecuteNonQuery();
            conn.Close();

            addClubResponse.ForeColor = Colors.Green;
            addClubResponse.Text = clubName + " successfully added.";
        }
        
        protected void DeleteClub(object sender, EventArgs e)
        {
            string clubName = deleteClubNameTextBox.Text;

            deleteClubResponse.ForeColor = Colors.Red;
            if (clubName.IsEmpty())
            {
                deleteClubResponse.Text = "Club name cannot be empty.";
                return;
            }

            if (clubName.Exceeds20())
            {
                deleteClubResponse.Text = "Make sure text inputs are 20 characters or less."; 
                return;
            }

            string connStr = WebConfigurationManager.ConnectionStrings["DBProject"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand deleteClubProc = new SqlCommand("deleteClub", conn);
            deleteClubProc.CommandType = CommandType.StoredProcedure;
            deleteClubProc.Parameters.Add(new SqlParameter("@name", clubName));

            conn.Open();
            deleteClubProc.ExecuteNonQuery();
            conn.Close();

            deleteClubResponse.ForeColor = Colors.Green;
            deleteClubResponse.Text = clubName + " successfully deleted.";
        }

        protected void AddStadium(object sender, EventArgs e)
        {
            string stadiumName = stadiumNameTextBox.Text;
            string stadiumLocation = stadiumLocationTextBox.Text;
            bool stadiumCapacityValidation = int.TryParse(stadiumCapacityTextBox.Text, out int result);

            addStadiumResponse.ForeColor = Colors.Red;
            if (stadiumName.Exceeds20() || stadiumLocation.Exceeds20())
            {
                addStadiumResponse.Text = "Make sure text inputs are 20 characters or less.";
                return;
            }

            if (!stadiumCapacityValidation)
            {
                addStadiumResponse.Text = "Make sure stadium capacity is a number"; 
                return;
            }

            int stadiumCapacity = int.Parse(stadiumCapacityTextBox.Text);

            string connStr = WebConfigurationManager.ConnectionStrings["DBProject"].ToString();
            SqlConnection conn = new SqlConnection(connStr);


            SqlCommand addStadiumProc = new SqlCommand("addStadium", conn);
            addStadiumProc.CommandType = CommandType.StoredProcedure;
            addStadiumProc.Parameters.Add(new SqlParameter("@name", stadiumName));
            addStadiumProc.Parameters.Add(new SqlParameter("@location", stadiumLocation));
            addStadiumProc.Parameters.Add(new SqlParameter("@capacity", stadiumCapacity));

            conn.Open();
            addStadiumProc.ExecuteNonQuery();
            conn.Close();

            addStadiumResponse.ForeColor = Colors.Green;
            addStadiumResponse.Text = stadiumName + " successfully added.";
        }
        protected void DeleteStadium(object sender, EventArgs e)
        {
            string stadiumName = deleteStadiumNameTextBox.Text;

            deleteStadiumResponse.ForeColor = Colors.Red;
            if (stadiumName.IsEmpty())
            {
                deleteStadiumResponse.Text = "Stadium name cannot be empty.";
                return;
            }

            if (stadiumName.Exceeds20())
            {
                deleteStadiumResponse.Text = "Make sure text inputs are 20 characters or less."; 
                return;
            }

            string connStr = WebConfigurationManager.ConnectionStrings["DBProject"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand deleteStadiumProc = new SqlCommand("deleteStadium", conn);
            deleteStadiumProc.CommandType= CommandType.StoredProcedure;
            deleteStadiumProc.Parameters.Add(new SqlParameter("@name", stadiumName));

            conn.Open();
            deleteStadiumProc.ExecuteNonQuery();
            conn.Close();

            deleteStadiumResponse.ForeColor= Colors.Green;
            deleteStadiumResponse.Text = stadiumName + " successfully deleted.";
        }
        protected void BlockFan(object sender, EventArgs e)
        {
            bool fanIdValidation = int.TryParse(fanIdTextBox.Text, out _);

            blockFanResponse.ForeColor= Colors.Red;
            if (!fanIdValidation)
            {
                blockFanResponse.Text = "Make sure national ID is a number"; 
                return;
            }

            int fanId = int.Parse(fanIdTextBox.Text);

            string connStr = WebConfigurationManager.ConnectionStrings["DBProject"].ToString();
            SqlConnection conn = new SqlConnection(connStr);


            SqlCommand blockFanProc = new SqlCommand("blockFan", conn);
            blockFanProc.CommandType= CommandType.StoredProcedure;
            blockFanProc.Parameters.Add(new SqlParameter("@nat_id", fanId));

            conn.Open();
            blockFanProc.ExecuteNonQuery();
            conn.Close();

            blockFanResponse.ForeColor= Colors.Green;
            blockFanResponse.Text = "National ID: " + fanId + " successfully blocked.";
        }

    }
}