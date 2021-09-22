using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carpinteria.AccesoDatos;

namespace Carpinteria.Servicios
{
    class GestorPresupuesto
    {

        private IPresupuestoDao dao;
        public GestorPresupuesto(AbstractDaoFactory factory)
        {
            dao = factory.CrearPresupuestoDao();
        }
        public int ProximoPresupuesto()
        {
            return dao.ObtenerProxNro();
        }

        public DataTable ObtenerProductos()
        {
            return dao.ListarProductos();
        }

        public bool ConfirmarPresupuesto(Presupuesto oPresupuesto)
        {
            return dao.Crear(oPresupuesto);
        }

    }
}
