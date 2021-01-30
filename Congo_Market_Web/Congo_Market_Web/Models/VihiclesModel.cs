using Congo_Market_Web.DB_Connection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Congo_Market_Web.Models
{
    public class VihiclesModel : Connection
    {
        [Required]
        public Guid vihiclesID { get; set; }
        [Required]
        public Guid postID { get; set; }
        [Required]
        public  byte makeID { get; set; }
        [Required]
        public  byte typeID { get; set; }
        [Required]
        public byte colorID { get; set; }
        [Required]
        public string fuel { get; set; }
        [Required]
        public string transmission { get; set; }
        [Required]
        public string listBy { get; set; }
        [Required]
        public string mileage { get; set; }


    
        public class Vihicles_Method
        {

           public static bool DB_PostVihicles_Creation(VihiclesModel model)
            {
                var myModel = new PostModel();

                var result = Entities.DB_PostVihicles_Creation(model.vihiclesID, model.postID, model.makeID, model.typeID, model.colorID, model.fuel, model.transmission, 
                               model.listBy, model.mileage, myModel.imagelink,myModel.registerID, myModel.townID, myModel.subcategoryID, myModel.title, myModel.price, myModel.condition, myModel.date, myModel.description, myModel.isSold);


                if (result > 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }


            public static List<DB_PostVihicles_List_Result> DB_PostVihicles_List()
            {
                List<DB_PostVihicles_List_Result> result = new List<DB_PostVihicles_List_Result>().ToList();

                return result;
            }


            public static VihiclesModel DB_PostVihicles_Detail(Guid postID)
            {
                var model = new VihiclesModel();

                var result = Entities.DB_PostVihicles_Detail(postID).FirstOrDefault();

                model.makeID = result.Post_Vihicles_makeID;
                model.mileage = result.Post_Vihicles_mileage;
                model.postID = result.Post_Vihicles_postID;
                model.transmission = result.Post_Vihicles_transmission;
                model.typeID = result.Post_Vihicles_typeID;
                model.vihiclesID = result.Post_Vihicles_vihiclesID;
                model.listBy = result.Post_Vihicles_listBy;

                return model;

            }


            public static bool DB_PostVihicles_Update(VihiclesModel model)
            {
                var myModel = new PostModel();

                var result = Entities.DB_PostVihicles_Update(model.vihiclesID, model.postID, model.makeID, model.typeID, model.colorID, model.fuel, model.transmission, model.listBy, 
                    model.mileage,myModel.imagelink ,myModel.registerID, myModel.townID, myModel.subcategoryID, myModel.title, 
                    myModel.price, myModel.condition, myModel.date, myModel.description, myModel.isSold);

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