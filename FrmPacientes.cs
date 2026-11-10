using System;
using System.ComponentModel;
using System.Windows.Forms;
using ClinicaTurnos.Dominio;

namespace ClinicaTurnos
{
    public partial class FrmPacientes : Form
    {
        private readonly BindingList<Paciente> pacientes = new BindingList<Paciente>();

        public FrmPacientes()
        {
            InitializeComponent();
            dgvPacientes.DataSource = pacientes;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (FrmPacienteDetalle ventana = new FrmPacienteDetalle())
            {
                if (ventana.ShowDialog(this) == DialogResult.OK)
                {
                    pacientes.Add(ventana.DatosPaciente);
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
