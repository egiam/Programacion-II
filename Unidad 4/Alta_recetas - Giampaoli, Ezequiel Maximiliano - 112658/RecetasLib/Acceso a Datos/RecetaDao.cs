using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecetasLib.Dominio;
using RecetasSLN.Acceso_a_Datos;
using static RecetasSLN.Frm_Alta;

namespace RecetasLib.Acceso_a_Datos
{
    public class RecetaDao: IRecetaDao
    {
		public List<Ingrediente> GetIngredientes()
		{
			List<Ingrediente> lst = new List<Ingrediente>();
			DataTable tabla = HelperDao.ObtenerInstancia().ConsultaSQL("SP_CONSULTAR_INGREDIENTES");
			foreach (DataRow row in tabla.Rows)
			{
				Ingrediente oIngrediente = new Ingrediente();
				oIngrediente.ingredienteId = Convert.ToInt32(row["id_ingrediente"].ToString());
				oIngrediente.nombre = row["n_ingrediente"].ToString();
				oIngrediente.unidad = row["unidad_medida"].ToString();

				lst.Add(oIngrediente);
			}
			return lst;
		}

		public bool InsertarReceta(Receta oReceta)
		{
			bool resultado = true;
			int filasAfectadas = 0;

			filasAfectadas = HelperDao.ObtenerInstancia().EjecutarSQLMaestroDetalle("SP_INSERTAR_RECETA", "SP_INSERTAR_DETALLES", oReceta, Accion.Create);

			if (filasAfectadas == 0) resultado = false;

			return resultado;
		}

		public int ObtenerProximoNumero()
		{
			return HelperDao.ObtenerInstancia().ProximoID("pa_PROXIMO_ID", "@next");
		}

		public bool Save(Receta oReceta)
		{
			throw new NotImplementedException();
		}
	}
}
