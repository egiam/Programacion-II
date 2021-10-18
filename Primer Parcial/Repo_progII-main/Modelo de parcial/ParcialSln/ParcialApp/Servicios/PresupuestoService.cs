using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParcialApp.Acceso_a_datos;
using ParcialApp.Dominio;

namespace ParcialApp.Servicios
{
    class PresupuestoService:IService
    {
        private IFacturaDao dao;

        public PresupuestoService()
        {
            dao = new FacturaDao(); //acá también podríamos tener una fábrica para crear el DAO.
        }

        public List<Factura> ConsultarPresupuestos(List<Parametro> criterios)
        {
            return dao.GetByFilters(criterios);
        }

        public List<Producto> ConsultarProductos()
        {
            return dao.GetProductos();
        }

        public bool GrabarPresupuesto(Factura oPresupuesto)
        {
            return dao.Save(oPresupuesto);
        }

        public Factura ObtenerPresupuestoPorID(int nro)
        {
            return dao.GetById(nro);
        }

        public bool RegistrarBajaPresupuesto(int presupuesto)
        {
            return dao.Delete(presupuesto);
        }
    }
}
