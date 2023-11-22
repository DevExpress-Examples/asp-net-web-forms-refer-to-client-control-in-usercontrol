using System;
using DevExpress.Web;

public partial class WebUserControl : System.Web.UI.UserControl {
    protected void ASPxPopupControl1_Init(object sender, EventArgs e) {
        ASPxPopupControl popupControl = (ASPxPopupControl)sender;
        popupControl.ClientInstanceName = GetUserControlSpecificId("_popup");
        popupControl.HeaderText = this.ID + "'s popup";
    }
    protected void btnShow_Init(object sender, EventArgs e) {
        ASPxButton button = (ASPxButton)sender;
        System.Threading.Thread.Sleep(50);
        Random randomizer = new Random();
        string clickEventCode = string.Format("function(s, e) { {0}.ShowAtPos({1}, {1}); }",
            GetUserControlSpecificId("_popup"), 100 + randomizer.Next(DateTime.Now.Millisecond));
        button.ClientSideEvents.Click = clickEventCode;
    }
    private string GetUserControlSpecificId(string elementId) {
        return this.ID + elementId;
    }
}
