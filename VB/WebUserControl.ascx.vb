Imports System
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxPopupControl

Partial Public Class WebUserControl
	Inherits System.Web.UI.UserControl

	Protected Sub ASPxPopupControl1_Init(ByVal sender As Object, ByVal e As EventArgs)
		Dim popupControl As ASPxPopupControl = DirectCast(sender, ASPxPopupControl)

		popupControl.ClientInstanceName = GetUserControlSpecificId("_popup")
		popupControl.HeaderText = Me.ID & "'s popup"
	End Sub

	Protected Sub btnShow_Init(ByVal sender As Object, ByVal e As EventArgs)
		Dim button As ASPxButton = DirectCast(sender, ASPxButton)

		System.Threading.Thread.Sleep(50)

		Dim randomizer As New Random()

		Dim clickEventCode As String = String.Format("function(s, e) {{    {0}.ShowAtPos({1}, {1});    }}", GetUserControlSpecificId("_popup"), 100 + randomizer.Next(Date.Now.Millisecond))

		button.ClientSideEvents.Click = clickEventCode
	End Sub

	Private Function GetUserControlSpecificId(ByVal elementId As String) As String
		Return Me.ID & elementId
	End Function
End Class