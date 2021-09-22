using System.Data;

namespace Carpinteria.AccesoDatos
{
    interface IPresupuestoDao
    {

        bool Crear(Presupuesto oPresupuesto);
        int ObtenerProxNro();
        DataTable ListarProductos();

    }
}