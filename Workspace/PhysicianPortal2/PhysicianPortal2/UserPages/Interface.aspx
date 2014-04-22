<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Interface.aspx.cs" MasterPageFile="~/Site.master" Inherits="PhysicianPortal2.AdminPages.Interface" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="mainContent" runat="server"  >    
	<div>

	<table width="600px" align="center">
	<tr>
	<td colspan="2">
		<p>
			<asp:GridView ID="GridView2" runat="server">
			</asp:GridView>
		</p>  
	</td>
	</tr>       
		</table>

	</div>
</asp:Content>

<asp:Content ID="Content1" runat="server" contentplaceholderid="HeadContent">
	<style type="text/css">
		.style2
		{
			width: 209px;
		}
	</style>
</asp:Content>
