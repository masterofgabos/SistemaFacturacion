﻿using System;
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
    public partial class FormularioVerOC : Form
    {
        public FormularioVerOC()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void cerrarsesion_Click(object sender, EventArgs e)
        {
            FormularioPrincipal ventanalogin = new FormularioPrincipal();
            this.Hide();
            ventanalogin.Show();
        }

        private void salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
