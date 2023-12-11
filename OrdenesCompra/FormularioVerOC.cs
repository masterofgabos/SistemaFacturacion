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
using Microsoft.Office.Interop.Excel;


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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void btnbuscarfecha_Click(object sender, EventArgs e)
        {
            string fechaOrdenBuscada = maskedTextBox1.Text;
            if (!string.IsNullOrEmpty(fechaOrdenBuscada))
            {
                DatosOC ordenEncontrada = Metodos.ObtenerOrdenPorFecha(fechaOrdenBuscada);

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
                MessageBox.Show("Ingrese una fecha válida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {

            string fechaOrdenBuscada = maskedTextBox1.Text;
            if (!string.IsNullOrEmpty(fechaOrdenBuscada))
            {
                // Creando la aplicación Excel
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();

                // Creando un nuevo libro dentro de la aplicación Excel
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);

                // Creando una nueva hoja de Excel en el libro
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

                // Mostrar la hoja de Excel detrás del programa
                app.Visible = true;

                // Obtener la referencia de la primera hoja. Por defecto, su nombre es Sheet1.
                // Almacenar su referencia en la variable worksheet
                worksheet = workbook.Sheets["Hoja1"];
                worksheet = workbook.ActiveSheet;

                // Cambiar el nombre de la hoja activa
                worksheet.Name = "Exportado desde el GridView";

                // Almacenar la parte del encabezado en Excel
                for (int i = 1; i < DgvProducto.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = DgvProducto.Columns[i - 1].HeaderText;
                }

                // Almacenar cada valor de fila y columna en la hoja de Excel
                for (int i = 0; i < DgvProducto.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < DgvProducto.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = DgvProducto.Rows[i].Cells[j].Value.ToString();
                    }
                }

                // Guardar la aplicación
                workbook.SaveAs("c:\\salida.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            }
            else
            {
                MessageBox.Show("No se pudo exportar, busque una fecha válida y cuando aparezcan los datos presione el botón", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

}

        private void FormularioVerOC_Load(object sender, EventArgs e)
        {

        }
    }
    
    
}
