// -----------------------------------------------------------------------
// This page displays a list of patients that have been 
// assigned to the logged in physician.
// -----------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhysicianPortal2.PhysicianPages
{
	public partial class Physician : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				DataAccess da = new DataAccess();
				String physID = da.getPhysicianIDByUserID(Page.User.Identity.Name);
				gvPatient.DataSource = da.getPatientsByPhysicianID(physID);
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
