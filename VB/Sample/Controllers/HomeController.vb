Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc

Namespace Sample.Controllers
	Public Class HomeController
		Inherits Controller
		Public Function Index() As ActionResult
			Return View()
		End Function

		Public Function GridViewPartial() As ActionResult
			Dim model = Enumerable.Range(0, 10).Select(Function(i) New With {Key .ID = i, Key .Text = "Text " & i, Key .Checked = i Mod 2 = 0})
			Return PartialView(model)
		End Function
	End Class
End Namespace