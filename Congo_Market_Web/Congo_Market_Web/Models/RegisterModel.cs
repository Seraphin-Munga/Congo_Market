using Congo_Market_Web.DB_Connection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Congo_Market_Web.Models
{
    public class RegisterModel : Connection
    {
        [Required]
        public Guid registerID { get; set; }
        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string telephone { get; set; }


        public class Register_Method
        {
            public static bool DB_Register_Creation(RegisterModel model)
            {

                var result = Entities.DB_Register_Creation(model.registerID, model.firstName, model.lastName, model.email, model.password, model.telephone);

                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public static List<DB_Email_Exist_Result> DB_Email_Exist(string email)
            {

                List<DB_Email_Exist_Result> result = Entities.DB_Email_Exist(email).ToList();

                return result;

            }



            public static RegisterModel DB_Register_Detail(Guid registerID)
            {
               var model = new RegisterModel();  

               var  result = Entities.DB_Register_Detail(registerID).FirstOrDefault();

                if (result != null)
                {
                    model.firstName = result.Register_firstName;
                    model.lastName = result.Register_lastName;
                    model.email = result.Register_email;
                    model.telephone = result.Register_telephone;
                    model.registerID = result.Register_registerID;
                }


                return model;
            }

             
            public static bool DB_Register_Update(RegisterModel model)
            {

                var result = Entities.DB_Register_Update(model.registerID, model.firstName, model.lastName, model.telephone);

                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }


            public static RegisterModel DB_Register_Login(string email ,string password)
            {

                var model = new RegisterModel();

                var result = Entities.DB_Register_Login(email, password).FirstOrDefault();

                if (result != null)
                {
                    model.firstName = result.Register_firstName;
                    model.lastName = result.Register_lastName;
                    model.email = result.Register_email;
                    model.telephone = result.Register_telephone;
                    model.registerID = result.Register_registerID;
                }


                return model;

            }


        }


    }
}