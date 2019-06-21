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
<p>2) &nbsp;Handle the grid's client-side <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebASPxGridViewScriptsASPxClientGridView_BatchEditStartEditingtopic">BatchEditStartEditing</a>,&nbsp;&nbsp;<a href="https://documentation.devexpress.com/#AspNet/DevExpressWebScriptsASPxClientGridView_BatchEditRowDeletingtopic">BatchEditRowDeleting</a>,&nbsp;<a href="https://documentation.devexpress.com/#AspNet/DevExpressWebScriptsASPxClientGridView_BatchEditRowDeletingtopic">BatchEditRowDeleting</a> events to cancel the operation based on the value of the mentioned variable:</p>
<code lang="cs">  settings.ClientSideEvents.BatchEditStartEditing = "OnEditing";
  settings.ClientSideEvents.BatchEditRowDeleting = "OnEditing";
  settings.ClientSideEvents.BatchEditRowInserting = "OnEditing";</code>
<code lang="js">function OnEditing(s, e) {
    e.cancel = !allowEdit;
}</code>

<br/>


