// -----------------------------------------------------------------------
// This page displays the interface log.
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhysicianPortal2.AdminPages
{
    public partial class Interface : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataAccess da = new DataAccess();
                GridView2.DataSource = da.getInterfaceLog();
                GridView2.DataBind();
            }
        }
    }
}