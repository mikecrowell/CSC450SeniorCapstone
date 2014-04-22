// -----------------------------------------------------------------------
// This page allows for maintenance of the test codes.
// The user is given controls to make additions and modifications to the TEST table.
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhysicianPortal2.AdminPages
{
    public partial class Tests : System.Web.UI.Page
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
                addTestCode();
                DropDownList1.DataBind();
            }
            else if (RadioButton2.Checked == true)
            {
                modifyTestCode();
                DropDownList1.DataBind();
            }
        }

        protected void addTestCode()
        {
            if (txtTestCode.Text.Equals("") && txtDescription.Text.Equals(""))
            {
                lblMessage.Text = "All fields must be filled in!";
            }
            else
            {
                DataAccess da = new DataAccess();
                TEST temp = da.getTestCodeByID(txtTestCode.Text);
                if (temp == null)
                {
                    TEST test = new TEST();
                    test.Test_Code = txtTestCode.Text;
                    test.Description = txtDescription.Text;
                    da.addTestCode(test);
                    lblMessage.Text = "New test code has been added.";

                    updateControls();
                }
                else
                {
                    lblMessage.Text = "That test code already exists.  Test code must be unique.";
                }

            }
        }

        protected void modifyTestCode()
        {
            DataAccess da = new DataAccess();
            TEST test = new TEST();
            test = da.getTestCodeByID(txtTestCode.Text);
            if (test == null)
            {
                test = da.getTestCodeByID(DropDownList1.SelectedValue);

                test.Test_Code = txtModTestCode.Text;
                test.Description = txtModDescription.Text;

                da.modifyTestCode(test);

                lblMessage.Text = "Test code has been modified.";

                updateControls();
            }
            else
            {
                lblMessage.Text = "That test code already exists.  Test code must be unique.";
            }

        }


        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            setModTestCodeControls();
        }

        protected void updateControls()
        {
            DataAccess da = new DataAccess();

            List<TEST> testList = new List<TEST>();
            testList = da.getListofAllTests();

            DropDownList1.DataSource = testList;
            DropDownList1.DataTextField = "Test_Code";
            DropDownList1.DataValueField = "Test_Code";
            DropDownList1.DataBind();

            setModTestCodeControls();

            RadioButton1.Checked = true;
            RadioButton2.Checked = false;

        }

        protected void setModTestCodeControls()
        {
            DataAccess da = new DataAccess();
            TEST test;
            test = da.getTestCodeByID(DropDownList1.SelectedValue);
            txtModTestCode.Text = test.Test_Code;
            txtModDescription.Text = test.Description;
        }
    }
}