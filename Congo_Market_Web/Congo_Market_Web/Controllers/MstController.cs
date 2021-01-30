using Congo_Market_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Congo_Market_Web.Models.MstModel;

namespace Congo_Market_Web.Controllers
{
    public class MstController : Controller
    {
        // GET: Mst
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult DB__Mst_Category_Lis()
        {
            return Json(Mst_Method.DB__Mst_Category_Lis(),JsonRequestBehavior.AllowGet);
        }

        public JsonResult DB__Mst_Category_Lis_2()
        {
            return Json(Mst_Method.DB__Mst_Category_Lis_2(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DB__Mst_Color_List()
        {

            return Json(Mst_Method.DB__Mst_Color_List(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DB__Mst_Subcategory_List(byte? categoryID)
        {

            return Json(Mst_Method.DB__Mst_Subcategory_List(categoryID), JsonRequestBehavior.AllowGet);
        }

        public  JsonResult DB__Mst_Make_List()
        {
            return Json(Mst_Method.DB__Mst_Make_List(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DB__Mst_Province_List()
        {
            return Json(Mst_Method.DB__Mst_Province_List(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DB__Mst_Province_List_2()
        {
            return Json(Mst_Method.DB__Mst_Province_List_2(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DB__Mst_Town_List(byte provinceID)
        {
            return Json(Mst_Method.DB__Mst_Town_List(provinceID), JsonRequestBehavior.AllowGet);
        }


        public JsonResult DB__Mst_PropertyType_List()
        {
            return Json(Mst_Method.DB__Mst_PropertyType_List(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DB__Mst_TypeVihicle_List()
        {
            return Json(Mst_Method.DB__Mst_TypeVihicle_List(), JsonRequestBehavior.AllowGet);
        }

    }
}