using Congo_Market_Web.DB_Connection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Congo_Market_Web.Models
{
    public class PostModel : PostPropertyModel
    {

        [Required]
        public Guid postID  { get; set; }
        [Required]
        public Guid registerID { get; set; }
        [Required]
        public byte townID { get; set; }
        [Required]
        public byte subcategoryID { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public decimal price { get; set; }
        [Required]
        public bool condition { get; set; }
        [Required]
        public bool isSold { get; set; }
        [Required]
        public DateTime date { get; set; }
        [Required]
        public string description { get; set; }

        public string imagelink { get; set; }

        public string telephone { get; set; }

        public string ville { get; set; }


        public PostModel()
        {
            date = DateTime.Now;
        }



        public class Post_Method : Connection
        {

            public static bool  DB_Post_Creation(PostModel model)
            {

                var result = Entities.DB_Post_Creation(model.postID, model.registerID, model.townID, model.subcategoryID, model.title, model.price, model.condition, model.isSold, model.date,model.imagelink ,model.description);

                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                 

             }


            public  static PostModel DB_Post_Detail(Guid postID)
            {
                var model = new PostModel();

                var result = Entities.DB_Post_Detail(postID).FirstOrDefault();


                model.title = result.Post_title;
               
                model.condition = Convert.ToBoolean(result.Post_condition);
                model.date = result.Post_date;
                model.postID = result.Post_postID;
                model.description = result.Post_description;
                model.telephone = result.Register_telephone;
                model.price = result.Post_price;
                model.ville = result.Town_townName;
                model.imagelink = result.Post_imageLink;
                model.registerID = result.Post_registerID;
                model.townID = result.Post_townID;

                if (result.Post_Property_surfaceSize != null)
                {
                    model.surfaceSize = result.Post_Property_surfaceSize;
                    model.bathroom = Convert.ToByte(result.Post_Property_bathroom);
                    model.bethroom = Convert.ToByte(result.Post_Property_bethroom);
                    model.numberOfParking = Convert.ToByte(result.Post_Property_numberOfParking);
                }

                if (result.Post_Vihicles_mileage != null)
                {
                    model.mileage = result.Post_Vihicles_mileage;
                    model.makeName = result.Vihicles_Make_makeName;
                    model.color = result.Post_colorName;
                }
         

                return model;
            }

          public static List<DB_Post_Search_Result> DB_Post_Search(byte? provinceID,string search)
            {
                List<DB_Post_Search_Result> result = Entities.DB_Post_Search(search,provinceID).ToList();

                return result;
            }


            public static List<DB_Post_List_byTitle_Result> DB_Post_List_byTitle(string title)
            {
                List<DB_Post_List_byTitle_Result> result = Entities.DB_Post_List_byTitle(title).ToList();

                return result;
            }


          public static List<DB_Post_List_Result> DB_Post_List()
            {
                List<DB_Post_List_Result> result = Entities.DB_Post_List().ToList();

                return result;
            }

            public static List<DB_Post_List_Customer_Result> DB_Post_List_Customer(Guid registerID)
            {
                List<DB_Post_List_Customer_Result> result = Entities.DB_Post_List_Customer(registerID).ToList();

                return result;
            }
             
            public static bool DB_Post_List_IsSold(Guid postID)
            {

                var result = Entities.DB_Post_List_IsSold(postID);

                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }


            public static List<DB_Post_Subcategory_List_Result> DB_Post_Subcategory_List(byte? subcategoryID,byte? categoryID,byte? provinceID)
            {
                List<DB_Post_Subcategory_List_Result> result = Entities.DB_Post_Subcategory_List(subcategoryID, categoryID, provinceID).ToList();

                return result;
            }


            public static bool DB_Post_Update(PostModel model)
            {

                var result = Entities.DB_Post_Update(model.postID, model.townID, model.subcategoryID, model.title, model.price, model.condition, model.isSold, model.date, model.imagelink,model.description);

                if (result > 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }


        }

    }
}