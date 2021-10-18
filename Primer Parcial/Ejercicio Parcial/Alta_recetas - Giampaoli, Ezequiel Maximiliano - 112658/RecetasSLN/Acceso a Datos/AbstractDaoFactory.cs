using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.Acceso_a_Datos
{
    abstract class AbstractDaoFactory
    {
        public abstract IRecetaDao CrearRecetaDao();
    }
}
