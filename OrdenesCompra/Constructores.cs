using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdenesCompra
{
    public class DatosOC
    {
        public int Id_oc { get; set; }
        public string Cliente_oc { get; set; }
        public string Proveedor_oc { get; set; }
        public int Cantidad_oc { get; set; }
        public string Descripcion_oc { get; set; }
        public string Producto_oc { get; set; }
        public int Monto_oc { get; set; }
        public int Descuentos_oc { get; set; }
        public int Monto_total_oc { get; set; }
        public string Fecha_oc { get; set; }
        public string Rut_cli_oc { get; set; }
        public string Rut_prov_oc { get; set; }
        public int Tel_cli_oc { get; set; }
        public int Tel_prov_oc { get; set; }
        public string Correo_cli_oc { get; set; }
        public string Correo_prov_oc { get; set; }
        public string Dir_cli_oc { get; set; }
        public string Dir_prov_oc { get; set; }

        public DatosOC() { }

        public DatosOC
            (int pId_oc,
            string pCliente_oc,
            string pProveedor_oc,
            int pCantidad_oc,
            string pDescripcion_oc,
            string pProducto_oc,
            int pMonto_oc,
            int pDescuentos_oc,
            int pMonto_total_oc,
            string pFecha_oc,
            string pRut_cli_oc,
            string pRut_prov_oc,
            int pTel_cli_oc,
            int pTel_prov_oc,
            string pCorreo_cli_oc,
            string pCorreo_prov_oc,
            string pDir_cli_oc,
            string pDir_prov_oc)
        {
            this.Id_oc = pId_oc;
            this.Cliente_oc = pCliente_oc;
            this.Proveedor_oc = pProveedor_oc;
            this.Cantidad_oc = pCantidad_oc;
            this.Descripcion_oc = pDescripcion_oc;
            this.Producto_oc = pProducto_oc;
            this.Monto_oc = pMonto_oc;
            this.Descuentos_oc = pDescuentos_oc;
            this.Monto_total_oc = pMonto_total_oc;
            this.Fecha_oc = pFecha_oc;
            this.Rut_cli_oc = pRut_cli_oc;
            this.Rut_prov_oc = pRut_prov_oc;
            this.Tel_cli_oc = pTel_cli_oc;
            this.Tel_prov_oc = pTel_prov_oc;
            this.Correo_cli_oc = pCorreo_cli_oc;
            this.Correo_prov_oc = pCorreo_prov_oc;
            this.Dir_cli_oc = pDir_cli_oc;
            this.Dir_prov_oc = pDir_prov_oc;

        }

    }

    public class DatosUsuario
    {
        public string Correo { get; set; }
        public string Pass { get; set; }

        public DatosUsuario()
        {

        }

        public DatosUsuario(string pCorreo, string pPass)
        {
            this.Correo = pCorreo;
            this.Pass = pPass;
        }
    }

}
