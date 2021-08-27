<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128549835/14.1.6%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T150965)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [HomeController.cs](./CS/Sample/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/Sample/Controllers/HomeController.vb))
* [GridViewPartial.cshtml](./CS/Sample/Views/Home/GridViewPartial.cshtml)
* **[Index.cshtml](./CS/Sample/Views/Home/Index.cshtml)**
<!-- default file list end -->
# GridView - How to conditionally enable and disable the batch editing on the client side
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/t150965)**
<!-- run online end -->


<p>This example demonstrates how to conditionally enable or disable the editing on the client side. You can find detailed steps by clicking below the "Show Implementation Details" link .<br><br></p>
<p><strong>See also:<br></strong><a href="https://www.devexpress.com/Support/Center/p/T150957">ASPxGridView - Batch Editing - How to conditionally enable and disable the editing on the client side</a></p>


<h3>Description</h3>

<p>1) Define a JavaScript variable that will control the edit state of the grid. This variable can be changed by your code or by other means. In this example, it is controlled by a check box:</p>
<code lang="cs">@Html.DevExpress().CheckBox(settings =&gt; {
    settings.Name = "AllowEditCB";
    settings.Properties.ClientSideEvents.CheckedChanged = "OnAllowEditChanged";
}).GetHtml()</code>
<code lang="js">function OnAllowEditChanged(s, e) {
    allowEdit = s.GetValue();
}</code>
<p><br>2) Handle the grid's client-side <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebASPxGridViewScriptsASPxClientGridView_BatchEditStartEditingtopic">BatchEditStartEditing</a> event to cancel the edit operation based on the value of the mentioned variable:</p>
<code lang="js">function OnStartEditing(s, e) {
    e.cancel = !allowEdit;
}</code>
<br>3) Add custom buttons to the command column to call the grid's client-side <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebASPxGridViewScriptsASPxClientGridView_AddNewRowtopic">AddNewRow</a> and <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebASPxGridViewScriptsASPxClientGridView_DeleteRowtopic">DeleteRow</a> methods based on the very same value:<br>
<code lang="cs">settings.CommandColumn.Visible = true;
settings.CommandColumn.SetHeaderTemplateContent(c =&gt; {
    Html.DevExpress().Button(btnSettings =&gt; {
        btnSettings.Name = "addNewBtn";
        btnSettings.Text = "New";
        btnSettings.RenderMode = ButtonRenderMode.Link;
        btnSettings.ClientSideEvents.Click = "OnHeaderNewClick";                
    }).Render();
});
settings.CommandColumn.CustomButtons.Add(new GridViewCommandColumnCustomButton() { ID = "btnDelete", Text = "Delete" });</code>
<code lang="js">function OnHeaderNewClick(s, e) {
    if (allowEdit)
        grid.AddNewRow();
}
function OnCustomButtonClick(s, e) {
    if (e.buttonID == "btnDelete" &amp;&amp; allowEdit)
        grid.DeleteRow(e.visibleIndex);
}</code>
<p>&nbsp;</p>

<br/>


