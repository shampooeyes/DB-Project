using System;

namespace DB_Project
{
    public partial class Homepage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }


        protected void AdminRedirect(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx?type=admin");
        }
        protected void ManagerRedirect(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx?type=stadium_manager");
        }

        protected void FanRedirect(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx?type=fan");
        }
        protected void SAManagerRedirect(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx?type=sports_association_manager");
        }
        protected void ClubRepresentativeRedirect(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx?type=club_representative");
        }
    }
}