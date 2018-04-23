using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sample.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }

        public ActionResult GridViewPartial() {
            var model = Enumerable.Range(0, 10).Select(i => new { ID = i, Text = "Text " + i, Checked = i%2 == 0});
            return PartialView(model);
        }
    }
}