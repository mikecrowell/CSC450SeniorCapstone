// -----------------------------------------------------------------------
// This page allows for maintenance of the physical locations, "Sites",
// that the physicians service.
// The user is given controls to make additions and modifications to the SITE table.
// ----------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhysicianPortal2.AdminPages
{
    public partial class Sites : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(IsPostBack))
            {
                lblMessage.Text = "";
                updateControls();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (RadioButton1.Checked == true)
            {
                addSite();
                DropDownList1.DataBind();
            }
            else if (RadioButton2.Checked == true)
            {
                modifySite();
                DropDownList1.DataBind();
            }
        }

        protected void addSite()
        {
            if (txtSiteID.Text.Equals("") && txtSiteName.Text.Equals("") && txtAddress.Text.Equals("") && txtCity.Text.Equals("") && txtState.Text.Equals("") && txtZip.Text.Equals(""))
            {
                lblMessage.Text = "All fields must be filled in!";
            }
            else
            {
                DataAccess da = new DataAccess();
                SITE temp = da.getSiteByID(txtSiteID.Text);
                if (temp == null)
                {
                    SITE site = new SITE();
                    site.Site_ID = txtSiteID.Text;
                    site.Name = txtSiteName.Text;
                    site.Address = txtAddress.Text;
                    site.City = txtCity.Text;
                    site.State = txtState.Text;
                    site.Zip = txtZip.Text;
                    da.addSite(site);
                    lblMessage.Text = "New site has been added.";

                    updateControls();
                }
                else
                {
                    lblMessage.Text = "That site id already exists.  Site id must be unique.";
                }

            }
        }

        protected void modifySite()
        {
            DataAccess da = new DataAccess();
            SITE site = new SITE();
            site = da.getSiteByID(txtSiteID.Text);
            if (site == null)
            {
                site = da.getSiteByID(DropDownList1.SelectedValue);

                site.Site_ID = txtModSiteID.Text;
                site.Name = txtModSiteName.Text;
                site.Address = txtModAddress.Text;
                site.City = txtModCity.Text;
                site.State = txtModState.Text;
                site.Zip = txtModZip.Text;
                da.modifySite(site);

                lblMessage.Text = "Site has been modified.";

                updateControls();
            }
            else
            {
                lblMessage.Text = "That site ID already exists.  Site ID must be unique.";
            }

        }


        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            setModSiteControls();
        }

        protected void updateControls()
        {
            DataAccess da = new DataAccess();

            List<SITE> siteList = new List<SITE>();
            siteList = da.getListofAllSites();

            DropDownList1.DataSource = siteList;
            DropDownList1.DataTextField = "Name";
            DropDownList1.DataValueField = "Site_ID";
            DropDownList1.DataBind();

            setModSiteControls();

            RadioButton1.Checked = true;
            RadioButton2.Checked = false;

        }

        protected void setModSiteControls()
        {
            DataAccess da = new DataAccess();
            SITE site;
            site = da.getSiteByID(DropDownList1.SelectedValue);
            txtModSiteID.Text = site.Site_ID;
            txtModSiteName.Text  = site.Name;
            txtModAddress.Text = site.Address;
            txtModCity.Text = site.City;
            txtModState.Text = site.State;
            txtModZip.Text = site.Zip;
        }

    }
}