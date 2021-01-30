using Congo_Market_Web.DB_Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Congo_Market_Web.Models
{
    public class MstModel : Connection
    {

        public class Mst_Method
        {
            public static List<DB__Mst_Category_List_Result> DB__Mst_Category_Lis()
            {
                var result = Entities.DB__Mst_Category_List().ToList();

                return result;
            }

            public static List<DB__Mst_Category_List_2_Result> DB__Mst_Category_Lis_2()
            {
                var result = Entities.DB__Mst_Category_List_2().ToList();

                return result;
            }

            public static List<DB__Mst_Color_List_Result> DB__Mst_Color_List()
            {
                List<DB__Mst_Color_List_Result> result = Entities.DB__Mst_Color_List().ToList();

                return result;
            }

            public static List<DB__Mst_Subcategory_List_Result> DB__Mst_Subcategory_List(byte? categoryID)
            {

                List<DB__Mst_Subcategory_List_Result> result = Entities.DB__Mst_Subcategory_List(categoryID).ToList();

                return result;
            }


            public static List<DB__Mst_Make_List_Result> DB__Mst_Make_List()
            {
                List<DB__Mst_Make_List_Result> result = Entities.DB__Mst_Make_List().ToList();

                return result;
            }

            public static List<DB__Mst_Province_List_Result> DB__Mst_Province_List()
            {
                var result = Entities.DB__Mst_Province_List().ToList();

                return result;

            }

            public static List<DB__Mst_Province_List_2_Result> DB__Mst_Province_List_2()
            {
                 var result = Entities.DB__Mst_Province_List_2().ToList();

                return result;

            }

            public static List<DB__Mst_Town_List_Result> DB__Mst_Town_List(byte provinceID)
            {
                List<DB__Mst_Town_List_Result> result = Entities.DB__Mst_Town_List(provinceID).ToList();

                return result;
            }


            public static List<DB__Mst_PropertyType_List_Result> DB__Mst_PropertyType_List()
            {
                List<DB__Mst_PropertyType_List_Result> result = Entities.DB__Mst_PropertyType_List().ToList();

                return result;
            }


            public static List<DB__Mst_TypeVihicle_List_Result> DB__Mst_TypeVihicle_List()
            {
                List<DB__Mst_TypeVihicle_List_Result> result = Entities.DB__Mst_TypeVihicle_List().ToList();

                return result;
            }


        }

       


    }
}