using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OrdenesCompra
{
    public partial class FormularioVerOC : Form
    {
        public FormularioVerOC()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void salir_Click(object sender, EventArgs e)
        {
            FormularioMenu ventanamenu = new FormularioMenu();
            this.Hide();
            ventanamenu.Show();
        }

        private void DgvProducto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DgvProducto.DataSource = Metodos.ListarOrdenes();
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            int idOrdenBuscada;
            if (int.TryParse(textBox1.Text, out idOrdenBuscada))
            {
                DatosOC ordenEncontrada = Metodos.ObtenerOrdenPorId(idOrdenBuscada);

                if (ordenEncontrada != null)
                {

                    List<DatosOC> listaOrdenes = new List<DatosOC> { ordenEncontrada };
                    DgvProducto.DataSource = listaOrdenes;

                    MessageBox.Show("Orden encontrada", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Orden no encontrada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ingrese un ID de orden válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCambiarEstado_Click(object sender, EventArgs e)
        {
            DatosOC cambiarOD = new DatosOC();
            cambiarOD.Id_oc = int.Parse(textBox1.Text);


            int resultado = Metodos.CambiarEstado(cambiarOD);

            if (resultado > 0)
            {
                MessageBox.Show("Datos modificados correctamente", "Datos modificados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                MessageBox.Show("No se pueden modificar los datos", "Error al modificar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
    
}
