// -----------------------------------------------------------------------
// This page provides a selection of the different report 
// options available to the user.
// This page is incomplete.  Only one report has been fully implemented.
// I ran out of time before completing the other reports.
// -----------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace PhysicianPortal2.AdminPages
{
    public partial class Reports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(IsPostBack))
            {
                DataAccess da = new DataAccess();

                List<TestCodeReport> trList = new List<TestCodeReport>();
                trList = da.getTestCodeUseage();
                GridView2.DataSource = trList;
                GridView2.DataBind();

            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Still need to implement
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Still need to implement
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Still need to implement
        }

        protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Still need to implement
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Still need to implement
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            // Still need to implement
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.ContentType = "application/vnd.ms-excel";
            Response.Charset = "";
            this.EnableViewState = false;
            StringWriter writer = new StringWriter();
            HtmlTextWriter textWriter = new HtmlTextWriter(writer);
            GridView2.RenderControl(textWriter);
            Response.Write(writer.ToString());
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //Need to override this method to prevent error when using grid control nested inside form
        }
    }
}