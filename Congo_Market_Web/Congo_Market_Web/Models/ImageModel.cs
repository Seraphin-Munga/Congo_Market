using Congo_Market_Web.DB_Connection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Congo_Market_Web.Models
{
    public class ImageModel : Connection
    {
        [Required]
        public Guid imageID { get; set; }
        [Required]
        public Guid postID { get; set; }
        [Required]
        public string ImageLinks { get; set; }

        public class Image_Method
        {
            public static bool DB_Image_Creation(ImageModel model)
            {
                var result = Entities.DB_Image_Creation(model.imageID, model.postID, model.ImageLinks);

                if (result > 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }


            public static bool DB_Image_Update(ImageModel model)
            {
                var result = Entities.DB_Image_Update(model.imageID, model.postID, model.ImageLinks);

                if (result > 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }


            public static List<DB_Image_Detail_Result> DB_Image_Detail(Guid postID)
            {

                List<DB_Image_Detail_Result> result = Entities.DB_Image_Detail(postID).ToList();

                return result;

            }

        }

    }
}