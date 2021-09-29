using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PyCarpinteria.servicios;

namespace PyCarpinteria.presentacion
{
    public partial class FrmEditarPresupuesto : Form
    {
        private IService servicio;
        private Accion modo;

        public FrmEditarPresupuesto()
        {
            InitializeComponent();
        }

        private void FrmEditarPresupuesto_Load(object sender, EventArgs e)
        {

        }
    }
}
