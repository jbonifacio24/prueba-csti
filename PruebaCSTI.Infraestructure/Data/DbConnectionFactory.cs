using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace PruebaCSTI.Infraestructure.Data
{
    public class DbConnectionFactory
    {
        public static SqlConnection CreateConnection()
        {
            return new SqlConnection(
                ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString
            );
        }
    }
}
