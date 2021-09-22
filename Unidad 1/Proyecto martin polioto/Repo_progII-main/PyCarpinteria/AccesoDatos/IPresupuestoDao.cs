using System.Data;
using PyCarpinteria.dominio;

namespace PyCarpinteria.AccesoDatos
{
    interface IPresupuestoDao
    {

        bool Crear(Presupuesto oPresupuesto);
        int ObtenerProxNro();
        DataTable ListarProductos();

    }
}