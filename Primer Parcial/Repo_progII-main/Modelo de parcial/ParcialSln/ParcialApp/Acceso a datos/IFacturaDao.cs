using ParcialApp.Dominio;
using ParcialApp.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialApp.Acceso_a_datos
{
    interface IFacturaDao
    {

        bool Delete(int nro);
        List<Factura> GetByFilters(List<Parametro> criterios);
        List<Producto> GetProductos();
        bool Save(Factura oFactura);
		int ObtenerProximoNumero();
		bool InsertarFactura(Factura oFactura);

        Factura GetById(int id);
    }
}
