using Congo_Market_Web.DB_Connection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Congo_Market_Web.Models
{
    public class PostPropertyModel : Connection 
    {
        [Required]
        public Guid propertyPostID { get; set; }
        [Required]
        public Guid postID { get; set; }
        [Required]
        public byte propertyType { get; set; }
        [Required]
        public string surfaceSize { get; set; }
        [Required]
        public byte bethroom { get; set; }
        [Required]
        public byte  bathroom { get; set; }
        [Required]
        public string listBy { get; set; }
        [Required]
        public bool petAllow { get; set; }
        [Required]
        public byte numberOfParking { get; set; }

        public string makeName { get; set; }
        public string color { get; set; }

        public string mileage { get; set; }

        public class PostProperty_Method
        {

             
             public static bool DB_PostPoperty_Creation(PostPropertyModel model)
            {
                var myModel = new PostModel();

                var result = Entities.DB_PostPoperty_Creation(model.propertyPostID, model.postID, model.propertyType, model.surfaceSize, model.bethroom, model.bathroom, model.listBy, model.petAllow, 
                                                           model.numberOfParking, myModel.imagelink,myModel.registerID, myModel.townID, myModel.subcategoryID, myModel.title, myModel.price, myModel.condition, myModel.isSold, myModel.date, myModel.description);
                if (result > 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }


            public static PostPropertyModel DB_PostPoperty_Detail(Guid propertyPostID)
            {
                var result = Entities.DB_PostPoperty_Detail(propertyPostID).FirstOrDefault();

                var model = new PostPropertyModel();

                model.bathroom = result.Post_Property_bethroom;
                model.bethroom = result.Post_Property_bethroom;
                model.petAllow = result.Post_Property_petAllow;
                model.propertyPostID = result.Post_Property_propertyPostID;
                model.postID = result.Post_Property_postID;

                return model;
            }


            public static List<DB_PostPoperty_List_Result> DB_PostPoperty_List()
            {
                List<DB_PostPoperty_List_Result> result = new List<DB_PostPoperty_List_Result>().ToList();

                return result;
            }


            public static  bool DB_PostPoperty_Update(PostPropertyModel model)
            {
                var myModel = new PostModel();


                var result = Entities.DB_PostPoperty_Update(model.postID, model.propertyType, model.surfaceSize, model.bethroom, model.bathroom, model.listBy, model.petAllow, 
                                                   model.numberOfParking,myModel.imagelink ,myModel.registerID, myModel.townID, myModel.subcategoryID, myModel.title, myModel.price, myModel.condition, myModel.date, myModel.description, myModel.isSold);

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