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

                //List<AppUser> uList = new List<AppUser>();
                //uList = da.getAppUsersAll();
                //uList.Sort();

                //DropDownList1.DataSource = uList;
                //DropDownList1.DataTextField = "fullName";
                //DropDownList1.DataValueField = "appuserid";
                //DropDownList1.DataBind();

                //List<TRANSACTIONTYPE> ttList = new List<TRANSACTIONTYPE>();
                //ttList = da.getTransactionTypeAll();

                //DropDownList2.DataSource = ttList;
                //DropDownList2.DataTextField = "TTYPE_NAME";
                //DropDownList2.DataValueField = "TTYPE_ID";
                //DropDownList2.DataBind();

                //List<Category> cList = new List<Category>();
                //cList = da.getCategoriesAll();

                //DropDownList3.DataSource = cList;
                //DropDownList3.DataTextField = "categoryName";
                //DropDownList3.DataValueField = "categoryid";
                //DropDownList3.DataBind();

                //List<Extension> eList = new List<Extension>();
                //eList = da.getExtensionsAll();

                //DropDownList4.DataSource = eList;
                //DropDownList4.DataTextField = "fileExtension";
                //DropDownList4.DataValueField = "extensionid";
                //DropDownList4.DataBind();

                //List<UserReport> urList = new List<UserReport>();
                //urList = da.getUserActivityList();
                //GridView1.DataSource = urList;
                //GridView1.DataBind();

                List<TestCodeReport> trList = new List<TestCodeReport>();
                trList = da.getTestCodeUseage();
                GridView2.DataSource = trList;
                GridView2.DataBind();

            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

            //DataAccess da = new DataAccess();
            //List<UserReport> urList = new List<UserReport>();
            //urList = da.getActivityForUser(Int32.Parse(DropDownList1.SelectedValue));

            //GridView1.DataSource = urList;
            //GridView1.DataBind();

        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {

            //DataAccess da = new DataAccess();
            //List<UserReport> urList = new List<UserReport>();
            //urList = da.getActivityByActivityType(Int32.Parse(DropDownList2.SelectedValue));

            //GridView1.DataSource = urList;
            //GridView1.DataBind();

        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {

            //DataAccess da = new DataAccess();
            //List<UserReport> urList = new List<UserReport>();
            //urList = da.getActivityByFileCategory(Int32.Parse(DropDownList3.SelectedValue));

            //GridView1.DataSource = urList;
            //GridView1.DataBind();

        }

        protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
        {

            //DataAccess da = new DataAccess();
            //List<UserReport> urList = new List<UserReport>();
            //urList = da.getActivityByFileType(Int32.Parse(DropDownList4.SelectedValue));

            //GridView1.DataSource = urList;
            //GridView1.DataBind();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //DataAccess da = new DataAccess();
            //List<UserReport> urList = new List<UserReport>();
            //urList = da.getUserActivityList();

            //GridView1.DataSource = urList;
            //GridView1.DataBind();

            //DropDownList1.SelectedIndex = -1;
            //DropDownList1.ClearSelection();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //Response.ContentType = "application/vnd.ms-excel";
            //Response.Charset = "";
            //this.EnableViewState = false;
            //StringWriter writer = new StringWriter();
            //HtmlTextWriter textWriter = new HtmlTextWriter(writer);
            //GridView1.RenderControl(textWriter);
            //Response.Write(writer.ToString());
            //Response.End();
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