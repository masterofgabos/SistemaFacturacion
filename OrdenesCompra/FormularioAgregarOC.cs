using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OrdenesCompra
{
    public partial class FormularioAgregarOC : Form
    {
        public FormularioAgregarOC()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DatosOC pDatosOC = new DatosOC();
            pDatosOC.Cliente_oc = textBox1.Text;
            pDatosOC.Proveedor_oc = textBox2.Text;
            pDatosOC.Cantidad_oc = int.Parse(textBox3.Text);
            pDatosOC.Descripcion_oc = textBox4.Text;
            pDatosOC.Producto_oc = textBox5.Text;
            pDatosOC.Monto_oc = int.Parse(textBox6.Text);
            pDatosOC.Descuentos_oc = int.Parse(textBox7.Text);
            pDatosOC.Fecha_oc = maskedTextBox1.Text;
            pDatosOC.Rut_cli_oc = textBox9.Text;
            pDatosOC.Rut_prov_oc = textBox10.Text;
            pDatosOC.Tel_cli_oc = int.Parse(textBox11.Text);
            pDatosOC.Tel_prov_oc = int.Parse(textBox12.Text);
            pDatosOC.Correo_cli_oc = textBox13.Text;
            pDatosOC.Correo_prov_oc = textBox14.Text;
            pDatosOC.Dir_cli_oc = textBox15.Text;
            pDatosOC.Dir_prov_oc = textBox16.Text;


            int resultado = Metodos.AgregarOC(pDatosOC);

            if (resultado > 0)
            {
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

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            Metodos.SoloNumeros(e);
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            Metodos.SoloNumeros(e);
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            Metodos.SoloNumeros(e);
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            Metodos.SoloNumeros(e);
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            Metodos.SoloNumeros(e);
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            Metodos.SoloNumeros(e);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Metodos.SoloLetras(e);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Metodos.SoloLetras(e);
        }
    }
}