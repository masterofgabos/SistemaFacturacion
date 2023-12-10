using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrdenesCompra
{

    public class Metodos

    {

        //METODOS LOGIN

        public static int Login(DatosUsuario pDatosUsuario)
        {

            int retornoLog = 0;

            if (string.IsNullOrEmpty(pDatosUsuario.Correo))
            {
                MessageBox.Show("Debes ingresar un correo");
                return retornoLog;
            }

            if (string.IsNullOrEmpty(pDatosUsuario.Pass))
            {
                MessageBox.Show("Debes ingresar una contraseña");
                return retornoLog;
            }

            if (!pDatosUsuario.Correo.Contains("@"))
            {
                MessageBox.Show("El correo debe tener un @");
                return retornoLog;
            }

            using (SqlConnection conexion = BaseConexion.ObtenerConexion())
            {

                SqlCommand comando = new SqlCommand("SELECT * FROM Usuario WHERE usuario_correo = @correo", conexion);
                comando.Parameters.AddWithValue("@correo", pDatosUsuario.Correo);

                SqlDataReader reader = comando.ExecuteReader();

                if (!reader.Read())
                {
                    MessageBox.Show("No se encontró el usuario");
                    return retornoLog;
                }

                DatosUsuario user = MapDatosUsuarioFromReader(reader);

                if (pDatosUsuario.Pass != user.Pass)
                {
                    MessageBox.Show("Contraseña incorrecta");
                    return retornoLog;
                }

                if (!user.Activo)
                {
                    MessageBox.Show("El usuario no está activo");
                    return retornoLog;
                }

                MessageBox.Show("Login exitoso!");
                retornoLog = 1;

                return retornoLog;

            }

        }

        private static DatosUsuario MapDatosUsuarioFromReader(SqlDataReader reader)
        {
            DatosUsuario datosUsuario = new DatosUsuario();

            datosUsuario.Correo = reader["usuario_correo"].ToString();
            datosUsuario.Pass = reader["usuario_contraseña"].ToString();

            // asignar valor por defecto
            datosUsuario.Activo = true;

            return datosUsuario;
        }

        // METODOS LISTAR ORDENES DE COMPRA

        public static List<DatosOC> ListarOrdenes()
        {
            List<DatosOC> Lista = new List<DatosOC>();
            using (SqlConnection conn = BaseConexion.ObtenerConexion())
            {

                SqlCommand comando = new SqlCommand

                    (string.Format("Select " +
                    "id_oc, " +
                    "cliente_oc, " +
                    "proveedor_oc, " +
                    "cantidad_oc, " +
                    "descripcion_oc," +
                    "producto_oc," +
                    "monto_oc," +
                    "descuentos_oc," +
                    "monto_total_oc," +
                    "fecha_oc," +
                    "rut_cli_oc," +
                    "rut_prov_oc," +
                    "tel_cli_oc," +
                    "tel_prov_oc," +
                    "correo_cli_oc," +
                    "correo_prov_oc," +
                    "dir_cli_oc," +
                    "dir_prov_oc," +
                    "despacho_oc from [OrdenCompra]"), conn);

                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    DatosOC pOC = new DatosOC();

                    pOC.Id_oc = reader.GetInt32(0);
                    pOC.Cliente_oc = reader.GetString(1);
                    pOC.Proveedor_oc = reader.GetString(2);
                    pOC.Cantidad_oc = reader.GetInt32(3);
                    pOC.Descripcion_oc = reader.GetString(4);
                    pOC.Producto_oc = reader.GetString(5);
                    pOC.Monto_oc = reader.GetInt32(6);
                    pOC.Descuentos_oc = reader.GetInt32(7);
                    pOC.Monto_total_oc = reader.GetInt32(8);
                    pOC.Fecha_oc = reader.GetDateTime(9).ToShortDateString();
                    pOC.Rut_cli_oc = reader.GetString(10);
                    pOC.Rut_prov_oc = reader.GetString(11);
                    pOC.Tel_cli_oc = reader.GetInt32(12);
                    pOC.Tel_prov_oc = reader.GetInt32(13);
                    pOC.Correo_cli_oc = reader.GetString(14);
                    pOC.Correo_prov_oc = reader.GetString(15);
                    pOC.Dir_cli_oc = reader.GetString(16);
                    pOC.Dir_prov_oc = reader.GetString(17);
                    pOC.Despacho_oc = reader.GetString(18);

                    Lista.Add(pOC);
                }

                conn.Close();
                return Lista;
            }
        }

<<<<<<< Updated upstream
=======
        //METODOS BUSCAR POR ID


        public static DatosOC ObtenerOrdenPorId(int id)
        {
            using (SqlConnection conn = BaseConexion.ObtenerConexion())
            {
                string consulta = "SELECT id_oc, cliente_oc, proveedor_oc, cantidad_oc, descripcion_oc, producto_oc, monto_oc, descuentos_oc, monto_total_oc, fecha_oc, rut_cli_oc, rut_prov_oc, tel_cli_oc, tel_prov_oc, correo_cli_oc, correo_prov_oc, dir_cli_oc, dir_prov_oc, despacho_oc FROM [OrdenCompra] WHERE id_oc = @Id";

                SqlCommand comando = new SqlCommand(consulta, conn);
                comando.Parameters.AddWithValue("@Id", id);

                SqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    DatosOC pOC = new DatosOC();

                    pOC.Id_oc = reader.GetInt32(0);
                    pOC.Cliente_oc = reader.GetString(1);
                    pOC.Proveedor_oc = reader.GetString(2);
                    pOC.Cantidad_oc = reader.GetInt32(3);
                    pOC.Descripcion_oc = reader.GetString(4);
                    pOC.Producto_oc = reader.GetString(5);
                    pOC.Monto_oc = reader.GetInt32(6);
                    pOC.Descuentos_oc = reader.GetInt32(7);
                    pOC.Monto_total_oc = reader.GetInt32(8);
                    pOC.Fecha_oc = reader.GetDateTime(9).ToShortDateString();
                    pOC.Rut_cli_oc = reader.GetString(10);
                    pOC.Rut_prov_oc = reader.GetString(11);
                    pOC.Tel_cli_oc = reader.GetInt32(12);
                    pOC.Tel_prov_oc = reader.GetInt32(13);
                    pOC.Correo_cli_oc = reader.GetString(14);
                    pOC.Correo_prov_oc = reader.GetString(15);
                    pOC.Dir_cli_oc = reader.GetString(16);
                    pOC.Dir_prov_oc = reader.GetString(17);
                    pOC.Despacho_oc = reader.GetString(18);

                    conn.Close();
                    return pOC;
                }

                conn.Close();
                return null; // Retorna null si no se encuentra la orden con el ID especificado
            }
        }

        //METODOS CAMBIAR ESTADO ORDENES DE COMPRA

        public static int CambiarEstado(DatosOC pDatosDespacho)
        {
            int retornoActualizarDatosModificados = 0;
            using (SqlConnection conexion = BaseConexion.ObtenerConexion())
            {

                using (SqlCommand comando = new SqlCommand(string.Format("Update [OrdenCompra] set despacho_oc= 'Despachado' where id_oc='{0}'",
                        pDatosDespacho.Id_oc), conexion))

                retornoActualizarDatosModificados = comando.ExecuteNonQuery();
                conexion.Close();

            }
            return retornoActualizarDatosModificados;
        }


        //METODOS CALCULAR MONTO TOTAL ORDENES DE COMPRA

        public static int CalcularMonto(DatosOC pDatosDespacho)
        {
            int retornoActualizarDatosModificados = 0;
            using (SqlConnection conexion = BaseConexion.ObtenerConexion())
            {

                using (SqlCommand comando = new SqlCommand(string.Format("Update [OrdenCompra] set monto_total_oc= ((monto_oc - descuento_oc) + (monto_oc*0.19)) where id_oc='{0}'",
                        pDatosDespacho.Id_oc), conexion))

                    retornoActualizarDatosModificados = comando.ExecuteNonQuery();
                conexion.Close();

            }
            return retornoActualizarDatosModificados;
        }

>>>>>>> Stashed changes

        //METODOS AGREGAR ORDENES DE COMPRA

        public static int AgregarOC(DatosOC pDatosOC)
        {
            using (SqlConnection conexion = BaseConexion.ObtenerConexion())
            {
                int retornoAgregarDatosModificados = 0;
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.Text;
<<<<<<< Updated upstream
                    comando.CommandText = "Insert into [OrdenCompra] " +
                        "cliente_oc, " +
                        "proveedor_oc, " +
                        "cantidad_oc, " +
                        "descripcion_oc," +
                        "producto_oc," +
                        "monto_oc," +
                        "descuentos_oc," +
                        "monto_total_oc," +
                        "fecha_oc," +
                        "rut_cli_oc," +
                        "rut_prov_oc," +
                        "tel_cli_oc," +
                        "tel_prov_oc," +
                        "correo_cli_oc," +
                        "correo_prov_oc," +
                        "dir_cli_oc," +
                        "dir_prov_oc) " +

                        "VALUES " +
                        "(@Cliente_oc, " +
                        "@Proveedor_oc, " +
                        "@Cantidad_oc, " +
                        "@Descripcion_oc, " +
                        "@Producto_oc, " +
                        "@Monto_oc, " +
                        "@Descuentos_oc, " +
                        "@Monto_total_oc, " +
                        "@Fecha_oc, " +
                        "@Rut_cli_oc, " +
                        "@Rut_prov_oc, " +
                        "@Tel_cli_oc, " +
                        "@Tel_cli_oc, " +
                        "@Correo_cli_oc, " +
                        "@Correo_prov_oc, " +
                        "@Dir_cli_oc, " +
                        "@Dir_prov_oc)";
=======
                    comando.CommandText = "Insert into [OrdenCompra] (cliente_oc, proveedor_oc, cantidad_oc, descripcion_oc, producto_oc, monto_oc, descuentos_oc,monto_total_oc,fecha_oc,rut_cli_oc, rut_prov_oc, tel_cli_oc, tel_prov_oc, correo_cli_oc, correo_prov_oc, dir_cli_oc, dir_prov_oc, despacho_oc) VALUES " +
                        "(@Cliente_oc, @Proveedor_oc, @Cantidad_oc, @Descripcion_oc, @Producto_oc, @Monto_oc, @Descuentos_oc, 0, @Fecha_oc, @Rut_cli_oc, @Rut_prov_oc, @Tel_cli_oc, @Tel_prov_oc, @Correo_cli_oc, @Correo_prov_oc, @Dir_cli_oc, @Dir_prov_oc, 'EN PROGRESO')";
>>>>>>> Stashed changes

                    comando.Parameters.AddWithValue("@Cliente_oc", pDatosOC.Cliente_oc);
                    comando.Parameters.AddWithValue("@Proveedor_oc", pDatosOC.Proveedor_oc);
                    comando.Parameters.AddWithValue("@Cantidad_oc", pDatosOC.Cantidad_oc);
                    comando.Parameters.AddWithValue("@Descripcion_oc", pDatosOC.Descripcion_oc);
                    comando.Parameters.AddWithValue("@Producto_oc", pDatosOC.Producto_oc);
                    comando.Parameters.AddWithValue("@Monto_oc", pDatosOC.Monto_oc);
                    comando.Parameters.AddWithValue("@Descuentos_oc", pDatosOC.Descuentos_oc);
                    comando.Parameters.AddWithValue("@Monto_total_oc", pDatosOC.Monto_total_oc);
                    comando.Parameters.AddWithValue("@Fecha_oc", DateTime.Parse(pDatosOC.Fecha_oc));
                    comando.Parameters.AddWithValue("@Rut_cli_oc", pDatosOC.Rut_cli_oc);
                    comando.Parameters.AddWithValue("@Rut_prov_oc", pDatosOC.Rut_prov_oc);
                    comando.Parameters.AddWithValue("@Tel_cli_oc", pDatosOC.Tel_cli_oc);
                    comando.Parameters.AddWithValue("@Tel_prov_oc", pDatosOC.Tel_prov_oc);
                    comando.Parameters.AddWithValue("@Correo_cli_oc", pDatosOC.Correo_cli_oc);
                    comando.Parameters.AddWithValue("@Correo_prov_oc", pDatosOC.Correo_prov_oc);
                    comando.Parameters.AddWithValue("@Dir_cli_oc", pDatosOC.Dir_cli_oc);
                    comando.Parameters.AddWithValue("@Dir_prov_oc", pDatosOC.Dir_prov_oc);

                    retornoAgregarDatosModificados = comando.ExecuteNonQuery();
                    conexion.Close();
                }
                return retornoAgregarDatosModificados;
            }
        }

        //METODOS VALIDADORES

        public static void SoloNumeros(KeyPressEventArgs pE)
        {
            if (char.IsDigit(pE.KeyChar))
            {
                pE.Handled = false;
            }
            else if (char.IsControl(pE.KeyChar))
            {
                pE.Handled = false;
            }
            else
            {
                pE.Handled = true;
            }
        }

        public static void SoloLetras(KeyPressEventArgs pE)
        {
            if (Char.IsLetter(pE.KeyChar))
            {
                pE.Handled = false;
            }
            else if (Char.IsControl(pE.KeyChar))
            {
                pE.Handled = false;
            }
            else if (Char.IsSeparator(pE.KeyChar))
            {
                pE.Handled = false;
            }
            else
            {
                pE.Handled = true;
            }
        }



    }


}
