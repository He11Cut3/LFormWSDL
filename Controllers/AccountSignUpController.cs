using System.Collections.Generic;
using LForm.Models;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using System.Collections.Specialized;
using Umbraco.Core;
using StackExchange.Profiling.Internal;
using LForm.Security;
using System.Runtime.InteropServices.WindowsRuntime;

namespace LForm.Controllers.Surface
{
    public class AccountSignUpController : SurfaceController
    {
        public ActionResult Render()
        {
            var models = new AccountContentModel();
            return PartialView("AccountSignUpForm", models);
        }

        [HttpPost]
        [ValidateUmbracoFormRouteString]
        [ValidateAntiForgeryToken]
        public ActionResult Submit(AccountContentModel models)
        {
            if (!ModelState.IsValid)
            {

                ModelState.AddModelError("", "Проверьте введённые данные");

                return CurrentUmbracoPage();
            }

            var error = "";
            if (!MembershipHelper.AccountSignUp(models, Request.UserHostAddress, ref error))
            {
                ModelState.AddModelError("", error);

                return CurrentUmbracoPage();
            }

            ViewBag.Success = true;
            ViewBag.SuccessMessage = "Аккаунт успешно зарегистрирован.";
            return RedirectToUmbracoPage(1286);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignOut()
        {
            MembershipHelper.LogOff();

            return RedirectToUmbracoPage(1257);
        }
    }
}