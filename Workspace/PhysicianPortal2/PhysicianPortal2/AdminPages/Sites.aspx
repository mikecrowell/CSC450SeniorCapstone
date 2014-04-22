<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sites.aspx.cs" MasterPageFile="~/Site.master" Inherits="PhysicianPortal2.AdminPages.Sites" %>

<asp:Content ID="SidebarContent" ContentPlaceHolderID="SidebarContent" runat="server">

    <asp:ScriptManager ID="sm" runat="server"></asp:ScriptManager>

    <script type = "text/javascript">
        function ShowAdd(obj) {
            if (obj.checked) {
                document.getElementById("<%=Panel1.ClientID%>").style.display = "block";
                document.getElementById("<%=Panel2.ClientID%>").style.display = "none";
            }
        }
        function ShowUpdate(obj) {
            if (obj.checked) {
                document.getElementById("<%=Panel2.ClientID%>").style.display = "block";
                document.getElementById("<%=Panel1.ClientID%>").style.display = "none";
            }
        }

    </script> 

    <div id="sidebar" align="left">
        <asp:RadioButton ID="RadioButton1" runat="server" GroupName = "group1"  Text = "Add Site" onclick = "ShowAdd(this)" Checked="True" /> 
        <br /> 
        <br />
        <asp:RadioButton ID="RadioButton2" runat="server"  GroupName = "group1" Text = "Update Site" onclick = "ShowUpdate(this)"/> 
    </div>
    <br />
</asp:Content>
<asp:Content ID="displayContent" ContentPlaceHolderID="mainContent" runat="server">
    <div style="padding-left:10em;"> 
        <h2>Site Management</h2>
        <h3>
            <asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>
        </h3>
        <asp:Panel ID="Panel1" runat="server" style="display:block;">
            <p style="font-weight:bold;">Add Site</p>
            <br />
            <table>
                <tr>
                  <td><asp:Label ID="Label1" runat="server" Text="Label">Site ID: </asp:Label></td>
                  <td><asp:TextBox ID="txtSiteID" runat="server" BorderStyle="Inset"></asp:TextBox></td>
                </tr>
                <tr>
                  <td><asp:Label ID="Label2" runat="server" Text="Label">Site Name: </asp:Label></td>
                  <td><asp:TextBox ID="txtSiteName" runat="server" BorderStyle="Inset"></asp:TextBox></td>
                </tr>
                <tr>
                  <td><asp:Label ID="Label3" runat="server" Text="Label">Address: </asp:Label><br /></td>
                  <td><asp:TextBox ID="txtAddress" runat="server" BorderStyle="Inset"></asp:TextBox></td>
                </tr>
                <tr>
                  <td><asp:Label ID="Label4" runat="server" Text="Label">City: </asp:Label></td>
                  <td><asp:TextBox ID="txtCity" runat="server" BorderStyle="Inset"></asp:TextBox></td>
                </tr>
                <tr>
                  <td><asp:Label ID="Label14" runat="server" Text="Label">State: </asp:Label></td>
                  <td><asp:TextBox ID="txtState" runat="server" BorderStyle="Inset"></asp:TextBox></td>
                </tr>
                <tr>
                  <td><asp:Label ID="Label44" runat="server" Text="Label">Zip: </asp:Label></td>
                  <td><asp:TextBox ID="txtZip" runat="server" BorderStyle="Inset"></asp:TextBox></td>
                </tr>
            </table>
        </asp:Panel>

        <asp:Panel ID="Panel2" runat="server" style="display:none;">
            <p style="font-weight:bold;">Modify Site</p>
            <br />
             <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">    
                   <ContentTemplate>
                        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True"
                        onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                        </asp:DropDownList>
                        <br />
                        <br />
                        <br />
                        <table>
                            <tr>
                              <td><asp:Label ID="Label21" runat="server" Text="Label">Site ID: </asp:Label></td>
                              <td><asp:TextBox ID="txtModSiteID" runat="server" BorderStyle="Inset"></asp:TextBox></td>
                            </tr>
                            <tr>
                              <td><asp:Label ID="Label22" runat="server" Text="Label">Site Name: </asp:Label></td>
                              <td><asp:TextBox ID="txtModSiteName" runat="server" BorderStyle="Inset"></asp:TextBox></td>
                            </tr>
                            <tr>
                              <td><asp:Label ID="Label23" runat="server" Text="Label">Address: </asp:Label><br /></td>
                              <td><asp:TextBox ID="txtModAddress" runat="server" BorderStyle="Inset"></asp:TextBox></td>
                            </tr>
                            <tr>
                              <td><asp:Label ID="Label24" runat="server" Text="Label">City: </asp:Label></td>
                              <td><asp:TextBox ID="txtModCity" runat="server" BorderStyle="Inset"></asp:TextBox></td>
                            </tr>
                            <tr>
                              <td><asp:Label ID="Label214" runat="server" Text="Label">State: </asp:Label></td>
                              <td><asp:TextBox ID="txtModState" runat="server" BorderStyle="Inset"></asp:TextBox></td>
                            </tr>
                            <tr>
                              <td><asp:Label ID="Label224" runat="server" Text="Label">Zip: </asp:Label></td>
                              <td><asp:TextBox ID="txtModZip" runat="server" BorderStyle="Inset"></asp:TextBox></td>
                            </tr>
                        </table>
                   </ContentTemplate> 
            </asp:UpdatePanel>
        </asp:Panel>

        <br />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Submit" onclick="Button1_Click" UseSubmitBehavior="False" />
    </div> 
    

</asp:Content>
