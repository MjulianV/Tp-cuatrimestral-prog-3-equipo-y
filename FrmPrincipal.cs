using System;
using System.Windows.Forms;

namespace ClinicaTurnos
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void pacientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FrmPacientes ventana = new FrmPacientes())
            {
                ventana.ShowDialog(this);
            }
        }
    }
}
