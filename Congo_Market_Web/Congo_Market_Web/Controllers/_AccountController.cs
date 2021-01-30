using Congo_Market_Web.Models;
using Microsoft.AspNet.Identity;
using School_Management_System_Version_1._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using static Congo_Market_Web.Models.RegisterModel;

namespace Congo_Market_Web.Controllers
{
    [Authorize]
    public class _AccountController : Controller
    {
        // GET: _Account
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            Session.RemoveAll();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            ViewData["islogin"] = "false";

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(RegisterModel model)
        {
            model.password = _Utility_Function.EncryptPassword(model.password);

            var result = Register_Method.DB_Register_Login(model.email, model.password);

            if (result.email != null)
            {
                ViewData["islogin"] = "true";

                Session["email"] = result.email;
                Session["telephone"] = result.telephone;
                Session["firstName"] = result.firstName;
                Session["lasName"] = result.lastName;
                Session["registerID"] = result.registerID;

                return RedirectToAction("Create", "Post");
            }

            return View();
        }

        [AllowAnonymous]
        public JsonResult DB_Email_Exist(string email)
        {
            return Json(Register_Method.DB_Email_Exist(email), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            ViewData["islogin"] = "false";
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(RegisterModel model)
        {
            model.password = _Utility_Function.EncryptPassword(model.password);

            model.registerID = Guid.NewGuid();

            if (Register_Method.DB_Register_Creation(model))
            {
                ViewData["success"] = "successfully";

                return RedirectToAction("Login");
            }
            {
                ViewBag["success"] = "Something went wrong";
            }

            return View();
        }

    }
}