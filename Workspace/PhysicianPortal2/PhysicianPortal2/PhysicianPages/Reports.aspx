<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" MasterPageFile="~/Site.master" Inherits="PhysicianPortal2.AdminPages.Reports" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>



<asp:Content ID="SidebarContent" ContentPlaceHolderID="SidebarContent" runat="server">

    <asp:ScriptManager ID="sm" runat="server"></asp:ScriptManager>

    <script type = "text/javascript">
        function ShowUserReport(obj) {
            if (obj.checked) {
                document.getElementById("<%=Panel1.ClientID%>").style.display = "block";
                document.getElementById("<%=Panel2.ClientID%>").style.display = "none";
            }
        }
        function ShowFileReport(obj) {
            if (obj.checked) {
                document.getElementById("<%=Panel2.ClientID%>").style.display = "block";
                document.getElementById("<%=Panel1.ClientID%>").style.display = "none";
            }
        }


    </script> 

    <div id="sidebar" align="left">
        <asp:RadioButton ID="RadioButton1" runat="server" GroupName = "group1"  Text = "Physician Activity Report" onclick = "ShowUserReport(this)" Checked="True" /> 
        <br /> 
        <br />
        <asp:RadioButton ID="RadioButton2" runat="server"  GroupName = "group1" Text = "Test Code Usage Report" onclick = "ShowFileReport(this)"/> 
    </div>
    <br />
</asp:Content>
<asp:Content ID="displayContent" ContentPlaceHolderID="mainContent" runat="server">




    <div style="padding-left:10em;"> 
        <h2>Reports</h2>
        <asp:Panel ID="Panel1" runat="server" style="display:block;">
            <p style="font-weight:bold;">Physician Activity Report</p>
            <br />
            <asp:Button ID="Button2" runat="server" Text="Export to Excel" onclick="Button2_Click" UseSubmitBehavior="False" />
            <p>
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True"  onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:Button ID="Button1" runat="server" Text="All" onclick="Button1_Click" />
                &nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True"  onselectedindexchanged="DropDownList2_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:Button ID="Button4" runat="server" Text="All" onclick="Button1_Click" />
                &nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True"  onselectedindexchanged="DropDownList3_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:Button ID="Button5" runat="server" Text="All" onclick="Button1_Click" />
                &nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="DropDownList4" runat="server" AutoPostBack="True"  onselectedindexchanged="DropDownList4_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:Button ID="Button6" runat="server" Text="All" onclick="Button1_Click" />
            </p>
            <p>
                <asp:GridView ID="GridView1" runat="server">
                </asp:GridView>
            </p>
        </asp:Panel>

        <asp:Panel ID="Panel2" runat="server" style="display:none;">
            <p style="font-weight:bold;">Test Code Usage Report</p>
            <br />
            <asp:Button ID="Button3" runat="server" Text="Export to Excel" onclick="Button3_Click" UseSubmitBehavior="False" />
            <p>
                <asp:GridView ID="GridView2" runat="server">
                </asp:GridView>
            </p>
        </asp:Panel>

    </div> 
    

</asp:Content>
