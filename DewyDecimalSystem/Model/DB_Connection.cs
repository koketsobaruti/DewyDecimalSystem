using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace DewyDecimalSystem.Model
{
    public class DB_Connection
    {
        public static string GetConnection()
        {
            var connectionFromWebConfiguration = WebConfigurationManager.ConnectionStrings["DBConnection"];
            string conn = connectionFromWebConfiguration.ConnectionString;
            return conn;
        }
    }
}