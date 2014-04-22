<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User.aspx.cs" MasterPageFile="~/Site.master" Inherits="PhysicianPortal2.UserPages.User" %>


<asp:Content ID="MainContent" ContentPlaceHolderID="mainContent" runat="server"  >    
	<div>

	<script language="javascript" type="text/javascript">
		function divexpandcollapse(divname) {
			var div = document.getElementById(divname);
			var img = document.getElementById('img' + divname);
			if (div.style.display == "none") {
				div.style.display = "inline";
				img.src = "/Images/minus.jpg";
			} else {
				div.style.display = "none";
				img.src = "/Images/plus.jpg";
			}
		}

		function divexpandcollapseChild(divname) {
			var div1 = document.getElementById(divname);
			var img = document.getElementById('img' + divname);
			if (div1.style.display == "none") {
				div1.style.display = "inline";
				img.src = "/Images/minus.jpg";
			} else {
				div1.style.display = "none";
				img.src = "/Images/plus.jpg"; ;
			}
		}
	</script>

	<%-- 
		A multi-level nested Gridview is used (three Gidview controls nested within each other)
		Each child Gridview control is used to present details of the selected row of the parent
		Gridview control.  The first outer Gridview lists patients, the second level Gridview
		lists orders for a patient, and the third level Gridview displays the result for a order.
	--%>

	<table width="600px" align="center">
	<tr>
	<td colspan="2">
	<asp:GridView ID="gvPatient" runat="server"  AutoGenerateColumns="false" 
						ShowFooter="true" Width="600px"
						OnRowDataBound="gvPatient_OnRowDataBound">
	<HeaderStyle 
		BackColor="silver"
		ForeColor="Blue"
	/>
	<Columns>
		<asp:TemplateField ItemStyle-Width="20px">
			<ItemTemplate>
				<a href="JavaScript:divexpandcollapse('div<%# Eval("Patient_ID") %>');">
					<img id="imgdiv<%# Eval("Patient_ID") %>" width="9px" border="0" 
																 src="/Images/plus.jpg" alt="" /></a>                       
			</ItemTemplate>
			<ItemStyle Width="20px" VerticalAlign="Middle"></ItemStyle>
		</asp:TemplateField>
		<asp:TemplateField HeaderText="Patient ID">
		<ItemTemplate>
			<asp:Label ID="lblPtID" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,
																	"Patient_ID") %>'></asp:Label>
		</ItemTemplate>
		</asp:TemplateField>               
		<asp:BoundField DataField="Last_Name" HeaderText="Last Name" />
		<asp:BoundField DataField="First_Name" HeaderText="First Name" />
		<asp:BoundField DataField="DOB" HeaderText="DOB" />
		<asp:BoundField DataField="Address" HeaderText="Address" />
		<asp:BoundField DataField="City" HeaderText="City" />
		<asp:BoundField DataField="State" HeaderText="State" />
		<asp:BoundField DataField="Zip" HeaderText="Zip" />
		<asp:TemplateField>
			<ItemTemplate>
			<tr>
			<td colspan="100%">
			<div id="div<%# Eval("Patient_ID") %>"  style="overflow:auto; display:none;
									position: relative; left: 15px; overflow: auto">
			<asp:GridView ID="gvOrders" runat="server" Width="95%"
									AutoGenerateColumns="false" DataKeyNames="Order_ID"
									OnRowDataBound="gvOrders_OnRowDataBound">			
			<HeaderStyle 
				BackColor="silver"
				ForeColor="Blue"
			/>			
			<Columns>
			<asp:TemplateField ItemStyle-Width="20px">
			<ItemTemplate>
			<a href="JavaScript:divexpandcollapse('div1<%# Eval("Order_ID") %>');">
			<img id="imgdiv1<%# Eval("Order_ID") %>" width="9px" border="0" src="/Images/plus.jpg"
						alt="" /></a>                       
			</ItemTemplate>
			<ItemStyle Width="20px" VerticalAlign="Middle"></ItemStyle>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="Order ID" Visible="false">
			<ItemTemplate>
				<asp:Label ID="lblOrderID" runat="server" Text='<%#DataBinder.Eval
															(Container.DataItem, "Order_ID") %>'></asp:Label>
			</ItemTemplate>
			</asp:TemplateField>
			<asp:BoundField DataField="Order_Id" HeaderText="Order Id" />
			<asp:BoundField DataField="Order_Date" HeaderText="Date" />
			<asp:BoundField DataField="Test_Code" HeaderText="Test Code" />
			<asp:BoundField DataField="Order_Status" HeaderText="Status" />
			<asp:TemplateField>
				<ItemTemplate>
				<tr>
					<td colspan="100%">
						<div id="div1<%# Eval("Order_ID") %>"  style="overflow:auto; display:none;
													position: relative; left: 15px; overflow: auto">
						<asp:GridView ID="gvResult" runat="server" Width="95%"
																AutoGenerateColumns="false">										
						<HeaderStyle 
							BackColor="silver"
							ForeColor="Blue"
						/>						
						<Columns>
						<asp:BoundField DataField="Result_Date" HeaderText="Result Date"/>
						<asp:BoundField DataField="Resulted_By" HeaderText="Resulted By"/>
						<asp:BoundField DataField="Result_Report" HeaderText="Result Report"/>
						</Columns>
						</asp:GridView>
						</div>
					</td>
				</tr>
				</ItemTemplate>
			</asp:TemplateField>
			</Columns>
			</asp:GridView>
			</div>
			</td>
			</tr>
			</ItemTemplate>
		</asp:TemplateField>
	</Columns>
	</asp:GridView>    
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
