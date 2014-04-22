using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhysicianPortal2
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            DataAccess da = new DataAccess();
            bool test = da.isUserAdmin(Page.User.Identity.Name);

        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void Login1_LoggedIn(object sender, EventArgs e)
        {
            AccountRoleProvider Roles = new AccountRoleProvider();

            DataAccess da = new DataAccess();

        // Load page based on user role
            if (Roles.IsUserInRole(Login1.UserName, "Physician"))
            {
                Response.Redirect("~/PhysicianPages/Physician.aspx");
            }
            else
            {
                Response.Redirect("~/UserPages/User.aspx");
            }
        }

    }
}
