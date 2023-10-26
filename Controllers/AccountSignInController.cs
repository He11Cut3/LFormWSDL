using LForm.Models;
using LForm.Security;
using LForm.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace LForm.Controllers
{
    public class AccountSignInController : SurfaceController
    {
        public ActionResult Render()
        {
            var models = new LoginContentModel();
            return PartialView("AccountSignInForm", models);
        }

        [HttpPost]
        [ValidateUmbracoFormRouteString]
        [ValidateAntiForgeryToken]
        public ActionResult Submit(LoginContentModel models)
        {
            if (!ModelState.IsValid)
            {

                ModelState.AddModelError("", "Пользователь не найден");

                return CurrentUmbracoPage();
            }

            var error = "";
            if (!MembershipHelper.AccountSignIn(models, Request.UserHostAddress, ref error))
            {
                ModelState.AddModelError("", error);

                return CurrentUmbracoPage();
            }

            return RedirectToUmbracoPage(1286);
        }
    }
}