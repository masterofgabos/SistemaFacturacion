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
    public partial class FormularioMenu : Form
    {
        public FormularioAgregarOC ventanaingresar = new FormularioAgregarOC();
        public FormularioVerOC ventanaver = new FormularioVerOC();

        public FormularioMenu()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            ventanaingresar.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ventanaver.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormularioPrincipal ventanalogin = new FormularioPrincipal();
            this.Hide();
            ventanalogin.Show();
        }

        private void FormularioMenu_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Formulario ventanagestionar = new Formulario();
            this.Hide();
            ventanagestionar.Show();
        }
    }
}
