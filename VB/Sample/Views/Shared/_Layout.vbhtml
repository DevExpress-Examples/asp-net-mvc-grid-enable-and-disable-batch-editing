<!DOCTYPE html>

<html>
<head>
    <title>@ViewBag.Title</title>
    <link href="@Url.Content("~/Content/Site.css")" rel="stylesheet" type="text/css" />

    @Html.DevExpress().GetStyleSheets(
    New StyleSheet With {.ExtensionSuite = ExtensionSuite.NavigationAndLayout},
    New StyleSheet With {.ExtensionSuite = ExtensionSuite.Editors},
    New StyleSheet With {.ExtensionSuite = ExtensionSuite.GridView}
)
    @Html.DevExpress().GetScripts(
    new Script With { .ExtensionSuite = ExtensionSuite.NavigationAndLayout },
    new Script With { .ExtensionSuite = ExtensionSuite.GridView },
    new Script With { .ExtensionSuite = ExtensionSuite.Editors }
)
</head>

<body>
    @RenderBody()
</body>
</html>
