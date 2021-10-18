using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParcialApp.Dominio;

namespace ParcialApp.Servicios
{
    interface IService
    {
        bool RegistrarBajaPresupuesto(int presupuesto);
        List<Factura> ConsultarPresupuestos(List<Parametro> criterios);
        List<Producto> ConsultarProductos();
        bool GrabarPresupuesto(Factura oPresupuesto);

        Factura ObtenerPresupuestoPorID(int nro);
    }
}
