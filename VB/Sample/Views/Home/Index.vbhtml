<script type="text/javascript">
    var allowEdit = false;
    function OnEditing(s, e) {
        e.cancel = !allowEdit;
    }
    function OnAllowEditChanged(s, e) {
        allowEdit = s.GetValue();
    }
</script>

@Html.DevExpress().CheckBox(
    Sub(settings)
            settings.Name = "AllowEditCB"
             settings.Text = "Allow Editing"
            settings.Properties.ClientSideEvents.CheckedChanged = "OnAllowEditChanged"
    End Sub).GetHtml()

@Html.Action("GridViewPartial")