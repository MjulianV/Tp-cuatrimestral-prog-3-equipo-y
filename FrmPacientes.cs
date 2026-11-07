using System;
using System.Windows.Forms;

namespace ClinicaTurnos
{
    public partial class FrmPacientes : Form
    {
        public FrmPacientes()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (FrmPacienteDetalle ventana = new FrmPacienteDetalle())
            {
                ventana.ShowDialog(this);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
