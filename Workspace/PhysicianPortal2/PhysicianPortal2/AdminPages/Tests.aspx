<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tests.aspx.cs" MasterPageFile="~/Site.master" Inherits="PhysicianPortal2.AdminPages.Tests" %>

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
        <asp:RadioButton ID="RadioButton1" runat="server" GroupName = "group1"  Text = "Add Test Code" onclick = "ShowAdd(this)" Checked="True" /> 
        <br /> 
        <br />
        <asp:RadioButton ID="RadioButton2" runat="server"  GroupName = "group1" Text = "Update Test Code" onclick = "ShowUpdate(this)"/> 
    </div>
    <br />
</asp:Content>
<asp:Content ID="displayContent" ContentPlaceHolderID="mainContent" runat="server">
    <div style="padding-left:10em;"> 
        <h2>Test Code Management</h2>
        <h3>
            <asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>
        </h3>
        <asp:Panel ID="Panel1" runat="server" style="display:block;">
            <p style="font-weight:bold;">Add Test Code</p>
            <br />
            <table>
                <tr>
                  <td><asp:Label ID="Label1" runat="server" Text="Label">Test Code: </asp:Label></td>
                  <td><asp:TextBox ID="txtTestCode" runat="server" BorderStyle="Inset"></asp:TextBox></td>
                </tr>
                <tr>
                  <td><asp:Label ID="Label2" runat="server" Text="Label">Description: </asp:Label></td>
                  <td><asp:TextBox ID="txtDescription" runat="server" BorderStyle="Inset"></asp:TextBox></td>
                </tr>
            </table>
        </asp:Panel>

        <asp:Panel ID="Panel2" runat="server" style="display:none;">
            <p style="font-weight:bold;">Modify Test Code</p>
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
                              <td><asp:Label ID="Label21" runat="server" Text="Label">Test Code: </asp:Label></td>
                              <td><asp:TextBox ID="txtModTestCode" runat="server" BorderStyle="Inset"></asp:TextBox></td>
                            </tr>
                            <tr>
                              <td><asp:Label ID="Label22" runat="server" Text="Label">Description: </asp:Label></td>
                              <td><asp:TextBox ID="txtModDescription" runat="server" BorderStyle="Inset"></asp:TextBox></td>
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
