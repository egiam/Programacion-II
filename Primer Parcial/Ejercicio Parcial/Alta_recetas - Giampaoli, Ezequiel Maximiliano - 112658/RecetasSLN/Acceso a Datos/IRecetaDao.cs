using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecetasSLN.Dominio;

namespace RecetasSLN.Acceso_a_Datos
{
    interface IRecetaDao
    {
        List<Ingrediente> GetIngredientes();
        bool Save(Receta oFactura);
        int ObtenerProximoNumero();
        bool InsertarReceta(Receta oReceta);
    }
}
