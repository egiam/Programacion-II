using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiWebAPI.Models
{
    public class Fecha
    {
        public Fecha()
        {
            DateTime hoy = DateTime.Today;
            Numero = hoy.Day;
            Dia = hoy.DayOfWeek.ToString();
            Mes = hoy.Month;
            Anio = hoy.Year;
        }

        public int Numero { get; set; }
        public string Dia { get; set; }
        public int Mes { get; set; }
        public int Anio { get; set; }

    }
}
