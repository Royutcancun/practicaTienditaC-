using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace MiniNook.clases
{
   public class conect
    {

        //conexion de base de dato
        public string conecta()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "localhost";
            builder.InitialCatalog = "RLOPEZ";
            builder.UserID = "sa";
            builder.Password = "123456789";
            //Console.WriteLine(builder);
            return Convert.ToString(builder);
            


            //termina conexion
        }

    }
}
