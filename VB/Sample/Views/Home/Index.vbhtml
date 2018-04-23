<script type="text/javascript">
    var allowEdit = false;
    function OnStartEditing(s, e) {
        e.cancel = !allowEdit;
    }
    function OnHeaderNewClick(s, e) {
        if (allowEdit)
            gridView.AddNewRow();
    }
    function OnCustomButtonClick(s, e) {
        if (e.buttonID == "btnDelete" && allowEdit)
            gridView.DeleteRow(e.visibleIndex);
    }
    function OnAllowEditChanged(s, e) {
        allowEdit = s.GetValue();
    }
</script>

@Html.DevExpress().CheckBox(
    Sub(settings)
            settings.Name = "AllowEditCB"
            settings.Properties.ClientSideEvents.CheckedChanged = "OnAllowEditChanged"
    End Sub).GetHtml()

@Html.Action("GridViewPartial")