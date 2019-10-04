using EducareApplication.EducareService;
using EducareApplication.EducareService.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EducareApplication.Controllers
{
    public class LoginManagerController : Controller
    {
        private readonly IEducareService _Repository;
        public LoginManagerController(IEducareService repository)
        {
            this._Repository = repository;
        }
         
        [HttpGet]
        public ActionResult AuthenticateUserIdentity()
        {
            return View();
        }

        [HttpPost] 
        [ValidateInput(true)]
        [ValidateAntiForgeryToken]
        public ActionResult AuthenticateUserIdentity(ClaimUserIdentity user)
        {
            if (ModelState.IsValid && this._Repository.IsUserAuthenticated(user))
            {
                FormsAuthentication.SetAuthCookie(user.username.ToString(), false);
                return RedirectToAction("Dashboard", "Registration");
            }

            ViewBag.LoginFailed = "Login Attempt Failed. Request aborted !";
            return View();

        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult RemoveUserIdentity()
        {
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();
            FormsAuthentication.SignOut();
            return RedirectToAction(nameof(AuthenticateUserIdentity));
        }


        [HttpGet]
        public ActionResult ErrorNotFound()
        {
            ViewBag.Url = Request.Url.AbsoluteUri.ToString();
            return View();
        }

    }
}