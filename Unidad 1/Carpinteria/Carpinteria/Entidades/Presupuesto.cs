using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpinteria
{
    class Presupuesto
    {
        //public Presupuesto(List<DetallePresupuesto> detalles)
        //{
        //    Detalles = new List<DetallePresupuesto>();
        //}

        public Presupuesto()
        {
            Detalles = new List<DetallePresupuesto>();
        }

        public int PresupuestoNro { get; set; }
        public DateTime Fecha { get; set; }
        public string Cliente { get; set; }
        public double Total { get; set; }
        public double Descuento { get; set; }
        public DateTime FechaBaja { get; set; }
        public List<DetallePresupuesto> Detalles { get; set; }


        public void AgregarDetalle(DetallePresupuesto detalle)
        {
            Detalles.Add(detalle);
        }

        public void QuitarDetalle(int indice)
        {
            Detalles.RemoveAt(indice);
        }

        public double CalcularTotal()
        {
            double total = 0;
            for (int i = 0; i < Detalles.Count; i++)
            {
                total += Detalles[i].CalcularSubtotal();
            }
            return total;
            //En foreach
            //foreach (DetallePresupuesto item in Detalles)
            //{
            //    total += item.CalcularSubtotal();
            //}

        }

        public bool Confirmar()
        {
            return true;
        }
    }
}
