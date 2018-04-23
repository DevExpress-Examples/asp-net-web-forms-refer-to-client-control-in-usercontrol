<%@ Control Language="vb" AutoEventWireup="true" CodeFile="WebUserControl.ascx.vb" Inherits="WebUserControl" %>

<dx:ASPxButton ID="btnShow" runat="server" AutoPostBack="false" 
	Text="Open My Own PopupControl" OnInit="btnShow_Init">
</dx:ASPxButton>

<dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" AllowDragging="True" 
	CloseAction="CloseButton" OnInit="ASPxPopupControl1_Init">
</dx:ASPxPopupControl>