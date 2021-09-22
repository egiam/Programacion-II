using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PyCarpinteria.AccesoDatos;

namespace PyCarpinteria.Servicios
{
    class GestorPresupuesto
    {

        private IPresupuestoDao dao;
        public int ProximoPresupuesto()
        {
            return dao.ObtenerProxNro();
        }

    }
}
