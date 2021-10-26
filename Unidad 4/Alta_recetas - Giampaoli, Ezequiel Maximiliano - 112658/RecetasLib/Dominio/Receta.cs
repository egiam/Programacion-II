using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecetasLib.Dominio;

namespace RecetasLib.Dominio
{
    public class Receta
    {
        public List<DetalleReceta> Detalles { get; set; }

        public Receta()
        {
            Detalles = new List<DetalleReceta>();
        }

        public int recetaNro { get; set; }
        public string nombre { get; set; }
        public int tipo_receta { get; set; }
        public string cheff { get; set; }

		public void AgregarDetalle(DetalleReceta detalle)
		{
			Detalles.Add(detalle);
		}
		public void QuitarDetalle(int indice)
		{
			Detalles.RemoveAt(indice);
		}
	}
}
