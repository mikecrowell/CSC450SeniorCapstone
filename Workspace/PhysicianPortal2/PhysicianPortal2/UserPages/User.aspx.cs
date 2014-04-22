// -----------------------------------------------------------------------
// This page presents a list of all patients to the user
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhysicianPortal2.UserPages
{
    public partial class User : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            // Controls on the page are bound in the code behind using methods
            // from the DataAccess class.

                DataAccess da = new DataAccess();
                gvPatient.DataSource = da.getAllPatients();
                gvPatient.DataBind();
            }
        }

        protected void gvPatient_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblPtID = (Label)e.Row.FindControl("lblPtID");
                GridView gvOrders = (GridView)e.Row.FindControl("gvOrders");

                string txtptid = lblPtID.Text;

                DataAccess da = new DataAccess();

                gvOrders.DataSource = da.getPatientOrdersByPatientID(txtptid);
                gvOrders.DataBind();

            }
        }

        protected void gvOrders_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblOrderID = (Label)e.Row.FindControl("lblOrderID");
                GridView gvResult = (GridView)e.Row.FindControl("gvResult");

                string txtorderid = lblOrderID.Text;

                DataAccess da = new DataAccess();

                gvResult.DataSource = da.getResultListByOrderID(txtorderid);
                gvResult.DataBind();
            }
        }
    }
}