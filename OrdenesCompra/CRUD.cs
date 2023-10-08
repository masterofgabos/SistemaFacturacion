using System;
using System.Collections.Generic;
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
