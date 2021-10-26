using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecetasLib.Dominio;

namespace RecetasLib.Acceso_a_Datos
{
    public interface IRecetaDao
    {
        public List<Ingrediente> GetIngredientes();
        public bool Save(Receta oFactura);
        public int ObtenerProximoNumero();
        public bool InsertarReceta(Receta oReceta);
    }
}
