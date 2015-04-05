<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ViewStateOptimizer.Web.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test the ViewStateOptimizer library</title>
</head>
<body>
	<form id="frm" runat="server">
    <asp:ScriptManager ID="sm" runat="server" />
		<div>
			<h3>Use FileViewStateOptimizer for Non-ajax UpdatePanel</h3>
			<asp:GridView ID="gv1" runat="server" AutoGenerateColumns="true"></asp:GridView>
			<asp:Button ID="btnSubmit1" Text="Submit" runat="server" OnClick="btnSubmit1_Click" />
		
			<h3>Use FileViewStateOptimizer for ajax UpdatePanel</h3>
			<asp:UpdatePanel runat="server">
				<ContentTemplate>
					<asp:GridView ID="gv2" runat="server" AutoGenerateColumns="true"></asp:GridView>
					<asp:Button ID="btnSubmit2" Text="Submit" runat="server" OnClick="btnSubmit2_Click" />
				</ContentTemplate>
			</asp:UpdatePanel>
		</div>
    </form>
</body>
</html>
