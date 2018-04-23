@Html.DevExpress().GridView(
    Sub(settings)
            settings.Name = "gridView"
            settings.CallbackRouteValues = New With {.Controller = "Home", .Action = "GridViewPartial"}

            settings.KeyFieldName = "ID"
            settings.SettingsEditing.Mode = GridViewEditingMode.Batch

            settings.CommandColumn.Visible = True
            settings.CommandColumn.SetHeaderTemplateContent(
                Sub(c)
                        Html.DevExpress().Button(Sub(btnSettings)
                                                         btnSettings.Name = "addNewBtn"
                                                         btnSettings.Text = "New"
                                                         btnSettings.RenderMode = ButtonRenderMode.Link
                                                         btnSettings.ClientSideEvents.Click = "OnHeaderNewClick"
                                                 End Sub).Render()
                End Sub)
            settings.CommandColumn.CustomButtons.Add(New GridViewCommandColumnCustomButton() With {.ID = "btnDelete", .Text = "Delete"})

            settings.Columns.Add("ID", MVCxGridViewColumnType.TextBox)
            settings.Columns.Add("Text", MVCxGridViewColumnType.TextBox)
            settings.Columns.Add("Checked", MVCxGridViewColumnType.CheckBox)
    
                                
            settings.CellEditorInitialize = Sub(s, e)
                                                    e.Editor.ReadOnly = False
                                                    If e.Column.FieldName = "ID" OrElse e.Column.FieldName = "Text" Then
                                                        DirectCast(e.Editor, ASPxTextBox).ValidationSettings.Display = Display.Dynamic
                                                    Else
                                                        DirectCast(e.Editor, ASPxCheckBox).ValidationSettings.Display = Display.Dynamic
                                                    End If
                                            End Sub
        
            settings.ClientSideEvents.BatchEditStartEditing = "OnStartEditing"
            settings.ClientSideEvents.CustomButtonClick = "OnCustomButtonClick"
    End Sub).Bind(Model).GetHtml()