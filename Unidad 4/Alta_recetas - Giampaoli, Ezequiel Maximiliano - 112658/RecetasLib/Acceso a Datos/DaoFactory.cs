using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.Acceso_a_Datos
{
    class DaoFactory:AbstractDaoFactory
    {
        public override IRecetaDao CrearRecetaDao()
        {
            return new RecetaDao();
        }
    }
}
