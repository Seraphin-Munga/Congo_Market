using Congo_Market_Web.Models;
using School_Management_System_Version_1._1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Congo_Market_Web.Models.ImageModel;
using static Congo_Market_Web.Models.PostModel;
using static Congo_Market_Web.Models.PostPropertyModel;
using static Congo_Market_Web.Models.RegisterModel;
using static Congo_Market_Web.Models.VihiclesModel;

namespace Congo_Market_Web.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Title(string title)
        {
            return View(Post_Method.DB_Post_List_byTitle(title));
        }

        [HttpGet]
        public ActionResult subcategory_List(byte? subcategoryID,byte? categoryID,byte? provinceID)
        {
            ViewData["islogin"] = "false";

            return View(Post_Method.DB_Post_Subcategory_List(subcategoryID, categoryID, provinceID));
        }

        public ActionResult Create()
        {
            ViewData["islogin"] = "false";
            return View();
        }

        [HttpGet]
        public ActionResult DB_Post_List_Customer()
        {
            ViewData["islogin"] = "false";
            Guid registerID = new Guid(Session["registerID"].ToString());

            return View(Post_Method.DB_Post_List_Customer(registerID));
        }

        public ActionResult DB_Post_List_IsSold(Guid postID)
        {
            ViewData["islogin"] = "false";
            if (Post_Method.DB_Post_List_IsSold(postID))
            {
                return RedirectToAction("DB_Post_List_Customer");
            }
            else
            {
                return RedirectToAction("Create");
            }
        }

        public JsonResult DB_Post_Search(string searchTerm,byte? provinceID)
        {
            return Json(Post_Method.DB_Post_Search(provinceID,searchTerm), JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult Create(PostModel model)
        {

            model.postID = Guid.NewGuid();
            model.registerID = new Guid(Session["registerID"].ToString());
            model.date = DateTime.Now;

            var imageModel = new ImageModel();

            var vihiclesModel = new VihiclesModel();
            var proppertyModel = new PostPropertyModel();

          
            imageModel.postID = model.postID;
            vihiclesModel.vihiclesID = Guid.NewGuid();
            proppertyModel.propertyPostID = Guid.NewGuid();

            string uname = Request["uploadername"];
            HttpFileCollectionBase files = Request.Files;


            for (int i = 0; i < files.Count; i++)
            {
                if (files[i] != null)
                {
                    imageModel.imageID = Guid.NewGuid();

                    HttpPostedFileBase file = files[i];

                    var uploadDir = "/productsImages/" + model.postID;
                    Directory.CreateDirectory(Server.MapPath(uploadDir));
                    string pictName = file.FileName;
                    imageModel.ImageLinks = Path.Combine(Server.MapPath(uploadDir), pictName);
                    file.SaveAs(imageModel.ImageLinks);
                    imageModel.ImageLinks = pictName;

                    if (i == 0)
                    {

                        model.imagelink = pictName;

                        if (Post_Method.DB_Post_Creation(model))
                        {
                            ViewBag.message = "The post has been successfully upload";
                        }
                        else
                        {
                            ViewBag.message = "There is an error an occur";
                        }

                        if (vihiclesModel.fuel != null)
                        {

                            if (Vihicles_Method.DB_PostVihicles_Creation(vihiclesModel))
                            {
                                ViewBag.message = "The post has been successfully upload";
                            }
                            else
                            {
                                ViewBag.message = "There is an error an occur";
                            }

                        }

                        if (proppertyModel.propertyType != 0)
                        {

                            if (PostProperty_Method.DB_PostPoperty_Creation(proppertyModel))
                            {
                                ViewBag.message = "The post has been successfully upload";
                            }
                            else
                            {
                                ViewBag.message = "There is an error an occur";
                            }
                        }
                    }
                    else
                    {
                        Image_Method.DB_Image_Creation(imageModel);
                    }

                }

             }
           

            return Json(JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult List()
        {

            return View(Post_Method.DB_Post_List());
        }

        [HttpGet]
        public ActionResult Detail(Guid postID)
        {
            ViewBag.images = Image_Method.DB_Image_Detail(postID);

            ViewData["islogin"] = "false";
            
            return View(Post_Method.DB_Post_Detail(postID));
        }


        public ActionResult Detail_1(Guid postID)
        {
            ViewBag.images = Image_Method.DB_Image_Detail(postID);

            return View(Post_Method.DB_Post_Detail(postID));
        }



        public JsonResult postUpdate(PostModel model)
        {

            var vihiclesModel = new VihiclesModel();
            var proppertyModel = new PostPropertyModel();
            var imageModel = new ImageModel();


            string uname = Request["uploadername"];
            HttpFileCollectionBase files = Request.Files;


            for (int i = 0; i < files.Count; i++)
            {
                HttpPostedFileBase file = files[i];

                if (file != null)
                {

                    var filePath = Server.MapPath("/productsImages/" + model.postID + "/" + imageModel.ImageLinks);

                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }

                    var uploadDir = "/productsImages/" + model.postID;
                    Directory.CreateDirectory(Server.MapPath(uploadDir));
                    string pictName = file.FileName;
                    imageModel.ImageLinks = Path.Combine(Server.MapPath(uploadDir), pictName);
                    file.SaveAs(imageModel.ImageLinks);
                    imageModel.ImageLinks = pictName;


                    if (i == 1)
                    {
                        model.imagelink = pictName;

                        if (Post_Method.DB_Post_Update(model))
                        {
                            ViewBag.message = "The post has been successfully upload";
                        }
                        else
                        {
                            ViewBag.message = "There is an error an occur";
                        }

                        if (vihiclesModel.fuel != null)
                        {

                            if (Vihicles_Method.DB_PostVihicles_Update(vihiclesModel))
                            {
                                ViewBag.message = "The post has been successfully upload";
                            }
                            else
                            {
                                ViewBag.message = "There is an error an occur";
                            }

                        }

                        if (proppertyModel.propertyType != 0)
                        {

                            if (PostProperty_Method.DB_PostPoperty_Update(proppertyModel))
                            {
                                ViewBag.message = "The post has been successfully upload";
                            }
                            else
                            {
                                ViewBag.message = "There is an error an occur";
                            }

                        }

                    }
                    else
                    {
                        Image_Method.DB_Image_Update(imageModel);
                    }

                }

            }

            return Json(JsonRequestBehavior.AllowGet);

        }


    }
}