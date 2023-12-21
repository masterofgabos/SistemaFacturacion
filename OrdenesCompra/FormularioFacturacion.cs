using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrdenesCompra
{
    public partial class FormularioFacturacion : Form
    {
        public FormularioFacturacion()
        {
            InitializeComponent();
            dataGridView1.DataSource = Metodos.ListarOrdenes();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnFacturacion_Click(object sender, EventArgs e)
        {
            DatosOC facturarOD = new DatosOC();
            facturarOD.Id_oc = int.Parse(textBox1.Text);


            int resultado = Metodos.CambiarEstado(facturarOD);

            if (resultado > 0)
            {
                dataGridView1.DataSource = Metodos.ListarOrdenes();
                MessageBox.Show("Datos modificados correctamente", "Datos modificados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                MessageBox.Show("No se pueden modificar los datos", "Error al modificar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void salir_Click(object sender, EventArgs e)
        {
            FormularioMenu ventanamenu = new FormularioMenu();
            this.Hide();
            ventanamenu.Show();
        }

        private void FormularioFacturacion_Load(object sender, EventArgs e)
        {

        }
    }
}
