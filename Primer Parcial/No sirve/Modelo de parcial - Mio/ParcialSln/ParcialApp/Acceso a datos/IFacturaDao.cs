using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParcialApp.Dominio;

namespace ParcialApp.Acceso_a_datos
{
    interface IFacturaDao
    {

        List<Producto> GetProductos();
        bool Save(Factura oFactura);
        int ObtenerProximoNumero();

    }
}
