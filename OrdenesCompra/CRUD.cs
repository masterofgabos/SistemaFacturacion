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
            using (SqlConnection conexion = BaseConexion.ObtenerConexion())
            {
                try
                {
                    using (SqlCommand comando = new SqlCommand(string.Format("SELECT Correo, Pass, TipoUsu FROM MaestroUsuario WHERE Correo='{0}' AND Pass='{1}'", pDatosUsuario.Correo, pDatosUsuario.Pass), conexion))
                    {
                        SqlDataReader reader = comando.ExecuteReader();
                        if (reader.Read())
                        {
                            MessageBox.Show("Login exitoso.", "Continuar", MessageBoxButtons.OK);
                            retornoLog = 1;
                            conexion.Close();
                        }
                        else
                        {
                            MessageBox.Show("No tiene acceso a esta app", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            retornoLog = 0;
                            conexion.Close();
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                return retornoLog;
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
