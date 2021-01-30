using Congo_Market_Web.DB_Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Congo_Market_Web.Models
{
    public class Connection
    {
        public static DB_Congo_MarketEntities Entities = new DB_Congo_MarketEntities();
    }
}