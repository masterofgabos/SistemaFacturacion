using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrdenesCompra;

namespace OrdenesCompra
{
    public partial class FormularioPrincipal : Form
    {
        public FormularioMenu ventanamenu = new FormularioMenu();
        public FormularioPrincipal()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            DatosUsuario usuario = new DatosUsuario();
            usuario.Correo = txtCorreo.Text;
            usuario.Pass = txtContra.Text;

            int resultado = Metodos.Login(usuario);

            if (resultado == 1)
            {
                ventanamenu.Show();
                this.Hide();
            }
            else
            {
                // error en login
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtContra_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
