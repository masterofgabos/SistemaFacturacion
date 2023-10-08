using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdenesCompra
{
    class BaseConexion
    {
        public static SqlConnection ObtenerConexion()
        {
            SqlConnection conexion = new SqlConnection("Server= REVISION-PC; database= OrdenesCompra; Integrated Security= True");
            conexion.Open();


            return conexion;

        }
    }
}
