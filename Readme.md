<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128564917/13.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E2102)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# ASP.NET Web Forms - How to refer to a client-side control encapsulated in certain instance of UserControl
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e2102/)**
<!-- run online end -->

This example shows how to refer to a client-side control (pop-up window) encapsulated in certain instance of UserControl.

![](user-controls-with-popups.png)

In this example, a user control contains a ASPxButton and ASPxPopupControl components. When a user clicks the button, the pop-up window appears. The common practice is to set the ClientInstanceName property of the ASPxPopupControl and use it for calling client-side methods:

```aspx
<dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" ClientInstanceName="popupControl" ...  />
```
```jscript
popupControl.Show();  
```
However if you add multiple instances of the same user control onto your page, the `ClientInstanceName` is no longer unique, and both user control instances now open the first popup control. There are two solutions to resolve this issue:

* Dynamically generate client-side code and use the `ClientID` property. It's also necessary to set the `EnableClientSideAPI` property to `true` and clear the `ClientInstanceName` property.
The second approach is a bit simpler, and it is shown in the attached example.
* Dynamically generate a unique value for the `ClientInstanceName` property and also dynamically generate client-side code that uses the correct `ClientInstanceName` value.

## Implementation Details

This example uses the second approach to access the `ASPxPopupControl` on the client. The `ClientInstanceName` property value for ASPxPopupControl and `Click` event handler for ASPxButton are generated dynamically.

```csharp
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
```

## Files to Review

* [Default.aspx](./CS/Default.aspx) (VB: [Default.aspx](./VB/Default.aspx))
* [WebUserControl.ascx](./CS/WebUserControl.ascx) (VB: [WebUserControl.ascx](./VB/WebUserControl.ascx))
* [WebUserControl.ascx.cs](./CS/WebUserControl.ascx.cs) (VB: [WebUserControl.ascx.vb](./VB/WebUserControl.ascx.vb))

## Documentation

* [Access a Control on the Client Side](https://docs.devexpress.com/AspNet/4222/common-concepts/client-side-functionality#access-a-control-on-the-client-side)
* [Access Controls in Templates on the Server](https://docs.devexpress.com/AspNet/403575/common-concepts/access-controls-in-templates-on-the-server)
