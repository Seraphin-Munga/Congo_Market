using Congo_Market_Web.Models;
using School_Management_System_Version_1._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using static Congo_Market_Web.Models.RegisterModel;

namespace Congo_Market_Web.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
  

        public JsonResult DB_Register_Creation(RegisterModel model)
        {
             model.password = _Utility_Function.EncryptPassword(model.password);

             model.registerID = Guid.NewGuid();

            if (Register_Method.DB_Register_Creation(model))
            {
                ViewData["success"] = "successfully";
            }
            {
                ViewBag["success"] = "Something went wrong";
            }

            return Json(JsonRequestBehavior.AllowGet);
        }


        public JsonResult DB_Register_Detail(Guid registerID)
        {
            return Json(Register_Method.DB_Register_Detail(registerID), JsonRequestBehavior.AllowGet);
        }


        public JsonResult Login(string password, string email)
        {
            password = _Utility_Function.EncryptPassword(password);

            var result = Register_Method.DB_Register_Login(email, password);

            if (result.email != null)
            {
                ViewData["islogin"] = "true";
                 
                Session["email"] = result.email;
                Session["telephone"] = result.telephone;
                Session["firstName"] = result.firstName;
                Session["lasName"] = result.lastName;
                Session["registerID"] = result.registerID;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }




     

    }
}