<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register Src="~/WebUserControl.ascx" TagName="UserControl" TagPrefix="uc" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>How to refer to a client-side control within a UserControl</title>
</head>
<body>
    <form id="mainForm" runat="server">
		<uc:UserControl ID="uc1" runat="server" />
		<uc:UserControl ID="uc2" runat="server" />
    </form>
</body>
</html>