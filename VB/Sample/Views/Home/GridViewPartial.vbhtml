@Html.DevExpress().GridView(
    Sub(settings)
            settings.Name = "gridView"
            settings.CallbackRouteValues = New With {.Controller = "Home", .Action = "GridViewPartial"}

            settings.KeyFieldName = "ID"
            settings.SettingsEditing.Mode = GridViewEditingMode.Batch

            settings.CommandColumn.Visible = True
          
            settings.CommandColumn.ShowNewButtonInHeader = True
            settings.CommandColumn.ShowDeleteButton = True
            
            settings.Columns.Add("ID", MVCxGridViewColumnType.TextBox)
            settings.Columns.Add("Text", MVCxGridViewColumnType.TextBox)
            settings.Columns.Add("Checked", MVCxGridViewColumnType.CheckBox)
    
                                
            settings.CellEditorInitialize = Sub(s, e)
                                                    e.Editor.ReadOnly = False                                                  
                                                    DirectCast(e.Editor, ASPxEdit).ValidationSettings.Display = Display.Dynamic
                                            End Sub
        
            settings.ClientSideEvents.BatchEditStartEditing = "OnEditing"
            settings.ClientSideEvents.BatchEditRowDeleting = "OnEditing"
            settings.ClientSideEvents.BatchEditRowInserting = "OnEditing"
    End Sub).Bind(Model).GetHtml()