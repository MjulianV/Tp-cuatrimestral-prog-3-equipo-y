using System;
using System.Windows.Forms;

namespace ClinicaTurnos
{
    public partial class FrmPacienteDetalle : Form
    {
        public FrmPacienteDetalle()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
