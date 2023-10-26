using System.Web.Mvc;
using LForm.Service;
using LForm.Security;
using Umbraco.Web.Mvc;
using LForm.Models;
using LForm.Dto;

namespace LForm.Controllers
{
    public class UserController : SurfaceController
    {
        private static readonly UserService _service = new UserService();

        public ActionResult Render()
        {
            var error = "";
            var models = _service.GetByEntity(MembershipHelper.Current.UserName, MembershipHelper.Current.Password, MembershipHelper.Current.Id, ref error);
            return PartialView("UserForm", models);
        }

    }
}
